using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static Module10.Unit5.FinalTask1.ResultOfPreviousIterations;
using System.Diagnostics.Metrics;

namespace Module10.Unit5.FinalTask1
{
    #region Enum Description Перечисление ключей для управления блоками процедур калькулятора
    /// <summary>
    /// Перечисление ключей для управления блоками процедур калькулятора.
    /// <para>Определяет этапы выполнения калькулятора и переходы между ними:</para>
    /// <list type="bullet">
    ///   <item><description>Управляет выбором блоков, операций, аргументов и результатов.</description></item>
    ///   <item><description>Обеспечивает обработку повторов и возвратов к определённым этапам.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public enum BlockKey
    {
        SelectBlock,               // Выбор блока операций
        SelectOperation,           // Выбор конкретной операции
        ShowPastResults,           // Вывод результатов прошлых итераций
        InputArguments,            // Ввод аргументов для операции
        CalculateResult,           // Вычисление результата операции
        SaveResult,                // Сохранение результата
        ContinuePrompt,            // Запрос на продолжение работы
        Exit,                      // Выход из цикла калькулятора
        RetryCurrent,              // Повтор текущего блока
        ReturnToOperationSelection // Возврат к выбору операции
    }

    #region Class Description "Класс калькулятора для выполнения математических операций"
    /// <summary>
    /// Класс калькулятора для выполнения математических операций.
    /// <para>Реализует основной цикл работы с использованием зависимостей:</para>
    /// <list type="bullet">
    ///   <item><description>Управляет выбором блоков, операций и аргументов.</description></item>
    ///   <item><description>Обрабатывает результаты и логирование.</description></item>
    ///   <item><description>Обеспечивает повторное выполнение процедур при ошибках.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public class Calculator
    {
        #region Field Description "Интерфейс для чтения пользовательского ввода"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="_reader"/> | Интерфейс для чтения пользовательского ввода.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное поле.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Поле типа <see cref="IReader"/>, которое:</para>
        /// <list type="number">
        ///   <item><description>Используется для получения пользовательского ввода.</description></item>
        ///   <item><description>Инициализируется через конструктор.</description></item>
        /// </list>
        /// </summary>
        #endregion
        private readonly IReader _reader; // Интерфейс для чтения пользовательского ввода

        #region Field Description "Интерфейс для вывода данных"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="_writer"/> | Интерфейс для вывода данных.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное поле.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Поле типа <see cref="IWriter"/>, которое:</para>
        /// <list type="number">
        ///   <item><description>Используется для вывода результатов, ошибок и сообщений.</description></item>
        ///   <item><description>Инициализируется через конструктор.</description></item>
        /// </list>
        /// </summary>
        #endregion
        private readonly IWriter _writer; // Интерфейс для вывода данных

        #region Field Description "Интерфейс для выбора процедур"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="_selector"/> | Интерфейс для выбора процедур.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное поле.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Поле типа <see cref="IOperationSelector"/>, которое:</para>
        /// <list type="number">
        ///   <item><description>Управляет выбором блоков, операций и аргументов.</description></item>
        ///   <item><description>Инициализируется через конструктор.</description></item>
        /// </list>
        /// </summary>
        #endregion
        private readonly IOperationSelector _selector; // Интерфейс для выбора процедур

        #region Field Description "Интерфейс для логирования"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="_logger"/> | Интерфейс для логирования.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное поле.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Поле типа <see cref="ILogger"/>, которое:</para>
        /// <list type="number">
        ///   <item><description>Используется для логирования событий и ошибок.</description></item>
        ///   <item><description>Инициализируется через конструктор.</description></item>
        /// </list>
        /// </summary>
        #endregion
        private readonly ILogger _logger; // Интерфейс для логирования

        #region Field Description "Счётчик итераций калькулятора"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="repeatNumber"/> | Счётчик итераций калькулятора.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное поле.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Поле типа <see cref="int"/>, которое:</para>
        /// <list type="number">
        ///   <item><description>Хранит номер текущей итерации работы калькулятора.</description></item>
        ///   <item><description>Инициализируется значением 1 и увеличивается при каждой новой итерации.</description></item>
        /// </list>
        /// </summary>
        #endregion
        private int repeatNumber = 1; // Счётчик итераций калькулятора

        #region Constructor Description "Конструктор класса"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para>Конструктор класса <see cref="Calculator"/>.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Конструктор.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Инициализирует экземпляр класса <see cref="Calculator"/>:</para>
        /// <list type="number">
        ///   <item><description>Принимает и сохраняет зависимости через интерфейсы.</description></item>
        ///   <item><description>Логирует успешное внедрение зависимостей.</description></item>
        /// </list>
        /// </summary>
        /// <param name="reader">Интерфейс для чтения пользовательского ввода типа <see cref="IReader"/>.</param>
        /// <param name="writer">Интерфейс для вывода данных типа <see cref="IWriter"/>.</param>
        /// <param name="selector">Интерфейс для выбора процедур типа <see cref="IOperationSelector"/>.</param>
        /// <param name="logger">Интерфейс для логирования типа <see cref="ILogger"/>.</param>
        #endregion
        public Calculator(
            IReader reader,
            IWriter writer,
            IOperationSelector selector,
            ILogger logger)
        {
            // Сохранение зависимостей
            _reader = reader;
            _writer = writer;
            _selector = selector;
            _logger = logger;
            // Логирование успешной инициализации
            _logger.Event(
                $"\n{nameof(Calculator)}",
                "Запуск конструктора: зависимости успешно внедрены");
        }

        #region Method Description "Основной цикл работы калькулятора"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Run"/> | Основной цикл работы калькулятора.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Публичный метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, выполняющий основной цикл работы калькулятора:</para>
        /// <list type="number">
        ///   <item><description>Инициализирует счётчик итераций.</description></item>
        ///   <item><description>Выполняет последовательные блоки процедур в цикле с управлением через <see cref="BlockKey"/>.</description></item>
        ///   <item><description>Обрабатывает исключения через метод <see cref="RetryProcedure{T}"/>.</description></item>
        /// </list>
        /// <para>Блоки процедур:</para>
        /// <list type="number">
        ///   <item><description>Выбор блока операций (<see cref="OperationBlock"/>).</description></item>
        ///   <item><description>Выбор операции (<see cref="IMathOperation"/>).</description></item>
        ///   <item><description>Вывод результатов прошлых итераций (<see cref="ResultOfPreviousIterations"/>).</description></item>
        ///   <item><description>Ввод аргументов (<see cref="double"/>[]).</description></item>
        ///   <item><description>Вычисление результата (<see cref="double"/>).</description></item>
        ///   <item><description>Сохранение результата (<see cref="string"/>).</description></item>
        ///   <item><description>Запрос на продолжение (<see cref="bool"/>).</description></item>
        /// </list>
        /// <para>Условия выхода:</para>
        /// <list type="bullet">
        ///   <item><description>Пользователь отказался продолжать работу.</description></item>
        ///   <item><description>Возникло необработанное исключение.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public void Run()
        {
            // Логирование начала работы цикла
            _logger.Event(nameof(Run), "Запуск главного while");
            // Вывод сообщения о запуске
            _writer.WriteMessage("Запуск Калькулятора");
            // Задержка для эффекта
            Thread.Sleep(1000);

            // Основной цикл калькулятора
            while (true)
            {
                // Инициализация переменных для текущей итерации
                BlockKey nextBlock = BlockKey.SelectBlock;
                OperationBlock block = default;
                IMathOperation operation = null;
                double[] args = null;
                double result = 0;
                string memory = null;

                // Внутренний цикл для обработки блоков
                while (nextBlock != BlockKey.Exit)
                {
                    switch (nextBlock)
                    {
                        // Блок 1: Выбор блока операций
                        case BlockKey.SelectBlock:
                            // Выполнение процедуры выбора блока
                            var (selectedBlock, blockNext) = RetryProcedure(
                                () => _selector.BlockSelection(),
                                nameof(_selector.BlockSelection),
                                "Выбор блока операций"
                            );
                            block = selectedBlock;
                            nextBlock = blockNext == BlockKey.ReturnToOperationSelection
                                ? BlockKey.SelectOperation
                                : BlockKey.SelectOperation;
                            break;

                        // Блок 2: Выбор операции
                        case BlockKey.SelectOperation:
                            // Выполнение процедуры выбора операции
                            var (op, opNext) = RetryProcedure(
                                () => _selector.OperationSelection(block),
                                nameof(_selector.OperationSelection),
                                "Выбор операции"
                            );
                            operation = op;
                            nextBlock = opNext == BlockKey.ReturnToOperationSelection
                                ? BlockKey.SelectOperation
                                : BlockKey.ShowPastResults;
                            break;

                        // Блок 3: Вывод прошлых результатов
                        case BlockKey.ShowPastResults:
                            // Проверка необходимости вывода результатов прошлых итераций
                            if (repeatNumber > 1)
                            {
                                ListingTheResultsOfPastIterations();
                            }
                            nextBlock = BlockKey.InputArguments;
                            break;

                        // Блок 4: Ввод аргументов
                        case BlockKey.InputArguments:
                            // Выполнение процедуры ввода аргументов
                            var (arg, argNext) = RetryProcedure(
                                () => _selector.ArgSelection(operation),
                                nameof(_selector.ArgSelection),
                                "Ввод аргументов"
                            );
                            args = arg;
                            nextBlock = argNext == BlockKey.ReturnToOperationSelection
                                ? BlockKey.SelectOperation
                                : BlockKey.CalculateResult;
                            break;

                        // Блок 5: Вычисление результата
                        case BlockKey.CalculateResult:
                            // Выполнение процедуры вычисления
                            var (res, resNext) = RetryProcedure(
                                () => _writer.CalculateAndDisplayResult(operation, args),
                                nameof(_writer.CalculateAndDisplayResult),
                                "Вычисление результата"
                            );
                            result = res;
                            nextBlock = resNext == BlockKey.ReturnToOperationSelection
                                ? BlockKey.SelectOperation
                                : BlockKey.SaveResult;
                            break;

                        // Блок 6: Работа с результатом
                        case BlockKey.SaveResult:
                            // Выполнение процедуры сохранения результата
                            var (mem, memNext) = RetryProcedure(
                                () => _selector.SavingTheResultSelection(result, ref repeatNumber),
                                nameof(_selector.SavingTheResultSelection),
                                "Сохранение результата"
                            );
                            memory = mem;
                            nextBlock = memNext == BlockKey.ReturnToOperationSelection
                                ? BlockKey.SelectOperation
                                : BlockKey.ContinuePrompt;
                            break;

                        // Блок 7: Запрос на продолжение
                        case BlockKey.ContinuePrompt:
                            // Выполнение процедуры запроса на продолжение
                            var (choosing, chooseNext) = RetryProcedure(
                                () => _selector.ShouldContinueSelection(memory),
                                nameof(_selector.ShouldContinueSelection),
                                "Запрос на продолжение"
                            );
                            if (choosing)
                            {
                                // Увеличение счётчика итераций
                                repeatNumber += 1;
                                // Логирование новой итерации
                                _logger.Event(nameof(Run), $"Итерация: №{repeatNumber}");
                                // Вывод сообщения о новой итерации
                                _writer.WriteMessage($"Итерация: №{repeatNumber}");
                                // Задержка для эффекта
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                // Выход из внешнего цикла
                                return;
                            }
                            nextBlock = chooseNext == BlockKey.ReturnToOperationSelection
                                ? BlockKey.SelectOperation
                                : choosing ? BlockKey.SelectBlock : BlockKey.Exit;
                            break;

                        // Повтор текущего блока
                        case BlockKey.RetryCurrent:
                            // Остаёмся на текущем блоке
                            break;

                        // Возврат к выбору операции
                        case BlockKey.ReturnToOperationSelection:
                            // Логирование возврата к выбору операции
                            _logger.Event(nameof(Run), "Возврат к выбору операции из-за незавершённой операции");
                            // Вывод сообщения о возврате
                            _writer.WriteMessage("Операция не завершена. Возврат к выбору операции...");
                            // Задержка для эффекта
                            Thread.Sleep(500);
                            nextBlock = BlockKey.SelectOperation;
                            break;
                    }
                }
            }
        }

        #region Method Description "Механизм повторного выполнения процедуры с обработкой исключений"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="RetryProcedure{T}"/> | Механизм повторного выполнения процедуры с обработкой исключений.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватный обобщённый метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, выполняющий процедуру с обработкой исключений и возвращающий кортеж результата и ключа:</para>
        /// <list type="number">
        ///   <item><description>Принимает делегат процедуры и её контекст.</description></item>
        ///   <item><description>Выполняет процедуру, обрабатывая ожидаемые исключения.</description></item>
        ///   <item><description>Возвращает результат и ключ для следующего блока или повторяет попытку.</description></item>
        /// </list>
        /// <para>Условия выхода:</para>
        /// <list type="bullet">
        ///   <item><description>Успешное выполнение процедуры.</description></item>
        ///   <item><description>Обработка <see cref="IncompleteOperationException"/> с возвратом к выбору операции.</description></item>
        ///   <item><description>Проброс необрабатываемого исключения.</description></item>
        /// </list>
        /// </summary>
        /// <typeparam name="T">Тип возвращаемого значения процедуры.</typeparam>
        /// <param name="basicProcedure">Делегат процедуры типа <see cref="Func{T}"/>.</param>
        /// <param name="procedureName">Название процедуры для логирования, тип <see cref="string"/>.</param>
        /// <param name="context">Контекст выполнения процедуры для логирования, тип <see cref="string"/>.</param>
        /// <returns>Кортеж из результата типа <typeparamref name="T"/> и ключа <see cref="BlockKey"/>.</returns>
        #endregion
        private (T result, BlockKey nextBlock) RetryProcedure<T>(
            Func<T> basicProcedure,
            string procedureName,
            string context)
        {
            // Цикл для повторных попыток выполнения процедуры
            while (true)
            {
                try
                {
                    // Выполнение процедуры
                    T result = basicProcedure();
                    // Успешное выполнение, возврат результата
                    return (result, BlockKey.RetryCurrent);
                }
                catch (BlockNotAvailableException ex)
                {
                    // Обработка исключения и повторная попытка
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                }
                catch (BlockNotFoundException ex)
                {
                    // Обработка исключения и повторная попытка
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                }
                catch (OperationNotAvailableException ex)
                {
                    // Обработка исключения и повторная попытка
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                }
                catch (InvalidArgumentsException ex)
                {
                    // Обработка исключения и повторная попытка
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                }
                catch (IncompleteOperationException ex)
                {
                    // Обработка исключения с возвратом к выбору операции
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                    return (default(T), BlockKey.ReturnToOperationSelection);
                }
                catch (FormatException ex)
                {
                    // Обработка исключения и повторная попытка
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                }
                catch (CalculationException ex)
                {
                    // Обработка исключения и повторная попытка
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                }
                catch (Exception ex)
                {
                    // Логирование и проброс критического исключения
                    _logger.Error($"Исключение: {ex.GetType().Name},\nГде: {procedureName}", ex.Message);
                    _writer.WriteError($"Критическая ошибка: {ex.Message}");
                    throw;
                }
            }
        }

        #region Method Description "Обработчик исключений"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="CommonConcentratorMoulderOfExceptions"/> | Обработчик исключений.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватный метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, выполняющий логирование и вывод сообщений об ошибках:</para>
        /// <list type="number">
        ///   <item><description>Принимает исключение, название процедуры и контекст.</description></item>
        ///   <item><description>Логирует информацию об ошибке через <see cref="_logger"/>.</description></item>
        ///   <item><description>Выводит сообщение об ошибке через <see cref="_writer"/>.</description></item>
        /// </list>
        /// </summary>
        /// <param name="ex">Исключение типа <see cref="Exception"/>.</param>
        /// <param name="procedureName">Название процедуры для логирования, тип <see cref="string"/>.</param>
        /// <param name="context">Контекст выполнения процедуры для логирования, тип <see cref="string"/>.</param>
        #endregion
        private void CommonConcentratorMoulderOfExceptions(
            Exception ex, 
            string procedureName, 
            string context)
        {
            // Логирование ошибки
            _logger.Error($"Исключение: {ex.GetType().Name},\nГде: {procedureName}", ex.Message);
            // Вывод сообщения об ошибке
            _writer.WriteError(ex.Message);
        }
    }
}