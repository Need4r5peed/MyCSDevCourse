using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Module10.Unit5.FinalTask1
{

    /// <summary>
    /// Основной класс калькулятора.
    /// Обрабатывает базовые арифметические и другие операции,
    /// сгруппированные в блоки (OperationBlock).
    /// </summary>
    public class Calculator
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private readonly IOperationSelector _selector;
        private readonly ILogger _logger;
        private readonly List<OperationBlock> _operationBlocks;
        private int repeatNumber = 0;
        private static ResultOfPreviousIterations resultsStorage = new ResultOfPreviousIterations();

        /// <summary>
        /// Конструктор, инициализирующий калькулятор с необходимыми зависимостями
        /// </summary>
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
            _operationBlocks = BlockRegistry.GetAvailableBlocks()
                .Select(blockName => BlockRegistry.Create(blockName))
                .ToList();
        }

        /// <summary>
        /// Основной цикл работы калькулятора
        /// </summary>
        public void Run()
        {
            _logger.Event("Loading", "Начало работы Калькулятора");
            Thread.Sleep(1000);
            _logger.Event("Loading", "Инициализация компонентов Калькулятора");
            Thread.Sleep(1000);

            while (true)
            {
                repeatNumber += 1;
                _logger.Event("Loading", $"Итерация №{repeatNumber}");
                Thread.Sleep(1000);

                var block = SelectOperationBlock();

                var operation = SelectOperation(block);

                if (repeatNumber > 1)
                {
                    resultsStorage.ListingTheResultsOfPastIterations(resultsStorage._storageByNumbers);
                }

                var args = GetArguments(operation);

                var result = CalculateResult(operation, args);

                DisplayResult(result);

                var memory = SavingTheResult(result, ref repeatNumber);

                if (!ShouldContinue(memory)) break;
            }
        }

        /// <summary>
        /// Основной цикл работы калькулятора
        /// </summary>
        /// <exception cref="FormatException">При неверном формате чисел</exception>
        /// <exception cref="KeyNotFoundException">При выборе несуществующей операции</exception>
        private OperationBlock SelectOperationBlock()
        {
            while (true)
            {
                try
                {
                    // Вывод списка доступных блоков
                    var availableBlockNames = _operationBlocks.Select(b => b.BlockName);
                    _logger.Event("Selection", "Загрузка блоков...");
                    Thread.Sleep(1000);
                    _writer.WriteMessage("Доступные блоки операций:");
                    _writer.WriteAvailableBlocks(availableBlockNames);

                    // Выбор пользователя через ввод названия блока в консоль
                    var blockName = _selector.SelectOperationBlock();
                    _logger.Event("Selection", $"Поиск блока: {blockName}");
                    Thread.Sleep(1000);

                    // Expertise!
                    BlockNotFoundExpertiseException.Expertise(blockName, _operationBlocks);

                    _logger.Event("Selection", $"Блок '{blockName}' найден. Выбор корректен.");
                    Thread.Sleep(1000);

                    // Возвращаем найденный блок
                    return _operationBlocks.First(b => b.BlockName.Equals(blockName));
                }
                catch (BlockNotAvailableException ex)
                {
                    _writer.WriteError(ex.Message);
                    _logger.Error("BlocksException", ex.Message);
                }
            }
        }

        private IMathOperation SelectOperation(OperationBlock block)
        {
            _logger.Event("Selection", $"Загрузка операций из блока '{block.BlockName}'");
            Thread.Sleep(1000);
            while (true)
            {
                try
                {
                    _writer.WriteMessage($"Доступные операции в блоке '{block.BlockName}':");
                    _writer.WriteAvailableOperations(block.Operations.Keys);

                    var operationName = _selector.SelectOperation(block.BlockName);
                    _logger.Event("SelectOperation", $"Поиск операции: {operationName}");
                    Thread.Sleep(1000);

                    // Expertise!
                    OperationNotFoundExpertiseException.Expertise(operationName, block);
                    _logger.Event("SelectOperation", $"Операция '{operationName}' доступна и готова к исполнению.");
                    Thread.Sleep(1000);

                    // Возвращает найденную операцию
                    return block.Operations[operationName];
                }
                // Исключение при отсутствии введённого названия операции
                catch (OperationNotAvailableException ex)
                {
                    _writer.WriteError(ex.Message);
                    _logger.Error("OperationsException", ex.Message);
                }
            }
        }

        private double[] GetArguments(IMathOperation operation)
        {
            _logger.Event("Сalculation", $"Подготовка памяти для ввода аргументов для выполнения '{operation.Name}'");
            Thread.Sleep(1000);
            while (true)
            {
                try
                {
                    _writer.WriteMessage($"Введите {operation.MinArgsCount}-{operation.MaxArgsCount} аргументов через пробел:");
                    var args = _reader.ReadNumbers();

                    // Expertise!
                    RequiredArgsCountExpertiseException.Expertise(args, operation);

                    return args;
                }
                catch (InvalidArgumentsException ex) // Наше кастомное исключение
                {
                    _writer.WriteError(ex.Message);
                    _logger.Error("ArgumentsException", ex.Message);
                }
                catch (FormatException ex) // Ошибки парсинга чисел
                {
                    _writer.WriteError($"Некорректный формат числа: {ex.Message}");
                    _logger.Error("ArgumentsFormat", ex.Message);
                }
                catch (Exception ex) // Другие непредвиденные ошибки
                {
                    _writer.WriteError($"Ошибка ввода: {ex.Message}");
                    _logger.Error("ArgumentsInput", ex.Message);
                    throw; // Пробрасываем выше, если это не ошибка ввода
                }
            }
        }

        private double CalculateResult(IMathOperation operation, double[] args)
        {
            try
            {
                _logger.Event("Calculation", $"Вычисление операции {operation.Name}");
                return operation.Calculate(args);
            }
            catch (Exception ex)
            {
                _logger.Error("Calculation", $"Ошибка вычисления: {ex.Message}");
                throw new CalculationException(args, $"Ошибка при вычислении: {ex.Message}");
            }
        }

        private void DisplayResult(double result)
        {
            _writer.WriteResult(result);
            _logger.Event("Display", $"Отображение результата: {result}");
        }

        private string SavingTheResult(double result, ref int counter)
        {
            _logger.Event("Сalculation", $"Выделение памяти для сохранения {result}");
            Thread.Sleep(1000);
            while (true)
            {
                try
                {
                    Console.WriteLine("1 - Сохранить, 2 - Очистить, 3 - Выход");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            resultsStorage.SavingTheResults(repeatNumber, result);
                            _logger.Event("Сalculation", $"Результат {result} итерации {repeatNumber} сохранен.");
                            return choice;
                        case "2":
                            resultsStorage.ClearingTheMemory();
                            _logger.Event("Сalculation", $"Все результаты стёрты из памяти.");
                            counter = 0;
                            return choice;
                        case "3":
                            return choice;
                    }
                }
                catch (FormatException ex) 
                {
                    _writer.WriteError($"Некорректный формат числа: {ex.Message}");
                    _logger.Error("MemoryException", ex.Message);
                }
            }
        }

        private bool ShouldContinue(string selectionOutput)
        {
            var response = selectionOutput;
            _logger.Event("Continue", $"Ответ пользователя: {response}");
            return response == "1" || response == "2";
        }
    }
}
