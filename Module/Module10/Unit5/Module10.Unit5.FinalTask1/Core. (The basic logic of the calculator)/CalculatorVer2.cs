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
    /// Основной класс калькулятора. Обрабатывает арифметические и другие операции,
    /// сгруппированные в блоки (OperationBlock).
    /// </summary>
    public class Calculator2
    {
        /// <summary>
        /// Поле-интерфейс для чтения ввода пользователя
        /// </summary>
        private readonly IReader _reader;

        /// <summary>
        /// Поле-интерфейс для вывода сообщений
        /// </summary>
        private readonly IWriter _writer;

        /// <summary>
        /// Поле-интерфейс для выбор операций и аргументов
        /// </summary>
        private readonly IOperationSelector _selector;

        /// <summary>
        /// Поле-интерфейс для логирования событий и ошибок
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Поле-счётчик итераций калькулятора
        /// </summary>
        private int repeatNumber = 0;

        /// <summary>
        /// Конструктор, инициализирующий калькулятор с необходимыми зависимостями
        /// </summary>
        public Calculator2(
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
                $"Запуск конструктора: зависимости успешно внедрены");
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

            // Бесконечный цикл (завершается через break или исключение)
            while (true)
            {
                repeatNumber += 1;
                _logger.Event(
                    $"\n" +
                    $"{nameof(Run)}",
                    $"Счётчик итерации: №{repeatNumber}");
                _writer.WriteMessage($"Итерация: №{repeatNumber}");
                Thread.Sleep(1000);

                /// <summary>
                /// --- Блок 1: Выбор блока операций (OperationBlock) ---
                /// </summary>
                OperationBlock block;
                _logger.Event(
                    $"\n" +
                    $"{nameof(Run)}",
                    $"Объявление {nameof(block)}");
                while (true)
                {
                    try
                    {
                        // Пользователь выбирает блок операций
                        block = _selector.BlockSelection(1);
                        break;
                    }
                    // Исключение о недоступности блока операций
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
                    // Исключение об отсутствии блока операций
                    catch (BlockNotFoundException ex)
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(BlockNotFoundException)},\n" +
                            $"Где: {nameof(_selector.BlockSelection)}",
                            ex.Message);
                        _writer.WriteError(ex.Message);
                        continue;
                    }
                    // Доп.: другие исключения
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

                /// <summary>
                /// --- Блок 2: Выбор операции ---
                /// </summary>
                IMathOperation operation;
                _logger.Event(
                    $"\n" +
                    $"{nameof(Run)}",
                    $"Объявление {nameof(operation)}");
                while (true)
                {
                    try
                    {
                        // Пользователь выбирает операцию
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
                    // Доп.: другие исключения
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

                /// <summary>
                /// --- Блок 3: Вывод прошлых результатов (если это не первая итерация) ---
                /// </summary>
                if (repeatNumber > 1)
                {
                    // Статический метод из ResultOfPreviousIterati
                    ListingTheResultsOfPastIterations();
                }

                /// <summary>
                /// --- Блок 4: Ввод аргументов, вычисление и вывод результата ---
                /// </summary>
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
                    // Обработка args
                    try
                    {
                        // Пользовательский ввод аргументов
                        args = _selector.ArgSelection(operation);
                    }
                    // Исключение при некорректных аргументах
                    catch (InvalidArgumentsException ex)
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(InvalidArgumentsException)},\n" +
                            $"Где: {nameof(_selector.ArgSelection)}",
                            ex.Message);
                        _writer.WriteError(ex.Message);
                        continue;
                    }
                    // Прочие ошибки парсинга чисел
                    catch (FormatException ex)
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(FormatException)},\n" +
                            $"Где: {nameof(_selector.ArgSelection)}",
                            ex.Message);
                        _writer.WriteError($"Некорректный формат числа: {ex.Message}");
                        continue;
                    }
                    // Доп.: другие исключения
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

                    // Обработка result
                    try
                    {
                        // Вычисление и вывод результата
                        result = _writer.CalculateAndDisplayResult(operation, args);
                        break;
                    }
                    // Исключение при вычислении
                    catch (CalculationException ex)
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(CalculationException)},\n" +
                            $"Где: {nameof(_writer.CalculateAndDisplayResult)}",
                            ex.Message);
                        _writer.WriteError(ex.Message);
                        continue;
                    }
                    // Доп.: другие исключения
                    catch (Exception ex)
                    {
                        _logger.Error(
                            $"\n" +
                            $"Исключение: {nameof(Exception)},\n" +
                            $"Где: {nameof(_writer.CalculateAndDisplayResult)}",
                            ex.Message);
                        _writer.WriteError($"Другая ошибка: {ex.Message}");
                        throw; // Пробрасываем выше, если это какое-то другое исключение
                        // Можно помтавить "continue;" - тогда будет возвращать к предыдущему
                        // шагу (при недоделанных операциях).
                    }
                }

                /// <summary>
                /// --- Блок 5: Сохранение результата и запрос на продолжение ---
                /// </summary>
                string memory;
                _logger.Event(
                    $"\n" +
                    $"{nameof(Run)}",
                    $"Объявление {nameof(memory)}");
                bool choosing;
                _logger.Event(
                    $"\n" +
                    $"{nameof(Run)}",
                    $"Объявление {nameof(choosing)}");
                while (true)
                {
                    // Обработка memory
                    try
                    {
                        memory = _selector.SavingTheResultSelection(result, ref repeatNumber);
                    }
                    // Исключение некорректного формата ввода
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
                    // Доп.: другие исключения
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

                    // Обработка choosing
                    try
                    {
                        choosing = _selector.ShouldContinueSelection(memory);
                        break;
                    }
                    // Доп.: другие исключения
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

                /// <summary>
                /// --- Блок 6: Выход из цикла, если пользователь отказался продолжать ---
                /// </summary>
                if (!choosing) break;
            }
        }
    }
}

