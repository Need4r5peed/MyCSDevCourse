using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ParameterOrder;
using static Module10.Unit5.FinalTask1.PositionСhangingDelegates;

/// <summary>
/// Главный класс приложения калькулятора.
/// Объединяет задания 1 и 2 в одном проекте.
/// </summary>
namespace Module10.Unit5.FinalTask1
{
    public class Main_FinalTask1
    {
        /// <summary>
        /// Точка входа в приложение.
        /// Инициализирует зависимости и запускает основной цикл калькулятора.
        /// </summary>
        public static void Main()
        {
            // 1. Инициализация зависимостей через делегат
            var appInitializer = () => {
                var logger = new LoggerForOperation();     // Инициализация системы логирования
                var writer = new ConsoleWriter(logger);          // Инициализация вывода в консоль
                var reader = new ConsoleReader();          // Инициализация чтения ввода
                var selector = new ConsoleSelection(writer, reader, logger); // Инициализация выбора операций
                var calculator = new Calculator(           // Создание калькулятора со всеми зависимостями
                    reader,
                    writer,
                    selector,
                    logger
                    );

                return (
                calculator,
                writer,
                logger
                );
                // Возвращение кортежа с основными компонентами Калькулятора
            };

            // 2. Получение инициализированных компонентов
            var (calculator, writer, logger) = appInitializer();

            // 3. Запуск основного цикла Калькулятора с обработкой исключений через try-catch-finally
            try
            {
                logger.Event("...", "...");
                Thread.Sleep(3000);
                logger.Event("Соединение с App... ", "...");
                Thread.Sleep(2000);
                logger.Event("Соединение с App... ", "Ожидание ответа.");
                Thread.Sleep(2000);
                logger.Event("Соединение с App... ", "Загрузка системы!");
                Thread.Sleep(2000);
                calculator.Run();
            }
            catch (BlockNotFoundException ex)
            {
                // Обработка ошибки отсутствия блока операций
                writer.WriteError($"Блок операций не найден: {ex.BlockName}");
                logger.Error("FatalException", $"Ошибка инициализации. {ex.Message}");
            }
            catch (Exception ex)
            {
                // Обработка всех остальных непредвиденных ошибок
                writer.WriteError($"Непредвиденная ошибка: {ex.Message}");
                logger.Error("FatalException", $"Ошибка: {ex}");
            }
            // Выход из App
            finally
            {
                logger.Event("Разъединение с App", "...");
                Thread.Sleep(3000);
                logger.Event("Разъединение с App", "Ожидание ответа.");
                Thread.Sleep(2000);
                logger.Event("Разъединение с App", "Завершение работы системы.");
            }
        }
    }
}