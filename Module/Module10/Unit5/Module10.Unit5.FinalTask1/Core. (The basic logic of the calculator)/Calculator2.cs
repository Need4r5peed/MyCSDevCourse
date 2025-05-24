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
                        continue;
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
                        continue;
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
                        continue;
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
                double result;
                _logger.Event(
                    $"\n" +
                    $"{nameof(Run)}",
                    $"Объявление {nameof(result)}");
                while (true)
                {
                    try
                    {
                        args = _selector.ArgSelection(operation);
                    }
                    catch (InvalidArgumentsException ex) // Наше кастомное исключение
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(InvalidArgumentsException)},\n" +
                            $"Где: {nameof(_selector.ArgSelection)}",
                            ex.Message);
                        _writer.WriteError(ex.Message);
                        continue;
                    }
                    catch (FormatException ex) // Ошибки парсинга чисел
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(FormatException)},\n" +
                            $"Где: {nameof(_selector.ArgSelection)}",
                            ex.Message);
                        _writer.WriteError($"Некорректный формат числа: {ex.Message}");
                        continue;
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
                        continue;
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

                ////Объединение с предыдущим!!!!!

                //double result;
                //_logger.Event(
                //    $"\n" +
                //    $"{nameof(Run)}",
                //    $"Объявление {nameof(result)}");
                //while (true)
                //{
                //    try
                //    {
                //        result = _writer.CalculateAndDisplayResult(operation, args);
                //        break;
                //    }
                //    catch (CalculationException ex) // Наше кастомное исключение
                //    {
                //        _logger.Error(
                //            $"\n" +
                //            $"Исключение: {nameof(CalculationException)},\n" +
                //            $"Где: {nameof(_writer.CalculateAndDisplayResult)}",
                //            ex.Message);
                //        _writer.WriteError(ex.Message);
                //    }
                //    // Доп.: другие непредвиденные ошибки
                //    catch (Exception ex)
                //    {
                //        _logger.Error(
                //            $"\n" +
                //            $"Исключение: {nameof(Exception)},\n" +
                //            $"Где: {nameof(_writer.CalculateAndDisplayResult)}",
                //            ex.Message);
                //        _writer.WriteError($"Другая ошибка: {ex.Message}");
                //        throw; // Пробрасываем выше, если это какое-то другое исключение
                //    }
                //}

                //DisplayResult(result);

                string memory;
                bool choosing;
                while (true)
                {
                    try
                    {
                        memory = _selector.SavingTheResultSelection(result, ref repeatNumber);
                    }
                    catch (FormatException ex)
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(FormatException)},\n" +
                            $"Где: {nameof(_writer.CalculateAndDisplayResult)}",
                            ex.Message);
                        _writer.WriteError($"Некорректный формат числа: {ex.Message}");
                        continue;
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

                    try
                    {
                        choosing = _selector.ShouldContinueSelection(memory);
                        break;
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

                if (!choosing) break;
            }
        }
    }
}

