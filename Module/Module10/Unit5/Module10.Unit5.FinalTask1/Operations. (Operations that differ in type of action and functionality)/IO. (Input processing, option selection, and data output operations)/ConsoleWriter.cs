using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.OperationType;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description Реализация интерфейса IWriter для консольного вывода
    /// <summary>
    /// Реализация интерфейса <see cref="IWriter"/> для консольного вывода.
    /// <para>Класс выполняет:</para>
    /// <list type="bullet">
    ///   <item><description>Вывод списков доступных блоков и операций.</description></item>
    ///   <item><description>Вывод информационных сообщений и ошибок.</description></item>
    ///   <item><description>Вывод результатов вычислений.</description></item>
    ///   <item><description>Обработку и отображение результатов математических операций.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public class ConsoleWriter : IWriter
    {
        #region Field Description "Реализация интерфейса для логирования событий"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="_logger"/> | Реализация интерфейса для логирования событий.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное (<see langword="private"/>) поле только для чтения (<see langword="readonly"/>).</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Содержит экземпляр класса, реализующего интерфейс <see cref="ILogger"/> для логирования событий и ошибок.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Используется для записи событий, связанных с вычислением и отображением результатов.</para>
        /// <remarks>
        /// <para><b>ℹ️ Дополнение:</b></para>
        /// <list type="bullet">
        ///   <item><description>Инициализируется через внедрение зависимости в конструкторе.</description></item>
        /// </list>
        /// </remarks>
        /// </summary>
        #endregion
        private readonly ILogger _logger;

        #region Field Description "Словарь названий операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="OperationNames"/> | Словарь названий операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное (<see langword="private"/>) статическое поле только для чтения (<see langword="readonly"/>).</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Словарь, преобразующий перечисление <see cref="OperationType"/> в читаемые названия операций.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Используется для отображения пользовательских названий операций в консоли.</para>
        /// <remarks>
        /// <para><b>ℹ️ Дополнение:</b></para>
        /// <list type="bullet">
        ///   <item><description>Инициализируется статически с предопределёнными парами ключ-значение.</description></item>
        /// </list>
        /// </remarks>
        /// </summary>
        #endregion
        private static readonly Dictionary<OperationType, string> OperationNames = new()
        {
            [Addition] = "Сложение",
            [Subtraction] = "Вычитание",
            [Multiplication] = "Умножение",
            [Division] = "Деление"
        };

        #region Constructor Description "Конструктор класса"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para>Конструктор класса <see cref="ConsoleWriter"/>.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Конструктор.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Инициализирует поле класса через внедрение зависимости.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <list type="number">
        ///   <item><description>Принимает зависимость через параметр конструктора.</description></item>
        ///   <item><description>Присваивает переданную зависимость приватному полю класса.</description></item>
        /// </list>
        /// </summary>
        /// <param name="logger">Экземпляр интерфейса <see cref="ILogger"/> для логирования событий.</param>
        #endregion
        public ConsoleWriter(ILogger logger)
        {
            // Инициализация поля логгера
            _logger = logger;
        }

        #region Method Description "Вывод списка доступных операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="WriteAvailableOperations(IEnumerable{OperationType})"/> | Вывод списка доступных операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, реализующий вывод списка операций типа <see cref="OperationType"/> в консоль:</para>
        /// <list type="number">
        ///   <item><description>Перебирает коллекцию операций.</description></item>
        ///   <item><description>Отображает каждую операцию с номером и читаемым названием из <see cref="OperationNames"/>.</description></item>
        /// </list>
        /// <para><b>ℹ️ Особенности кода:</b></para>
        /// <para>Цикл <c>foreach</c> преобразуется компилятором в:</para>
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
        /// <param name="operations">Перебираемая коллекция операций типа <see cref="OperationType"/>.</param>
        #endregion
        public void WriteAvailableOperations(IEnumerable<OperationType> operations)
        {
            // Счётчик для нумерации операций
            int i = 1;

            // Перебор операций и вывод их названий
            foreach (var op in operations)
            {
                Console.WriteLine($"{i++}. {OperationNames[op]}");
            }
        }

        #region Method Description "Вывод списка операций по именам"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="WriteAvailableOperations(IEnumerable{string})"/> | Вывод списка операций по именам.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, реализующий вывод списка операций по их строковым именам в консоль:</para>
        /// <list type="number">
        ///   <item><description>Перебирает коллекцию строковых имён операций.</description></item>
        ///   <item><description>Отображает каждое имя с номером.</description></item>
        /// </list>
        /// </summary>
        /// <param name="operationNames">Перебираемая коллекция строковых имён операций.</param>
        #endregion
        public void WriteAvailableOperations(IEnumerable<string> operationNames)
        {
            // Счётчик для нумерации операций
            int i = 1;
            // Перебор имён операций и их вывод
            foreach (var name in operationNames)
            {
                Console.WriteLine($"{i++}. {name}");
            }
        }

        #region Method Description "Вывод списка доступных блоков"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="WriteAvailableBlocks"/> | Вывод списка доступных блоков.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, реализующий вывод списка блоков операций по их строковым именам в консоль:</para>
        /// <list type="number">
        ///   <item><description>Перебирает коллекцию строковых имён блоков.</description></item>
        ///   <item><description>Отображает каждое имя с номером.</description></item>
        /// </list>
        /// </summary>
        /// <param name="blockNames">Перебираемая коллекция строковых имён блоков операций.</param>
        #endregion
        public void WriteAvailableBlocks(IEnumerable<string> blockNames)
        {
            // Счётчик для нумерации блоков
            int i = 1;
            // Перебор имён блоков и их вывод
            foreach (var name in blockNames)
            {
                Console.WriteLine($"{i++}. {name}");
            }
        }

        #region Method Description "Вывод информационного сообщения"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="WriteMessage"/> | Вывод информационного сообщения.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, реализующий вывод информационного сообщения в консоль:</para>
        /// <list type="number">
        ///   <item><description>Принимает текстовое сообщение.</description></item>
        ///   <item><description>Выводит сообщение в консоль без дополнительного форматирования.</description></item>
        /// </list>
        /// </summary>
        /// <param name="message">Текстовое сообщение для вывода.</param>
        #endregion
        public void WriteMessage(string message)
        {
            // Вывод сообщения в консоль
            Console.WriteLine(message);
        }

        #region Method Description "Вывод сообщения об ошибке"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="WriteError"/> | Вывод сообщения об ошибке.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, реализующий вывод сообщения об ошибке в консоль с выделением красным цветом:</para>
        /// <list type="number">
        ///   <item><description>Устанавливает красный цвет текста в консоли.</description></item>
        ///   <item><description>Выводит сообщение об ошибке с префиксом "ОШИБКА:".</description></item>
        ///   <item><description>Сбрасывает цвет текста в консоли.</description></item>
        /// </list>
        /// </summary>
        /// <param name="message">Текст сообщения об ошибке.</param>
        #endregion
        public void WriteError(string message)
        {
            // Установка красного цвета текста
            Console.ForegroundColor = ConsoleColor.Red;
            // Вывод сообщения об ошибке
            Console.WriteLine($"ОШИБКА: {message}");
            // Сброс цвета текста
            Console.ResetColor();
        }

        #region Method Description "Вывод результата вычисления"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="WriteResult"/> | Вывод результата вычисления.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, реализующий вывод результата вычисления в консоль с форматированием:</para>
        /// <list type="number">
        ///   <item><description>Принимает результат вычисления.</description></item>
        ///   <item><description>Выводит результат с добавлением пустых строк для визуального выделения.</description></item>
        /// </list>
        /// </summary>
        /// <param name="result">Результат вычисления типа <see cref="double"/>.</param>
        #endregion
        public void WriteResult(double result)
        {
            // Вывод результата с форматированием
            Console.WriteLine($"\nРезультат: {result}\n");
        }

        #region Method Description "Вычисление и вывод результата операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="CalculateAndDisplayResult"/> | Вычисление и вывод результата операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, реализующий вычисление результата математической операции и его вывод в консоль:</para>
        /// <list type="number">
        ///   <item><description>Логирует начало вычисления с помощью <see cref="_logger"/>.</description></item>
        ///   <item><description>Выполняет вычисление с проверкой через <see cref="CalculationExpertiseException.Expertise"/>.</description></item>
        ///   <item><description>Логирует результат вычисления.</description></item>
        ///   <item><description>Выводит результат в консоль через <see cref="WriteResult"/>.</description></item>
        ///   <item><description>Возвращает результат вычисления.</description></item>
        /// </list>
        /// </summary>
        /// <param name="operation">Математическая операция типа <see cref="IMathOperation"/>.</param>
        /// <param name="args">Массив аргументов типа <see cref="double"/>[].</param>
        /// <returns>Результат вычисления типа <see cref="double"/>.</returns>
        /// <exception cref="CalculationException">Выбрасывается, если вычисление операции завершается с ошибкой.</exception>
        #endregion
        public double CalculateAndDisplayResult(
            IMathOperation operation, 
            double[] args)
        {
            // Логирование начала вычисления
            _logger.Event($"{nameof(CalculateAndDisplayResult)}", $"Вычисление операции {operation.Name}");
            // Выполнение вычисления с проверкой на ошибки
            double result = CalculationExpertiseException.Expertise(operation, args, operation.Calculate(args));

            // Логирование результата
            _logger.Event($"{nameof(CalculateAndDisplayResult)}", $"Отображение результата: {result}");
            // Вывод результата в консоль
            WriteResult(result);

            // Возврат результата
            return result;
        }
    }
}