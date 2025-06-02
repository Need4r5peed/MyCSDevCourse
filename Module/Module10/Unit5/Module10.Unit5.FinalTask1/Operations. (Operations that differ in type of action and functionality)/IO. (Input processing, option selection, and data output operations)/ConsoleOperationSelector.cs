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
    /// Реализация операций консольного выбора процедур калькулятора
    /// </summary>
    public class ConsoleSelection : IOperationSelector
    {

        /// <summary>
        /// 
        /// <para><b>● Название элемента:</b></para>
        /// <para><see cref="_writer"/> | Реализация интерфейса для вывода данных.</para>
        /// 
        /// <para><b>● Тип элемента:</b></para>
        /// <para>Приватное(<see langword="private"/>) поле только для чтения(<see langword="readonly"/>).</para>
        /// 
        /// <para><b>● Описание:</b></para>
        /// <para>Содержит экземпляр класса, реализующего интерфейс <see cref="IWriter"/> для организации вывода данных.</para>
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <para><b>● Дополнение:</b></para>
        /// <list type="">
        ///    <item><description>Инициализируется через внедрение зависимости в конструкторе.</description></item>
        /// </list> 
        /// </remarks>
        private readonly IWriter _writer;

        /// <summary>
        /// 
        /// <para><b>● Название элемента:</b></para>
        /// <para><see cref="_reader"/> | Реализация интерфейса для чтения данных.</para>
        /// 
        /// <para><b>● Тип элемента:</b></para>
        /// <para>Приватное(<see langword="private"/>) поле только для чтения(<see langword="readonly"/>).</para>
        /// 
        /// <para><b>● Описание:</b></para>
        /// <para>Содержит экземпляр класса, реализующего интерфейс <see cref="IReader"/> для организации чтения данных.</para>
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <para><b>● Дополнение:</b></para>
        /// <list type="">
        ///    <item><description>Инициализируется через внедрение зависимости в конструкторе.</description></item>
        /// </list> 
        /// </remarks>
        private readonly IReader _reader;

        /// <summary>
        /// 
        /// <para><b>● Название элемента:</b></para>
        /// <para><see cref="_logger"/> | Реализация интерфейса для логирования событий.</para>
        /// 
        /// <para><b>● Тип элемента:</b></para>
        /// <para>Приватное(<see langword="private"/>) поле только для чтения(<see langword="readonly"/>).</para>
        /// 
        /// <para><b>● Описание:</b></para>
        /// <para>Содержит экземпляр класса, реализующего интерфейс <see cref="ILogger"/> для организации логирования событий.</para>
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <para><b>● Дополнение:</b></para>
        /// <list type="">
        ///    <item><description>Инициализируется через внедрение зависимости в конструкторе.</description></item>
        /// </list> 
        /// </remarks>
        private readonly ILogger _logger;

        /// <summary>
        /// Конструктор, инициализирующий поля через внедрение зависимостей.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="reader"></param>
        /// <param name="logger"></param>
        public ConsoleSelection(IWriter writer, IReader reader, ILogger logger)
        {
            _writer = writer;

            _reader = reader;

            _logger = logger;
        }

        /// <summary>
        /// <para>● Название элеиента:</para>
        /// <para><see cref="BlockSelection"/> |
        /// "Выбор блока математических операций".</para>
        /// 
        /// <para>● Тип элемента:</para> 
        /// <para>контракт метода.</para>
        /// 
        /// <para>● Концепция, описание, принцип работы элемента:</para>
        /// <para>Метод возвращающего типа, который должен выполнять:</para> 
        /// <list type="number">
        ///    <item><description>процедуру выбора доступных блоков;</description></item>
        ///    <item><description>процедуру пользовательского ввода выбранного варианта;</description></item>
        ///    <item><description>проццедуру поиска и проверку на исключения;</description></item>
        ///    <item><description>возврат выбранного блока операций.</description></item>
        /// </list> 
        /// 
        /// </summary>
        /// 
        /// <param name="~">
        /// <para>Входных параметров не имеет</para>
        /// </param>
        /// 
        /// <returns>Результат выбранных и найденных данных соответствующего типа <see cref="OperationBlock"/></returns>
        public OperationBlock BlockSelection()
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="counter"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"></exception>
        public string SavingTheResultSelection(double result, ref int counter)
        {
            _logger.Event($"{nameof(SavingTheResultSelection)}", $"Вывод списка дальнейших действий с результатом {result}.");
            Thread.Sleep(1000);

            _writer.WriteMessage("Ваши дальнейшие действия:");
            _writer.WriteMessage(
                $"1 - Сохранить результат {result} данной итерации №{counter},\n" +
                $"2 - Не сохранять результат {result} данной итерации №{counter}, но сохранить результат предыдущих итераций\n" +
                $"3 - Очистить результаты всех итераций (в том числе результат {result} данной итерации №{counter}),\n" +
                $"4 - Очистить результаты всех предыдущих итераций и сохранить результат {result} данной итерации №{counter},\n" +
                $"5 - Выход из Калькулятора");

            _logger.Event($"{nameof(SavingTheResultSelection)}", $"Выбор пользователя о дальнейшем действии с результатом {result}.");
            Thread.Sleep(1000);
            _writer.WriteMessage("Введите ниже - № дестйивя в консоль:");
            string choice = _reader.ReadChoice();

            switch (choice)
            {
                case "1":
                    _logger.Event($"{nameof(SavingTheResultSelection)}", $"Исполнение варианта {choice}.");

                    SavingTheResults(counter, result);
                    _writer.WriteMessage(
                        $"Результат {result} данной итерации №{counter} сохранен в память.\n" +
                        $"Номер данной итерации №{counter} не изменён\n" +
                        $"Счётчик итераций {nameof(counter)} = {counter} / не сброшен.\n" +
                        $"Программа калькулятора переходит к следующей итерации №{counter + 1}");
                    return choice;
                case "2":
                    _logger.Event($"{nameof(SavingTheResultSelection)}", $"Исполнение варианта {choice}.");

                    _writer.WriteMessage(
                        $"Результат {result} данной итерации №{counter} не сохранен в память.\n" +
                        $"Номер данной итерации №{counter} изменён на №{counter -= 1}\n" +
                        $"Счётчик итераций {nameof(counter)} = {counter} / сброшен на 1 итерацию.\n" +
                        $"Программа калькулятора переходит к новой итерации №{counter + 1}");
                    return choice;
                case "3":
                    _logger.Event($"{nameof(SavingTheResultSelection)}", $"Исполнение варианта {choice}.");

                    ClearingTheMemory();
                    _writer.WriteMessage(
                        $"Все результаты прошлых итераций, в том чесле результат {result} данной итерации №{counter} - \n" +
                        $"были очищены из памяти.\n" +
                        $"Номер данной итерации №{counter} изменён на №{counter = 0}\n" +
                        $"Счётчик итераций {nameof(counter)} = {counter} / сброшен на 0.\n" +
                        $"Программа калькулятора переходит к новой итерации №{counter + 1}");
                    counter = 0;
                    return choice;
                case "4":
                    _logger.Event($"{nameof(SavingTheResultSelection)}", $"Исполнение варианта {choice}.");

                    ClearingTheMemory();
                    SavingTheResults(counter, result);
                    _writer.WriteMessage(
                        $"Все результаты прошлых итераций были очищены из памяти.\n" +
                        $"Результат {result} данной итерации №{counter} сохранен в память." +
                        $"Номер данной итерации №{counter} изменён на №{counter = 1}\n" +
                        $"Счётчик итераций {nameof(counter)} = {counter} / сброшен до 1.\n" +
                        $"Программа калькулятора переходит к новой итерации №{counter + 1}");
                    return choice;
                case "5":
                    _logger.Event($"{nameof(SavingTheResultSelection)}", $"Исполнение варианта {choice}.");

                    _writer.WriteMessage(
                        $"Результат {result} итерации №{counter} не будет сохранен в память.\n" +
                        $"Все результаты прошлых итераций будут очищены из пямяти.\n" +
                        $"Программа Калькулятора будет завершена.");
                    return choice;
                default:
                    _logger.Event($"{nameof(SavingTheResultSelection)}", $"Исполнение варианта {choice}.");

                    throw new FormatException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectionOutput"></param>
        /// <returns></returns>
        public bool ShouldContinueSelection(string selectionOutput)
        {
            var response = selectionOutput;
            _logger.Event("Continue", $"Ответ пользователя: {response}");
            return response == "1" || response == "2" || response == "3" || response == "4";
        }
    }
}
