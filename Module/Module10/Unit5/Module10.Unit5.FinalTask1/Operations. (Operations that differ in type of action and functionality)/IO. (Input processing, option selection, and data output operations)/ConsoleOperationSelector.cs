using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ResultOfPreviousIterations;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Реализация интерфейса IOperationSelector для операций консольного выбора процедур калькулятора"
    /// <summary>
    /// Реализация операций консольного выбора процедур калькулятора.
    /// <para>Класс, реализующий интерфейс <see cref="IOperationSelector"/> для:</para>
    /// <list type="bullet">
    ///   <item><description>управления выбором блоков математических операций;</description></item>
    ///   <item><description>выбора конкретных операций внутри блоков;</description></item>
    ///   <item><description>ввода аргументов для операций;</description></item>
    ///   <item><description>управления сохранением результатов и продолжением работы калькулятора.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public class ConsoleSelection : IOperationSelector
    {
        #region Field Description "Реализация интерфейса для вывода данных"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="_writer"/> | Реализация интерфейса для вывода данных.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное (<see langword="private"/>) поле только для чтения (<see langword="readonly"/>).</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Содержит экземпляр класса, реализующего интерфейс <see cref="IWriter"/> для организации вывода данных.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Используется для вывода сообщений, списков операций и результатов в консоль.</para>
        /// <remarks>
        /// <para><b>ℹ️ Дополнение:</b></para>
        /// <list type="bullet">
        ///   <item><description>Инициализируется через внедрение зависимости в конструкторе.</description></item>
        /// </list>
        /// </remarks>
        /// </summary>
        #endregion
        private readonly IWriter _writer;

        #region Field Description "Реализация интерфейса для чтения данных"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="_reader"/> | Реализация интерфейса для чтения данных.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное (<see langword="private"/>) поле только для чтения (<see langword="readonly"/>).</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Содержит экземпляр класса, реализующего интерфейс <see cref="IReader"/> для организации чтения пользовательского ввода.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Используется для получения пользовательского выбора блоков, операций, аргументов и вариантов сохранения результатов.</para>
        /// <remarks>
        /// <para><b>ℹ️ Дополнение:</b></para>
        /// <list type="bullet">
        ///   <item><description>Инициализируется через внедрение зависимости в конструкторе.</description></item>
        /// </list>
        /// </remarks>
        /// </summary>
        #endregion
        private readonly IReader _reader;

        #region Field Description "Реализация интерфейса для логирования событий"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="_logger"/> | Реализация интерфейса для логирования событий.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное (<see langword="private"/>) поле только для чтения (<see langword="readonly"/>).</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Содержит экземпляр класса, реализующего интерфейс <see cref="ILogger"/> для логирования событий и ошибок.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Используется для записи событий, таких как выбор блоков, операций, ввод аргументов и обработка исключений.</para>
        /// <remarks>
        /// <para><b>ℹ️ Дополнение:</b></para>
        /// <list type="bullet">
        ///   <item><description>Инициализируется через внедрение зависимости в конструкторе.</description></item>
        /// </list>
        /// </remarks>
        /// </summary>
        #endregion
        private readonly ILogger _logger;

        #region Constructor Description "Конструктор класса"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para>Конструктор класса <see cref="ConsoleSelection"/>.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Конструктор.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Инициализирует поля класса через внедрение зависимостей.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <list type="number">
        ///   <item><description>Принимает зависимости через параметры конструктора.</description></item>
        ///   <item><description>Присваивает переданные зависимости приватным полям класса.</description></item>
        /// </list>
        /// </summary>
        /// <param name="writer">Экземпляр интерфейса <see cref="IWriter"/> для вывода данных.</param>
        /// <param name="reader">Экземпляр интерфейса <see cref="IReader"/> для чтения пользовательского ввода.</param>
        /// <param name="logger">Экземпляр интерфейса <see cref="ILogger"/> для логирования событий.</param>
        #endregion
        public ConsoleSelection(
            IWriter writer, 
            IReader reader, 
            ILogger logger)
        {
            // Инициализация полей через внедрение зависимостей
            _writer = writer;
            _reader = reader;
            _logger = logger;
        }

        #region Method Description "Выбор блока математических операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="BlockSelection"/> | Выбор блока математических операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод возвращающего типа, реализующий выбор блока операций через консольный интерфейс:</para>
        /// <list type="number">
        ///   <item><description>Получает список доступных блоков из реестра <see cref="BlockRegistry"/>.</description></item>
        ///   <item><description>Выводит список доступных блоков пользователю через <see cref="_writer"/>.</description></item>
        ///   <item><description>Запрашивает пользовательский ввод названия блока через <see cref="_reader"/>.</description></item>
        ///   <item><description>Проверяет корректность выбора с помощью <see cref="BlockNotFoundExpertiseException.Expertise"/>.</description></item>
        ///   <item><description>Логирует этапы выполнения с помощью <see cref="_logger"/>.</description></item>
        ///   <item><description>Возвращает экземпляр выбранного блока операций через <see cref="BlockRegistry.GetOrCreate"/>.</description></item>
        /// </list>
        /// </summary>
        /// <returns>Экземпляр блока операций типа <see cref="OperationBlock"/>.</returns>
        /// <exception cref="BlockNotFoundException">Выбрасывается, если блок с указанным именем не найден в реестре.</exception>
        #endregion
        public OperationBlock BlockSelection()
        {
            // Логирование загрузки доступных блоков
            _logger.Event($"{nameof(BlockSelection)}", "Загрузка блоков.");
            // Получение списка доступных блоков
            var availableBlockNames = BlockRegistry.GetAvailableBlocks();

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Логирование вывода блоков
            _logger.Event($"{nameof(BlockSelection)}", "Вывод доступных блоков.");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Вывод сообщения и списка блоков
            _writer.WriteMessage("Доступные блоки операций:");
            _writer.WriteAvailableBlocks(availableBlockNames);

            // Логирование пользовательского ввода
            _logger.Event($"{nameof(BlockSelection)}", "Пользовательский ввод по выбору блока.");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Запрос выбора блока
            _writer.WriteMessage("Выберите и введите название блока операций в консоль:");
            var blockNameСhoice = _reader.ReadBlockChoice();

            // Логирование поиска выбранного блока
            _logger.Event($"{nameof(BlockSelection)}", $"Поиск блока: {blockNameСhoice}");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Проверка на наличие блока
            _logger.Event($"{nameof(BlockSelection)}", $"Поиск исключений для {blockNameСhoice}");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Проверка корректности выбора блока
            BlockNotFoundExpertiseException.Expertise(blockNameСhoice, BlockRegistry._blockRegistry);

            // Логирование успешного выбора
            _logger.Event($"{nameof(BlockSelection)}", $"Блок '{blockNameСhoice}' найден. Выбор корректен.");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Логирование возврата блока
            _logger.Event($"{nameof(BlockSelection)}", $"Возвращение блока '{blockNameСhoice}'.");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Возврат выбранного блока
            return BlockRegistry.GetOrCreate(blockNameСhoice);
        }

        #region Method Description "Выбор математической операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="OperationSelection"/> | Выбор математической операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод возвращающего типа, реализующий выбор математической операции из указанного блока:</para>
        /// <list type="number">
        ///   <item><description>Выводит список доступных операций блока через <see cref="_writer"/>.</description></item>
        ///   <item><description>Запрашивает пользовательский ввод названия операции через <see cref="_reader"/>.</description></item>
        ///   <item><description>Проверяет корректность выбора с помощью <see cref="OperationNotFoundExpertiseException.Expertise"/>.</description></item>
        ///   <item><description>Логирует этапы выполнения с помощью <see cref="_logger"/>.</description></item>
        ///   <item><description>Возвращает выбранную операцию из словаря операций блока.</description></item>
        /// </list>
        /// </summary>
        /// <param name="block">Экземпляр блока операций типа <see cref="OperationBlock"/>, содержащий доступные операции.</param>
        /// <returns>Экземпляр математической операции типа <see cref="IMathOperation"/>.</returns>
        /// <exception cref="OperationNotFoundException">Выбрасывается, если операция с указанным именем не найдена в блоке.</exception>
        #endregion
        public IMathOperation OperationSelection(OperationBlock block)
        {
            // Логирование вывода операций
            _logger.Event($"{nameof(OperationSelection)}", "Вывод доступных операций.");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Вывод сообщения и списка операций
            _writer.WriteMessage($"Доступные операции в блоке '{block.BlockName}':");
            _writer.WriteAvailableOperations(block.Operations.Keys);

            // Логирование пользовательского ввода
            _logger.Event($"{nameof(OperationSelection)}", "Пользовательский ввод по выбору операции.");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Запрос выбора операции
            _writer.WriteMessage($"Выберите и введите название операции из блока '{block.BlockName}':");
            var operationUsersChoice = _reader.ReadOperationChoice();

            // Логирование поиска операции
            _logger.Event($"{nameof(OperationSelection)}", $"Поиск операции: {operationUsersChoice}");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Проверка на наличие операции
            _logger.Event($"{nameof(OperationSelection)}", $"Поиск исключений для {operationUsersChoice}.");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Проверка корректности выбора операции
            OperationNotFoundExpertiseException.Expertise(operationUsersChoice, block);

            // Логирование успешного выбора
            _logger.Event($"{nameof(OperationSelection)}", $"Операция '{operationUsersChoice}' доступна и готова к исполнению.");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Логирование загрузки операции
            _logger.Event($"{nameof(OperationSelection)}", $"Загрузка операции {operationUsersChoice} в память.");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Возврат выбранной операции
            return block.Operations[operationUsersChoice];
        }

        #region Method Description "Выбор аргументов для математической операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ArgSelection"/> | Выбор аргументов для математической операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод возвращающего типа, реализующий ввод аргументов для выбранной операции:</para>
        /// <list type="number">
        ///   <item><description>Запрашивает у пользователя ввод аргументов через <see cref="_reader"/>.</description></item>
        ///   <item><description>Проверяет количество аргументов с помощью <see cref="RequiredArgsCountExpertiseException.Expertise"/>.</description></item>
        ///   <item><description>Логирует этапы выполнения с помощью <see cref="_logger"/>.</description></item>
        ///   <item><description>Возвращает массив введённых аргументов типа <see cref="double"/>.</description></item>
        /// </list>
        /// </summary>
        /// <param name="operation">Экземпляр математической операции типа <see cref="IMathOperation"/>, для которой вводятся аргументы.</param>
        /// <returns>Массив аргументов типа <see cref="double[]"/>.</returns>
        /// <exception cref="RequiredArgsCountException">Выбрасывается, если количество введённых аргументов не соответствует требованиям операции.</exception>
        #endregion
        public double[] ArgSelection(IMathOperation operation)
        {
            // Вспомогательная функция для форматирования аргументов в логе
            string FormatArgs(object a) => a is double[] array ? $"[{string.Join(", ", array)}]" : a.ToString();

            // Логирование начала ввода аргументов
            _logger.Event($"{nameof(ArgSelection)}", $"Ввод пользователем аргументов.");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Запрос ввода аргументов
            _writer.WriteMessage($"Введите {operation.MinArgsCount}-{operation.MaxArgsCount} аргументов через пробел:");
            var args = _reader.ReadNumbers();

            // Логирование проверки аргументов
            _logger.Event($"{nameof(ArgSelection)}", $"Поиск исключений для {FormatArgs(args)}.");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Проверка корректности аргументов
            RequiredArgsCountExpertiseException.Expertise(args, operation);

            // Логирование успешного ввода аргументов
            _logger.Event($"{nameof(ArgSelection)}", $"Аргументы {FormatArgs(args)} готовы к использованию.");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Возврат массива аргументов
            return args;
        }

        #region Method Description "Выбор варианта сохранения результата вычислений"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="SavingTheResultSelection"/> | Выбор варианта сохранения результата вычислений.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод возвращающего типа, реализующий выбор действия с результатом вычислений:</para>
        /// <list type="number">
        ///   <item><description>Выводит список возможных действий с результатом через <see cref="_writer"/>.</description></item>
        ///   <item><description>Запрашивает пользовательский выбор через <see cref="_reader"/>.</description></item>
        ///   <item><description>Обрабатывает выбор пользователя, выполняя соответствующие действия (сохранение, очистка памяти, изменение счётчика).</description></item>
        ///   <item><description>Логирует этапы выполнения с помощью <see cref="_logger"/>.</description></item>
        ///   <item><description>Возвращает строковый код выбранного действия.</description></item>
        /// </list>
        /// </summary>
        /// <param name="result">Результат вычисления текущей итерации типа <see cref="double"/>.</param>
        /// <param name="counter">Счётчик итераций типа <see cref="int"/>, передаваемый по ссылке (<see langword="ref"/>).</param>
        /// <returns>Строковый код выбранного действия ("1", "2", "3", "4" или "5").</returns>
        /// <exception cref="FormatException">Выбрасывается, если пользователь ввёл некорректный вариант действия.</exception>
        #endregion
        public string SavingTheResultSelection(
            double result, 
            ref int counter)
        {
            // Логирование вывода списка действий
            _logger.Event($"{nameof(SavingTheResultSelection)}", $"Вывод списка дальнейших действий с результатом {result}.");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Вывод сообщения с вариантами действий
            _writer.WriteMessage("Ваши дальнейшие действия:");
            _writer.WriteMessage(
                $"1 - Сохранить результат {result} данной итерации №{counter},\n" +
                $"2 - Не сохранять результат {result} данной итерации №{counter}, но сохранить результат предыдущих итераций,\n" +
                $"3 - Очистить результаты всех итераций (в том числе результат {result} данной итерации №{counter}),\n" +
                $"4 - Очистить результаты всех предыдущих итераций и сохранить результат {result} данной итерации №{counter},\n" +
                $"5 - Выход из Калькулятора");

            // Логирование запроса пользовательского выбора
            _logger.Event($"{nameof(SavingTheResultSelection)}", $"Выбор пользователя о дальнейшем действии с результатом {result}.");

            // Задержка для имитации обработки
            Thread.Sleep(1000);

            // Запрос пользовательского выбора
            _writer.WriteMessage("Введите ниже - № действия в консоль:");
            string choice = _reader.ReadChoice();

            switch (choice)
            {
                case "1":
                    // Логирование выбора варианта 1
                    _logger.Event($"{nameof(SavingTheResultSelection)}", $"Исполнение варианта {choice}.");

                    // Сохранение результата
                    SavingTheResults(counter, result);
                    // Вывод сообщения о сохранении
                    _writer.WriteMessage(
                        $"Результат {result} данной итерации №{counter} сохранён в память.\n" +
                        $"Номер данной итерации №{counter} не изменён.\n" +
                        $"Счётчик итераций {nameof(counter)} = {counter} / не сброшен.\n" +
                        $"Программа калькулятора переходит к следующей итерации №{counter + 1}");
                    return choice;

                case "2":
                    // Логирование выбора варианта 2
                    _logger.Event($"{nameof(SavingTheResultSelection)}", $"Исполнение варианта {choice}.");

                    // Уменьшение счётчика
                    counter -= 1;
                    // Вывод сообщения о несохранении результата
                    _writer.WriteMessage(
                        $"Результат {result} данной итерации №{counter} не сохранён в память.\n" +
                        $"Номер итерации изменён на №{counter}.\n" +
                        $"Счётчик итераций {nameof(counter)} = {counter} / сброшен на 1 итерацию.\n" +
                        $"Программа калькулятора переходит к новой итерации №{counter + 1}");
                    return choice;

                case "3":
                    // Логирование выбора варианта 3
                    _logger.Event($"{nameof(SavingTheResultSelection)}", $"Исполнение варианта {choice}.");

                    // Очистка памяти
                    ClearingTheMemory();
                    // Сброс счётчика
                    counter = 0;
                    // Вывод сообщения об очистке
                    _writer.WriteMessage(
                        $"Все результаты прошлых итераций, в том числе результат {result} данной итерации №{counter}, \n" +
                        $"были очищены из памяти.\n" +
                        $"Номер итерации изменён на №{counter}.\n" +
                        $"Счётчик итераций {nameof(counter)} = {counter} / сброшен на 0.\n" +
                        $"Программа калькулятора переходит к новой итерации №{counter + 1}");
                    return choice;

                case "4":
                    // Логирование выбора варианта 4
                    _logger.Event($"{nameof(SavingTheResultSelection)}", $"Исполнение варианта {choice}.");

                    // Очистка памяти
                    ClearingTheMemory();
                    // Установка счётчика
                    counter = 1;
                    // Сохранение результата
                    SavingTheResults(counter, result);
                    // Вывод сообщения об очистке и сохранении
                    _writer.WriteMessage(
                        $"Все результаты прошлых итераций были очищены из памяти.\n" +
                        $"Результат {result} сохранён как итерация №{counter}.\n" +
                        $"Счётчик итераций сброшен до №{counter}.\n" +
                        $"Программа калькулятора переходит к новой итерации №{counter + 1}");
                    return choice;

                case "5":
                    // Логирование выбора варианта 5
                    _logger.Event($"{nameof(SavingTheResultSelection)}", $"Исполнение варианта {choice}.");

                    // Очистка памяти
                    ClearingTheMemory();
                    // Установка счётчика
                    counter = 1;
                    // Вывод сообщения о завершении
                    _writer.WriteMessage(
                        $"Результат {result} итерации №{counter} не сохранён в память.\n" +
                        $"Все результаты прошлых итераций были очищены из памяти.\n" +
                        $"Программа Калькулятора завершена.");
                    return choice;

                default:
                    // Логирование некорректного выбора
                    _logger.Event($"{nameof(SavingTheResultSelection)}", $"Некорректный выбор: {choice}. Выброс исключения.");

                    // Выброс исключения при некорректном вводе
                    throw new FormatException("Введён некорректный вариант действия.");
            }
        }

        #region Method Description "Определение продолжения работы калькулятора"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ShouldContinueSelection"/> | Определение продолжения работы калькулятора.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод возвращающего типа, определяющий необходимость продолжения работы калькулятора:</para>
        /// <list type="number">
        ///   <item><description>Принимает строковый код выбора пользователя из метода <see cref="SavingTheResultSelection"/>.</description></item>
        ///   <item><description>Логирует выбор пользователя с помощью <see cref="_logger"/>.</description></item>
        ///   <item><description>Возвращает <see langword="true"/> для продолжения работы (варианты "1", "2", "3", "4") или <see langword="false"/> для выхода (вариант "5").</description></item>
        /// </list>
        /// </summary>
        /// <param name="selectionOutput">Строка, представляющая выбор пользователя из <see cref="SavingTheResultSelection"/>.</param>
        /// <returns>Булево значение, указывающее, продолжать ли работу калькулятора.</returns>
        #endregion
        public bool ShouldContinueSelection(string selectionOutput)
        {
            // Сохранение пользовательского выбора
            var response = selectionOutput;
            // Логирование пользовательского ответа
            _logger.Event($"{nameof(ShouldContinueSelection)}", $"Ответ пользователя: {response}");
            // Проверка условия продолжения работы
            return response == "1" || response == "2" || response == "3" || response == "4";
        }
    }
}