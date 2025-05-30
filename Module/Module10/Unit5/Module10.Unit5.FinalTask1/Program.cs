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
            /// <summary>
            /// --- Блок 1: Инициализация зависимостей через делегат ---
            /// </summary>
            var appInitializer = () => {
                // Инициализация системы логирования
                var logger = new LoggerForOperation();
                // Инициализация вывода в консоль
                var writer = new ConsoleWriter(logger);
                // Инициализация чтения ввода
                var reader = new ConsoleReader();
                // Инициализация выбора операций
                var selector = new ConsoleSelection(writer, reader, logger);
                // Создание калькулятора со своими зависимостями
                var calculator = new Calculator(           
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
                // Возвращение кортежа с основными компонентами калькулятора
            };

            /// <summary>
            /// --- Блок 2: Получение инициализированных компонентов ---
            /// </summary>
            var (calculator, writer, logger) = appInitializer();
            logger.Event(
                $"\n" +
                $"{nameof(Main)}",
                $"Завершение инициализации компонентов калькулятора в {nameof(appInitializer)}.");

            /// <summary>
            /// --- Блок 3: Запуск основного цикла калькулятора с обработкой исключений через try-catch-finally  ---
            /// </summary>
            try
            {
                logger.Event(
                    $"\n" +
                    $"{nameof(Main)}",
                    $"Переход к запуску {nameof(calculator.Run)}.");
                writer.WriteMessage($"Запуск App \"Калькулятор\".");
                Thread.Sleep(3000);
                calculator.Run();
            }
            // Все непредвиденные исключения:
            catch (Exception ex)
            {
                logger.Error(
                    $"\n" +
                    $"Исключение: {nameof(Exception)},\n" +
                    $"Где: {nameof(calculator.Run)}",
                    ex.Message);
                writer.WriteError($"Непредвиденная ошибка: {ex.Message}");
            }
            // Выход из App
            finally
            {
                logger.Event(
                    $"\n" +
                    $"{nameof(Main)}",
                    $"Работа после {nameof(calculator.Run)}.");
                writer.WriteMessage($"Завершение работы App \"Калькулятор\".");
                Thread.Sleep(3000);
            }
        }
    }
}