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
    public enum BlockKey
    {
        SelectBlock,               // Блок 1: Выбор блока операций
        SelectOperation,           // Блок 2: Выбор операции
        ShowPastResults,           // Блок 3: Вывод прошлых результатов
        InputArguments,            // Блок 4: Ввод аргументов
        CalculateResult,           // Блок 5: Вычисление результата
        SaveResult,                // Блок 6: Работа с результатом
        ContinuePrompt,            // Блок 7: Запрос на продолжение
        Exit,                      // Выход из цикла
        RetryCurrent,              // Повтор текущего блока
        ReturnToOperationSelection // Возврат к блоку 2 при IncompleteOperationException
    }

    public class Calculator
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private readonly IOperationSelector _selector;
        private readonly ILogger _logger;
        private int repeatNumber = 1;

        public Calculator(
            IReader reader,
            IWriter writer,
            IOperationSelector selector,
            ILogger logger)
        {
            _reader = reader;
            _writer = writer;
            _selector = selector;
            _logger = logger;
            _logger.Event(
                $"\n{nameof(Calculator)}",
                "Запуск конструктора: зависимости успешно внедрены");
        }

        /// <summary>
        /// Название элемента: <see cref="Run"/> | 
        /// "Основной цикл работы калькулятора".
        /// Тип элемента: метод.
        /// 
        /// <para>● Концепция, описание, принцип работы элемента:</para>
        /// <para>Метод невозвращающего типа, который выполняет:</para> 
        /// <para><c>1)</c> инициализацию счётчика итераций;</para>
        /// <para><c>2)</c> последовательное выполнение блоков основных процедур в бесконечном цикле с управлением через ключи;</para>
        /// <para><c>3)</c> обработку исключений через <see cref="RetryProcedure{T}"/>.</para>
        /// 
        /// <para>● Блоки основных процедур элемента:</para>
        /// <para><c>— Блок #1</c> — Выбор блока математических операций (<see cref="OperationBlock"/>).</para>
        /// <para><c>— Блок #2</c> — Выбор конкретной математической операции (<see cref="IMathOperation"/>).</para>
        /// <para><c>— Блок #3</c> — Вывод результатов прошлых итераций (<see cref="ResultOfPreviousIterations"/>).</para>  
        /// <para><c>— Блок #4</c> — Ввод аргументов (<see cref="double[]"/>).</para> 
        /// <para><c>— Блок #5</c> — Вычисление результата (<see cref="double"/>).</para> 
        /// <para><c>— Блок #6</c> — Работа с результатом (<see cref="string"/>).</para> 
        /// <para><c>— Блок #7</c> — Запрос на продолжение и увеличение счётчика итераций (<see cref="bool"/>).</para> 
        /// 
        /// <para>● Условия выхода элемента:</para>
        /// <para><c>—</c> Пользователь отказался продолжать (<c>choosing == false</c>).</para>
        /// <para><c>—</c> Необработанное исключение (пробрасывается выше).</para>
        /// </summary>
        public void Run()
        {
            _logger.Event(nameof(Run), "Запуск главного while");
            _writer.WriteMessage("Запуск Калькулятора");
            Thread.Sleep(1000);

            while (true)
            {
                BlockKey nextBlock = BlockKey.SelectBlock;
                OperationBlock block = default;
                IMathOperation operation = null;
                double[] args = null;
                double result = 0;
                string memory = null;

                while (nextBlock != BlockKey.Exit)
                {
                    switch (nextBlock)
                    {
                        // Блок 1: Выбор блока операций
                        case BlockKey.SelectBlock:
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
                            if (repeatNumber > 1)
                            {
                                ListingTheResultsOfPastIterations();
                            }
                            nextBlock = BlockKey.InputArguments;
                            break;

                        // Блок 4: Ввод аргументов
                        case BlockKey.InputArguments:
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
                            var (choosing, chooseNext) = RetryProcedure(
                                () => _selector.ShouldContinueSelection(memory),
                                nameof(_selector.ShouldContinueSelection),
                                "Запрос на продолжение"
                            );
                            if (choosing)
                            {
                                repeatNumber += 1;
                                _logger.Event(nameof(Run), $"Итерация: №{repeatNumber}");
                                _writer.WriteMessage($"Итерация: №{repeatNumber}");
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                return; // Выход из внешнего цикла
                            }
                            nextBlock = chooseNext == BlockKey.ReturnToOperationSelection
                                ? BlockKey.SelectOperation
                                : choosing ? BlockKey.SelectBlock : BlockKey.Exit;
                            break;

                        // Повтор текущего блока
                        case BlockKey.RetryCurrent:
                            // Остаёмся на текущем блоке
                            break;

                        // Возврат к блоку 2 при IncompleteOperationException
                        case BlockKey.ReturnToOperationSelection:
                            _logger.Event(nameof(Run), "Возврат к выбору операции из-за незавершённой операции");
                            _writer.WriteMessage("Операция не завершена. Возврат к выбору операции...");
                            Thread.Sleep(500);
                            nextBlock = BlockKey.SelectOperation;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Название элемента: <see cref="RetryProcedure"/> | 
        /// "Механизм повторного выполнения основной процедуры с обработкой исключений".
        /// Тип элемента: метод.
        /// 
        /// <para>● Концепция, описание, принцип работы элемента:</para>
        /// <para>Обобщённый (generic) метод, возвращающий кортеж результата и ключа следующего блока, который выполняет:</para> 
        /// <para><c>1)</c> приём обобщённого и основных параметров;</para>
        /// <para><c>2)</c> базовую процедуру;</para>
        /// <para><c>3)</c> если возникает ожидаемое исключение (кроме IncompleteOperationException): логирование и повторная попытка;</para>
        /// <para><c>4)</c> если возникает IncompleteOperationException: логирование и возврат ключа для перехода к выбору операции;</para>
        /// <para><c>5)</c> если возникает критическое исключение: логирование и проброс выше;</para> 
        /// <para><c>6)</c> при успешном выполнении базовой процедуры: возврат результата и ключа для продолжения.</para>
        /// 
        /// <para>● Составляющие элемента:</para>
        /// <para><c>— RetryProcedure</c> — название метода.</para>
        /// <para><c>— T</c> — тип возвращаемых данных.</para>
        /// <para><c>— <T></c> — обобщённый параметр типа T.</para>  
        /// <para><c>— Func<T> basicProcedure</c> — 1-й параметр, делегат "Выполняемая основная процедура", возвращающий данные типа T.</para> 
        /// <para><c>— string procedureName</c> — 2-й параметр "Название основной процедуры" строкового типа string.</para> 
        /// <para><c>— string context</c> — 3-й параметр "Контекст выполнения основной процедуры" строкового типа string.</para>  
        /// 
        /// <para>● Условия выхода элемента:</para>
        /// <para><c>—</c> Успешное выполнение операции с возвратом результата и ключа.</para>
        /// <para><c>—</c> IncompleteOperationException с возвратом ключа для перехода к выбору операции.</para>
        /// <para><c>—</c> Необрабатываемое исключение (пробрасывается выше).</para>
        /// </summary>
        /// 
        /// <typeparam name="T">Тип возвращаемого значения базовой процедуры.</typeparam>
        /// <param name="basicProcedure">Основная процедура для выполнения.</param>
        /// <param name="procedureName">Название базовой процедуры | Логирование.</param>
        /// <param name="context">Дополнительный контекст выполнения базовой процедуры | Логирование.</param>
        /// 
        /// <returns>Кортеж из результата выполнения процедуры типа T и ключа следующего блока.</returns>
        private (T result, BlockKey nextBlock) RetryProcedure<T>(
            Func<T> basicProcedure,
            string procedureName,
            string context)
        {
            while (true)
            {
                try
                {
                    T result = basicProcedure();
                    return (result, BlockKey.RetryCurrent);
                }
                catch (BlockNotAvailableException ex)
                {
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                    // Повторная попытка текущего блока
                }
                catch (BlockNotFoundException ex)
                {
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                    // Повторная попытка текущего блока
                }
                catch (OperationNotAvailableException ex)
                {
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                    // Повторная попытка текущего блока
                }
                catch (InvalidArgumentsException ex)
                {
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                    // Повторная попытка текущего блока
                }
                catch (IncompleteOperationException ex)
                {
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                    return (default(T), BlockKey.ReturnToOperationSelection);
                }
                catch (FormatException ex)
                {
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                    // Повторная попытка текущего блока
                }
                catch (CalculationException ex)
                {
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                    // Повторная попытка текущего блока
                }
                catch (Exception ex)
                {
                    _logger.Error($"Исключение: {ex.GetType().Name},\nГде: {procedureName}", ex.Message);
                    _writer.WriteError($"Критическая ошибка: {ex.Message}");
                    throw;
                }
            }
        }

        private void CommonConcentratorMoulderOfExceptions(Exception ex, string procedureName, string context)
        {
            _logger.Error($"Исключение: {ex.GetType().Name},\nГде: {procedureName}", ex.Message);
            _writer.WriteError(ex.Message);
        }
    }
}