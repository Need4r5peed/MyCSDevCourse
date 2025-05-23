using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ResultOfPreviousIterations;

namespace Module10.Unit5.FinalTask1
{
    /// <summary>
    /// Реализация операций консольного выбора
    /// </summary>
    public class ConsoleSelection : IOperationSelector
    {
        private readonly IWriter _writer;

        private readonly IReader _reader;

        private readonly ILogger _logger;

        public ConsoleSelection(IWriter writer, IReader reader, ILogger logger)
        {
            _writer = writer;

            _reader = reader;

            _logger = logger;
        }

        public string BlockSelection()
        {
            _writer.WriteMessage("Выберите и введите название блока операций в консоль:");

            return _reader.ReadBlockChoice();
        }

        /// <summary>
        /// Доработанный метод по выбору блока, готовый попасть в интерфейс.
        /// </summary>
        /// <param name="operationBlocks"></param>
        /// <returns></returns>
        public OperationBlock BlockSelection(int i)
        {
            // Вывод списка доступных блоков
            _logger.Event($"{nameof(BlockSelection)}", "Загрузка блоков.");
            var availableBlockNames = BlockRegistry.GetAvailableBlocks();
            Thread.Sleep(1000);

            _logger.Event($"{nameof(BlockSelection)}", "Вывод доступных блоков.");
            Thread.Sleep(1000);
            _writer.WriteMessage("Доступные блоки операций:");
            _writer.WriteAvailableBlocks(availableBlockNames);

            // Выбор пользователя через ввод названия блока в консоль
            _logger.Event($"{nameof(BlockSelection)}", "Пользовательский ввод по выбору блока.");
            Thread.Sleep(1000);

            _writer.WriteMessage("Выберите и введите название блока операций в консоль:");
            var blockNameСhoice = _reader.ReadBlockChoice();

            _logger.Event($"{nameof(BlockSelection)}", $"Поиск блока: {blockNameСhoice}");
            Thread.Sleep(1000);

            // Expertise!
            _logger.Event($"{nameof(BlockSelection)}", $"Поиск исключений для {blockNameСhoice}");
            Thread.Sleep(1000);

            BlockNotFoundExpertiseException.Expertise(blockNameСhoice, BlockRegistry._blockRegistry);

            _logger.Event($"{nameof(BlockSelection)}", $"Блок '{blockNameСhoice}' найден. Выбор корректен.");
            Thread.Sleep(1000);

            // Возвращаем найденный блок
            _logger.Event($"{nameof(BlockSelection)}", $"Возвращение блока '{blockNameСhoice}'.");
            Thread.Sleep(1000);

            return BlockRegistry.GetOrCreate(blockNameСhoice);
        }

        public string OperationSelection(string blockName)
        {
            _writer.WriteMessage($"Выберите в введите название операции из блока '{blockName}':");
            return _reader.ReadOperationChoice();
        }

        public IMathOperation OperationSelection(OperationBlock block)
        {
            // 1.
            _logger.Event($"{nameof(OperationSelection)}", "Вывод доступных операций.");
            Thread.Sleep(1000);
            _writer.WriteMessage($"Доступные операции в блоке '{block.BlockName}':");
            _writer.WriteAvailableOperations(block.Operations.Keys);

            // 2.
            _logger.Event($"{nameof(OperationSelection)}", "Пользовательский ввод по выбору операции.");
            Thread.Sleep(1000);
            _writer.WriteMessage($"Выберите в введите название операции из блока '{block.BlockName}':");
            var operationUsersChoice = _reader.ReadOperationChoice();
            _logger.Event("SelectOperation", $"Поиск операции: {operationUsersChoice}");
            Thread.Sleep(1000);

            // 3. Expertise!
            _logger.Event($"{nameof(OperationSelection)}", $"Поиск исключений для {operationUsersChoice}.");
            Thread.Sleep(1000);
            OperationNotFoundExpertiseException.Expertise(operationUsersChoice, block);
            _logger.Event("SelectOperation", $"Операция '{operationUsersChoice}' доступна и готова к исполнению.");
            Thread.Sleep(1000);

            _logger.Event($"{nameof(OperationSelection)}", $"Загрузка операции {operationUsersChoice} в память.");
            Thread.Sleep(1000);
            // 4. Возвращает найденную операцию
            return block.Operations[operationUsersChoice];
        }

        public double[] ArgSelection(IMathOperation operation)
        {
            string FormatArgs(object a) => a is double[] array ? $"[{string.Join(", ", array)}]" : a.ToString();

            _logger.Event($"{nameof(ArgSelection)}", $"Ввод пользлвателем аргументов.");
            Thread.Sleep(1000);
            _writer.WriteMessage($"Введите {operation.MinArgsCount}-{operation.MaxArgsCount} аргументов через пробел:");
            var args = _reader.ReadNumbers();

            // Expertise!
            _logger.Event($"{nameof(ArgSelection)}", $"Поиск исключений для {FormatArgs(args)}.");
            Thread.Sleep(1000);

            RequiredArgsCountExpertiseException.Expertise(args, operation);

            _logger.Event($"{nameof(ArgSelection)}", $"Аргументы {FormatArgs(args)} готовы к использованию.");
            Thread.Sleep(1000);

            return args;
        }

        private string SavingTheResultSelection(int repeatNumber, double result, ref int counter)
        {
            _logger.Event($"{nameof(SavingTheResultSelection)}", $"Вывод списка дальнейших действий с результатом {result}.");
            Thread.Sleep(1000);

            _writer.WriteMessage(
                $"1 - Сохранить результат {result} данной итерации №{counter},\n" +
                $"2 - Не сохранять результат {result} данной итерации №{counter}, но сохранить результат предыдущих итераций\n" +
                $"3 - Очистить результаты всех итераций (в том числе результат {result} данной итерации №{counter}),\n" +
                $"4 - Очистить результаты всех предыдущих итераций и сохранить результат {result} данной итерации №{counter},\n" +
                $"5 - Выход из Калькулятора");

            _logger.Event($"{nameof(SavingTheResultSelection)}", $"Выбор пользователя о дальнейшем действии с результатом {result}.");
            Thread.Sleep(1000);
            string choice = _reader.ReadChoice();

            switch (choice)
            {
                case "1":
                    SavingTheResults(repeatNumber, result);
                    _logger.Event($"{nameof(SavingTheResultSelection)}",
                        $"Результат {result} данной итерации №{counter} сохранен в память {nameof(ResultOfPreviousIterations)}.\n" +
                        $"Номер данной итерации №{counter} не изменён\n" +
                        $"Счётчик итераций {nameof(counter)} = {counter} / не сброшен.\n" +
                        $"Программа калькулятора переходит к следующей итерации №{repeatNumber + 1}");
                    return choice;
                case "2":
                    _logger.Event($"{nameof(SavingTheResultSelection)}",
                        $"Результат {result} данной итерации №{counter} не сохранен в память {nameof(ResultOfPreviousIterations)}.\n" +
                        $"Номер данной итерации №{counter} изменён на №{counter -= 1}\n" +
                        $"Счётчик итераций {nameof(counter)} = {counter} / сброшен на 1 итерацию.\n" +
                        $"Программа калькулятора переходит к новой итерации №{0}");
                    return choice;
                case "3":
                    ClearingTheMemory();
                    _logger.Event($"{nameof(SavingTheResultSelection)}",
                        $"Все результаты прошлых итераций, в том чесле результат {result} данной итерации №{counter} - \n" +
                        $"были очищены из памяти {nameof(ResultOfPreviousIterations)}.\n" +
                        $"Номер данной итерации №{counter} изменён на №{counter = 0}\n" +
                        $"Счётчик итераций {nameof(counter)} = {counter} / сброшен на 0.\n" +
                        $"Программа калькулятора переходит к новой итерации №{0}");
                    counter = 0;
                    return choice;
                case "4":
                    ClearingTheMemory();
                    SavingTheResults(repeatNumber, result);
                    _logger.Event($"{nameof(SavingTheResultSelection)}",
                        $"Все результаты прошлых итераций были очищены из памяти {nameof(ResultOfPreviousIterations)}.\n" +
                        $"Результат {result} данной итерации №{counter} сохранен в память {nameof(ResultOfPreviousIterations)}." +
                        $"Номер данной итерации №{counter} изменён на №{counter = 1}\n" +
                        $"Счётчик итераций {nameof(counter)} = {counter} / сброшен на 1.\n" +
                        $"Программа калькулятора переходит к новой итерации №{0}");
                    return choice;
                case "5":
                    _logger.Event($"{nameof(SavingTheResultSelection)}",
                        $"Результат {result} итерации №{counter} не будет сохранен в память {nameof(ResultOfPreviousIterations)}.\n" +
                        $"Все результаты прошлых итераций будут очищены из пямяти {nameof(ResultOfPreviousIterations)}.\n" +
                        $"Программа Калькулятора будет завершена.");
                    return choice;
                default:
                    throw new FormatException();
            }
        }

        private bool ShouldContinueSelection(string selectionOutput)
        {
            var response = selectionOutput;
            _logger.Event("Continue", $"Ответ пользователя: {response}");
            return response == "1" || response == "2" || response == "3" || response == "4";
        }

        public bool AskForContinue()
        {
            _writer.WriteMessage("Продолжить? (y/n)");
            return Console.ReadLine().ToLower() == "y";
        }
    }
}
