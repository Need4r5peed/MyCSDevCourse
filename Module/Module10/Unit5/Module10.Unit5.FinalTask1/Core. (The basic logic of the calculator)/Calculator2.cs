using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static Module10.Unit5.FinalTask1.ResultOfPreviousIterations;

namespace Module10.Unit5.FinalTask1
{

    /// <summary>
    /// Основной класс калькулятора. Версия 2
    /// Обрабатывает базовые арифметические и другие операции,
    /// сгруппированные в блоки (OperationBlock).
    /// </summary>
    public class Calculator
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private readonly IOperationSelector _selector;
        private readonly ILogger _logger;
        private int repeatNumber = 0;

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
            _logger.Event(
                $"\n" +
                $"{nameof(Calculator)}",
                $"Запуск конструктора");
        }

        /// <summary>
        /// Основной цикл работы калькулятора
        /// </summary>
        public void Run()
        {
            _logger.Event(
                $"\n" +
                $"{nameof(Run)}",
                $"Запуск главного while");
            _writer.WriteMessage($"Запуск Калькулятора");
            Thread.Sleep(1000);

            while (true)
            {
                repeatNumber += 1;
                _logger.Event(
                    $"\n" +
                    $"{nameof(Run)}",
                    $"Счётчик итерации: №{repeatNumber}");
                _writer.WriteMessage($"Итерация: №{repeatNumber}");
                Thread.Sleep(1000);

                OperationBlock block;
                _logger.Event(
                    $"\n" +
                    $"{nameof(Run)}",
                    $"Объявление {nameof(block)}");
                while (true)
                {
                    try
                    {
                        block = _selector.BlockSelection(1);
                        break;
                    }
                    catch (BlockNotAvailableException ex)
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(BlockNotAvailableException)},\n" +
                            $"Где: {nameof(_selector.BlockSelection)}", 
                            ex.Message);
                        _writer.WriteError(ex.Message);
                    }
                    catch (BlockNotFoundException ex)
                    {
                        // Обработка ошибки отсутствия блока операций
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(BlockNotFoundException)},\n" +
                            $"Где: {nameof(_selector.BlockSelection)}",
                            ex.Message);
                        _writer.WriteError(ex.Message);
                    }
                    // Доп.: другие непредвиденные ошибки
                    catch (Exception ex)
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(Exception)},\n" +
                            $"Где: {nameof(_selector.BlockSelection)}",
                            ex.Message);
                        _writer.WriteError($"Другая ошибка: {ex.Message}");
                        throw; // Пробрасываем выше, если это какое-то другое исключение
                    }
                }

                IMathOperation operation;
                _logger.Event(
                    $"\n" +
                    $"{nameof(Run)}",
                    $"Объявление {nameof(operation)}");
                while (true)
                {
                    try
                    {
                        operation = _selector.OperationSelection(block);
                        break;
                    }
                    // Исключение при отсутствии введённого названия операции
                    catch (OperationNotAvailableException ex)
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(OperationNotAvailableException)},\n" +
                            $"Где: {nameof(_selector.OperationSelection)}",
                            ex.Message);
                        _writer.WriteError(ex.Message);
                    }
                    // Доп.: другие непредвиденные ошибки
                    catch (Exception ex)
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(Exception)},\n" +
                            $"Где: {nameof(_selector.OperationSelection)}",
                            ex.Message);
                        _writer.WriteError($"Другая ошибка: {ex.Message}");
                        throw; // Пробрасываем выше, если это какое-то другое исключение
                    }
                }

                if (repeatNumber > 1)
                {
                    ListingTheResultsOfPastIterations();
                }

                double[] args;
                _logger.Event(
                    $"\n" +
                    $"{nameof(Run)}",
                    $"Объявление {nameof(args)}");
                while (true)
                {
                    try
                    {
                        args = _selector.ArgSelection(operation);
                        break;
                    }
                    catch (InvalidArgumentsException ex) // Наше кастомное исключение
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(InvalidArgumentsException)},\n" +
                            $"Где: {nameof(_selector.ArgSelection)}",
                            ex.Message);
                        _writer.WriteError(ex.Message);
                    }
                    catch (FormatException ex) // Ошибки парсинга чисел
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(FormatException)},\n" +
                            $"Где: {nameof(_selector.ArgSelection)}",
                            ex.Message);
                        _writer.WriteError($"Некорректный формат числа: {ex.Message}");
                    }
                    // Доп.: другие непредвиденные ошибки
                    catch (Exception ex)
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(Exception)},\n" +
                            $"Где: {nameof(_selector.ArgSelection)}",
                            ex.Message);
                        _writer.WriteError($"Другая ошибка: {ex.Message}");
                        throw; // Пробрасываем выше, если это какое-то другое исключение
                    }
                }

                //Объединение с предыдущим!!!!!

                double result;
                _logger.Event(
                    $"\n" +
                    $"{nameof(Run)}",
                    $"Объявление {nameof(result)}");
                while (true)
                {
                    try
                    {
                        result = _writer.CalculateAndDisplayResult(operation, args);
                        break;
                    }
                    catch (CalculationException ex) // Наше кастомное исключение
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(CalculationException)},\n" +
                            $"Где: {nameof(_writer.CalculateAndDisplayResult)}",
                            ex.Message);
                        _writer.WriteError(ex.Message);
                        throw new CalculationException(args, $"Ошибка при вычислении: {ex.Message}");
                    }
                    // Доп.: другие непредвиденные ошибки
                    catch (Exception ex)
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(Exception)},\n" +
                            $"Где: {nameof(_writer.CalculateAndDisplayResult)}",
                            ex.Message);
                        _writer.WriteError($"Другая ошибка: {ex.Message}");
                        throw; // Пробрасываем выше, если это какое-то другое исключение
                    }
                }

                DisplayResult(result);

                var memory = SavingTheResult(result, ref repeatNumber);

                if (!ShouldContinue(memory)) break;
            }
        }

        ///// <summary>
        ///// Основной цикл работы калькулятора
        ///// </summary>
        ///// <exception cref="FormatException">При неверном формате чисел</exception>
        ///// <exception cref="KeyNotFoundException">При выборе несуществующей операции</exception>
        //private OperationBlock BlockSelection()
        //{
        //    // Вывод списка доступных блоков
        //    var availableBlockNames = BlockRegistry.GetAvailableBlocks();
        //    _logger.Event("Selection", "Загрузка блоков...");
        //    Thread.Sleep(1000);
        //    _writer.WriteMessage("Доступные блоки операций:");
        //    _writer.WriteAvailableBlocks(availableBlockNames);

        //    // Выбор пользователя через ввод названия блока в консоль
        //    var blockName = _selector.BlockSelection();
        //    _logger.Event("Selection", $"Поиск блока: {blockName}");
        //    Thread.Sleep(1000);

        //    // Expertise!
        //    BlockNotFoundExpertiseException.Expertise(blockName, BlockRegistry._blockRegistry);

        //    _logger.Event("Selection", $"Блок '{blockName}' найден. Выбор корректен.");
        //    Thread.Sleep(1000);

        //    // Возвращаем найденный блок
        //    return BlockRegistry.GetOrCreate(blockName);
        //}

        //private IMathOperation OperationSelection(OperationBlock block)
        //{

        //    // 1.
        //    _logger.Event($"{nameof(OperationSelection)}", "Вывод доступных операций.");
        //    Thread.Sleep(1000);
        //    _writer.WriteMessage($"Доступные операции в блоке '{block.BlockName}':");
        //    _writer.WriteAvailableOperations(block.Operations.Keys);

        //    // 2.
        //    _logger.Event($"{nameof(OperationSelection)}", "Пользовательский ввод по выбору операции.");
        //    Thread.Sleep(1000);
        //    _writer.WriteMessage($"Выберите в введите название операции из блока '{block.BlockName}':");
        //    var operationUsersChoice = _reader.ReadOperationChoice();
        //    _logger.Event("SelectOperation", $"Поиск операции: {operationUsersChoice}");
        //    Thread.Sleep(1000);

        //    // 3. Expertise!
        //    _logger.Event($"{nameof(OperationSelection)}", $"Поиск исключений для {operationUsersChoice}.");
        //    Thread.Sleep(1000);
        //    OperationNotFoundExpertiseException.Expertise(operationUsersChoice, block);
        //    _logger.Event("SelectOperation", $"Операция '{operationUsersChoice}' доступна и готова к исполнению.");
        //    Thread.Sleep(1000);

        //    // 4. Возвращает найденную операцию
        //    return block.Operations[operationUsersChoice];
        //}

        //private double[] GetArguments(IMathOperation operation)
        //{
        //    _writer.WriteMessage($"Введите {operation.MinArgsCount}-{operation.MaxArgsCount} аргументов через пробел:");
        //    var args = _reader.ReadNumbers();

        //    // Expertise!
        //    RequiredArgsCountExpertiseException.Expertise(args, operation);

        //    return args;
        //}

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
                            SavingTheResults(repeatNumber, result);
                            _logger.Event("Сalculation", $"Результат {result} итерации {counter} сохранен.");
                            return choice;
                        case "2":
                            ClearingTheMemory();
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

