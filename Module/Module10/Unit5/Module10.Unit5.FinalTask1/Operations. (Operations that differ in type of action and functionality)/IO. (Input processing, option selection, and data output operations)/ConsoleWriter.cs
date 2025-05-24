using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.OperationType;

namespace Module10.Unit5.FinalTask1
{
    /// <summary>
    /// Реализация интерфейса IWriter для консольного вывода
    /// </summary>
    public class ConsoleWriter : IWriter
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Поле-словарь названий доступных операций, преобразующий OperationType в читаемые названия
        /// </summary>
        private static readonly Dictionary<OperationType, string> OperationNames = new()
        {
            [Addition] = "Сложение",
            [Subtraction] = "Вычитание",
            [Multiplication] = "Умножение",
            [Division] = "Деление"
        };

        public ConsoleWriter(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Выводит список доступных операций для выбора пользователем
        /// <para>Реализация IWriter</para>
        /// <para>"foreach" преобразуется компилятором в </para>
        /// <code>
        /// IEnumerator&lt;OperationType&gt; enumerator = operations.GetEnumerator();
        /// try
        /// { 
        ///     while (enumerator.MoveNext())
        ///     {
        ///         OperationType op = enumerator.Current;
        ///         Console.WriteLine($"{i++}. {OperationNames[op]}");
        ///     }
        /// } 
        /// finally
        /// {
        ///     IDisposable disposable = enumerator as IDisposable;
        ///     if (disposable != null)
        ///     {
        ///         disposable.Dispose();
        ///     }
        /// }
        /// </code>
        /// </summary>
        /// <param name="operations">Список операций</param>
        public void WriteAvailableOperations(IEnumerable<OperationType> operations)
        {
            int i = 1;

            foreach (var op in operations)
            {
                Console.WriteLine($"{i++}. {OperationNames[op]}");
            }
        }

        /// <summary>
        /// Вывпод операций
        /// </summary>
        /// <param name="operationNames"></param>
        public void WriteAvailableOperations(IEnumerable<string> operationNames)
        {
            int i = 1;
            foreach (var name in operationNames)
            {
                Console.WriteLine($"{i++}. {name}");
            }
        }

        /// <summary>
        /// Вывод блоков
        /// </summary>
        /// <param name="blockNames"></param>
        public void WriteAvailableBlocks(IEnumerable<string> blockNames)
        {
            int i = 1;
            foreach (var name in blockNames)
            {
                Console.WriteLine($"{i++}. {name}");
            }
        }

        /// <summary>
        /// Выводит информационное сообщение стандартного формата
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Выводит сообщение об ошибке с красным цветом текста
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ОШИБКА: {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Выводит результат вычисления с форматированием
        /// </summary>
        /// <param name="result">Результат вычисления</param>
        public void WriteResult(double result)
        {
            Console.WriteLine($"\nРезультат: {result}\n");
        }

        /// <summary>
        /// Метод для калькулятора, подсчитывающий и выводящий результат в консоль
        /// </summary>
        /// <param name="result"></param>
        public double CalculateAndDisplayResult(IMathOperation operation, double[] args)
        {
            _logger.Event($"{nameof(CalculateAndDisplayResult)}", $"Вычисление операции {operation.Name}");
            double result = CalculationExpertiseException.Expertise(operation, args, operation.Calculate(args));

            _logger.Event($"{nameof(CalculateAndDisplayResult)}", $"Отображение результата: {result}");
            WriteResult(result);

            return result;
        }
    }
}
