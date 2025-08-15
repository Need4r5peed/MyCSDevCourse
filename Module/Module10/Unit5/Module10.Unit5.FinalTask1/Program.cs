using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Основной класс приложения "Калькулятор""
    /// <summary>
    /// Основной класс приложения "Калькулятор".
    /// <para>Служит точкой входа и отвечает за инициализацию и запуск приложения:</para>
    /// <list type="bullet">
    ///   <item><description>Конфигурирует DI-контейнер для внедрения зависимостей.</description></item>
    ///   <item><description>Инициализирует логгер и реестр блоков.</description></item>
    ///   <item><description>Запускает основной цикл калькулятора.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public class Main_FinalTask1
    {
        #region Method Description "Точка входа приложения"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Main"/> | Точка входа приложения.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Статический метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, выполняющий запуск приложения:</para>
        /// <list type="number">
        ///   <item><description>Инициализирует DI-контейнер и сервисы.</description></item>
        ///   <item><description>Создаёт и инициализирует логгер и реестр блоков.</description></item>
        ///   <item><description>Запускает основной цикл калькулятора.</description></item>
        ///   <item><description>Обрабатывает исключения и логирует завершение работы.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public static void Main()
        {
            ILogger logger = null;
            try
            {
                // Инициализация DI-контейнера
                var serviceProvider = ConfigureServices();
                // Получение фабрики логгеров
                var getLogger = serviceProvider.GetService<Func<string, ILogger>>();
                // Создание основного логгера
                logger = getLogger("Main");
                // Инициализация реестра блоков
                BlockRegistry.Initialize(getLogger);

                // Логирование начала работы приложения
                logger.Event(nameof(Main), "Запуск приложения 'Калькулятор'");
                // Задержка для эффекта
                Thread.Sleep(3000);

                // Запуск основного цикла калькулятора
                serviceProvider.GetService<Calculator>().Run();
            }
            // Обработка ошибки при неинициализации логгера
            catch (Exception ex) when (logger == null)
            {
                // Вывод критической ошибки в консоль
                Console.Error.WriteLine($"Ошибка инициализации [ЛОГГЕРА]: {ex}");
                // Завершение приложения с кодом ошибки
                Environment.Exit(1);
            }
            // Обработка ошибок инициализации
            catch (Exception ex) when (InitializationError(ex))
            {
                // Логирование ошибки инициализации
                logger?.Error(nameof(Main), $"[Критическая] ошибка инициализации: {ex.Message}");
                // Завершение приложения с кодом ошибки
                Environment.Exit(2);
            }
            // Обработка прочих ошибок
            catch (Exception ex)
            {
                // Логирование прочей ошибки
                logger?.Error(nameof(Main), $"[ИНАЯ] ошибка: {ex.Message}");
            }
            finally
            {
                // Логирование завершения работы
                logger?.Error(nameof(Main), "Завершение работы приложения");
                // Задержка для эффекта
                Thread.Sleep(3000);
            }
        }

        #region Method Description "Проверка ошибок инициализации"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="InitializationError"/> | Проверка ошибок инициализации.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватный статический метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, проверяющий, является ли исключение ошибкой инициализации:</para>
        /// <list type="number">
        ///   <item><description>Принимает исключение для анализа.</description></item>
        ///   <item><description>Проверяет тип исключения.</description></item>
        ///   <item><description>Возвращает булево значение, указывающее на ошибку инициализации.</description></item>
        /// </list>
        /// </summary>
        /// <param name="ex">Исключение типа <see cref="Exception"/> для проверки.</param>
        /// <returns>Булево значение типа <see cref="bool"/>, указывающее, является ли исключение ошибкой инициализации.</returns>
        #endregion
        private static bool InitializationError(Exception ex)
        {
            // Проверка типов исключений, связанных с инициализацией
            return ex is InvalidOperationException // Ошибка разрешения зависимостей
                   || ex is ArgumentNullException // Передача null в критические методы
                   || ex is KeyNotFoundException; // Обращение к несуществующему ключу
        }

        #region Method Description "Конфигурация DI-контейнера"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ConfigureServices"/> | Конфигурация DI-контейнера.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватный статический метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, выполняющий настройку DI-контейнера:</para>
        /// <list type="number">
        ///   <item><description>Создаёт коллекцию сервисов.</description></item>
        ///   <item><description>Регистрирует логгеры, фабрику логгеров и зависимости.</description></item>
        ///   <item><description>Возвращает настроенный провайдер сервисов.</description></item>
        /// </list>
        /// </summary>
        /// <returns>Провайдер сервисов типа <see cref="IServiceProvider"/>.</returns>
        #endregion
        private static IServiceProvider ConfigureServices()
        {
            // Создание коллекции сервисов
            var services = new ServiceCollection();

            // Регистрация логгеров
            services.AddSingleton<MainLogger>();
            services.AddSingleton<ProcedureLogger>();
            services.AddSingleton<OperationLogger>();
            services.AddSingleton<OtherActivitiesLogger>();

            // Регистрация фабрики логгеров
            services.AddTransient<Func<string, ILogger>>(provider => key =>
            {
                // Выбор логгера в зависимости от ключа
                return key switch
                {
                    LoggerTypes.Main => provider.GetService<MainLogger>(),
                    LoggerTypes.Procedure => provider.GetService<ProcedureLogger>(),
                    LoggerTypes.Operation => provider.GetService<OperationLogger>(),
                    _ => provider.GetService<OtherActivitiesLogger>() // Fallback-логгер
                };
            });

            // Регистрация сервисов с явными зависимостями
            services.AddTransient<IReader, ConsoleReader>();

            services.AddTransient<IWriter>(provider =>
                new ConsoleWriter(provider.GetService<Func<string, ILogger>>()(LoggerTypes.Procedure)));

            services.AddTransient<IOperationSelector>(provider =>
                new ConsoleSelection(
                    provider.GetService<IWriter>(),
                    provider.GetService<IReader>(),
                    provider.GetService<Func<string, ILogger>>()(LoggerTypes.Procedure)));

            services.AddTransient<Calculator>(provider =>
                new Calculator(
                    provider.GetService<IReader>(),
                    provider.GetService<IWriter>(),
                    provider.GetService<IOperationSelector>(),
                    provider.GetService<Func<string, ILogger>>()(LoggerTypes.Procedure)));

            services.AddTransient<OperationBlock>(provider =>
                new BasicArithmeticBlock(provider.GetService<Func<string, ILogger>>()));

            services.AddTransient<ISpecializedOperations>(provider =>
                new NumericAddition(provider.GetService<Func<string, ILogger>>()(LoggerTypes.Operation)));

            // Построение провайдера сервисов
            return services.BuildServiceProvider();
        }
    }
}