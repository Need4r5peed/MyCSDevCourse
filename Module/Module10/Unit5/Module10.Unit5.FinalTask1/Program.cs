using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace Module10.Unit5.FinalTask1
{
    public class Main_FinalTask1
    {
        public static void Main()
        {
            ILogger logger = null;
            try
            {
                // 1. Инициализация DI-контейнера и сервисов
                var serviceProvider = ConfigureServices();
                var getLogger = serviceProvider.GetService<Func<string, ILogger>>(); // Получаем фабрику один раз
                logger = getLogger("Main"); // Создаём основной логгер
                BlockRegistry.Initialize(getLogger); // Передаём фабрику в реестр

                // Основная логика
                logger.Event(nameof(Main), "Запуск приложения 'Калькулятор'");
                Thread.Sleep(3000);
                serviceProvider.GetService<Calculator>().Run();
            }
            // Исключение при неинициализации логгера.
            catch (Exception ex) when (logger == null)
            {
                Console.Error.WriteLine($"Ошибка инициализации [ЛОГГЕРА]: {ex}");
                Environment.Exit(1);
            }
            // Другие ошибки инициализации
            catch (Exception ex) when (InitializationError(ex))
            {
                // Обработка ошибок инициализации
                logger?.Error(nameof(Main), $"[Критическая] ошибка инициализации: {ex.Message}");
                Environment.Exit(2);
            }
            catch (Exception ex)
            {
                logger?.Error(nameof(Main), $"[ИНАЯ] ошибка: {ex.Message}");
            }
            finally
            {
                logger?.Error(nameof(Main), "Завершение работы приложения");
                Thread.Sleep(3000);
            }
        }

        private static bool InitializationError(Exception ex)
        {
            return ex is InvalidOperationException // Исключение, когда DI-контейнер не может разрешить
                                                   // зависимости (например, сервис не зарегистрирован)
                   || ex is ArgumentNullException // Исключение, когда происходит передача null в критически важные методы
                   || ex is KeyNotFoundException; // Исключение, когда происходит обращение к несуществующему ключу в словаре/реестре
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // 1. Регистрация логгеров
            services.AddSingleton<MainLogger>();
            services.AddSingleton<ProcedureLogger>();
            services.AddSingleton<OperationLogger>();
            services.AddSingleton<OtherActivitiesLogger>();

            // 2. Фабрика логгеров
            services.AddTransient<Func<string, ILogger>>(provider => key =>
            {
                return key switch
                {
                    LoggerTypes.Main => provider.GetService<MainLogger>(),
                    LoggerTypes.Procedure => provider.GetService<ProcedureLogger>(),
                    LoggerTypes.Operation => provider.GetService<OperationLogger>(),
                    _ => provider.GetService<OtherActivitiesLogger>() // Fallback
                };
            });

            // 3. Регистрация сервисов с явным указанием зависимостей
            services.AddTransient<IReader, ConsoleReader>();

            services.AddTransient<IWriter>(provider =>
                new ConsoleWriter(provider.GetService<Func<string, ILogger>>()(LoggerTypes.Procedure)
                ));

            services.AddTransient<IOperationSelector>(provider =>
                new ConsoleSelection(
                    provider.GetService<IWriter>(),
                    provider.GetService<IReader>(),
                    provider.GetService<Func<string, ILogger>>()(LoggerTypes.Procedure)
                ));

            services.AddTransient<Calculator>(provider =>
                new Calculator(
                    provider.GetService<IReader>(),
                    provider.GetService<IWriter>(),
                    provider.GetService<IOperationSelector>(),
                    provider.GetService<Func<string, ILogger>>()(LoggerTypes.Procedure)
                ));

            services.AddTransient<OperationBlock>(provider =>
                new BasicArithmeticBlock(provider.GetService<Func<string, ILogger>>()
                ));

            services.AddTransient<ISpecializedOperations>(provider =>
                new NumericAddition(provider.GetService<Func<string, ILogger>>()(LoggerTypes.Operation)
                ));

            return services.BuildServiceProvider();
        }
    }
}