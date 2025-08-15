using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Статический класс для реестра блоков математических операций"
    /// <summary>
    /// Статический класс для реестра блоков математических операций.
    /// <para>Управляет словарем блоков операций и их фабрик, обеспечивая регистрацию и создание экземпляров:</para>
    /// <list type="bullet">
    ///   <item><description>Хранит словарь с названиями блоков и инструкциями для их создания.</description></item>
    ///   <item><description>Обеспечивает потокобезопасное кэширование созданных блоков.</description></item>
    ///   <item><description>Предоставляет методы для регистрации, создания и получения блоков.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public static class BlockRegistry
    {
        #region Field Description "Словарь блоков математических операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="_blockRegistry"/> | Словарь блоков математических операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное статическое поле.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Поле типа <see cref="Dictionary{string, Func{OperationBlock}}"/>, которое:</para>
        /// <list type="number">
        ///   <item><description>Хранит пары ключ-значение, где ключ — строка с названием блока, а значение — делегат для создания экземпляра блока.</description></item>
        ///   <item><description>Инициализируется пустым словарем при создании класса.</description></item>
        /// </list>
        /// </summary>
        #endregion
        internal static readonly Dictionary<string, Func<OperationBlock>> _blockRegistry = new Dictionary<string, Func<OperationBlock>>(); // Словарь для хранения фабрик блоков

        #region Field Description "Потокобезопасный кэш экземпляров блоков"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="_initializedBlocks"/> | Потокобезопасный кэш экземпляров блоков.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное статическое поле.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Поле типа <see cref="ConcurrentDictionary{string, OperationBlock}"/>, которое:</para>
        /// <list type="number">
        ///   <item><description>Хранит созданные экземпляры блоков для повторного использования.</description></item>
        ///   <item><description>Обеспечивает потокобезопасный доступ к кэшу.</description></item>
        /// </list>
        /// </summary>
        #endregion
        internal static readonly ConcurrentDictionary<string, OperationBlock> _initializedBlocks = new(); // Потокобезопасный кэш для экземпляров блоков

        #region Field Description "Фабрика для создания логгеров"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="_loggerFactory"/> | Фабрика для создания логгеров.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное статическое поле.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Поле типа <see cref="Func{string, ILogger}"/>, которое:</para>
        /// <list type="number">
        ///   <item><description>Хранит делегат для создания экземпляров логгеров.</description></item>
        ///   <item><description>Используется при создании блоков, требующих логирования.</description></item>
        /// </list>
        /// </summary>
        #endregion
        private static Func<string, ILogger> _loggerFactory; // Делегат для создания логгеров

        #region Method Description "Инициализация реестра блоков"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Initialize"/> | Инициализация реестра блоков.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Статический метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Статический метод, выполняющий инициализацию реестра:</para>
        /// <list type="number">
        ///   <item><description>Принимает делегат для создания логгеров.</description></item>
        ///   <item><description>Сохраняет делегат в поле <see cref="_loggerFactory"/>.</description></item>
        ///   <item><description>Регистрирует начальный блок операций.</description></item>
        /// </list>
        /// </summary>
        /// <param name="loggerFactory">Делегат типа <see cref="Func{string, ILogger}"/> для создания логгеров.</param>
        #endregion
        public static void Initialize(Func<string, ILogger> loggerFactory)
        {
            // Сохранение делегата для создания логгеров
            _loggerFactory = loggerFactory;
            // Регистрация начального блока арифметических операций
            Register<BasicArithmeticBlock>("basic arithmetic");
        }

        #region Method Description "Регистрация блока операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Register{T}"/> | Регистрация блока операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Статический обобщённый метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Статический метод, выполняющий регистрацию нового типа блока операций:</para>
        /// <list type="number">
        ///   <item><description>Принимает название блока и регистрирует делегат для его создания.</description></item>
        ///   <item><description>Поддерживает создание экземпляров через обобщённый тип с ограничениями.</description></item>
        ///   <item><description>Добавляет делегат в словарь <see cref="_blockRegistry"/>.</description></item>
        /// </list>
        /// </summary>
        /// <typeparam name="T">Тип блока операций, наследуемый от <see cref="OperationBlock"/>.</typeparam>
        /// <param name="blockName">Строковое значение типа <see cref="string"/>, представляющее название блока операций.</param>
        #endregion
        public static void Register<T>(string blockName) where T : OperationBlock
        {
            // Регистрация делегата для создания блока
            _blockRegistry[blockName] = () =>
            {
                // Проверка типа и создание экземпляра с логгером для BasicArithmeticBlock
                if (typeof(T) == typeof(BasicArithmeticBlock))
                    return new BasicArithmeticBlock(_loggerFactory);

                // Выброс исключения для неподдерживаемых типов
                throw new InvalidOperationException($"Unsupported block type: {typeof(T)}");
            };
        }

        #region Method Description "Создание экземпляра блока операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Create"/> | Создание экземпляра блока операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Статический метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Статический метод, выполняющий создание экземпляра блока операций:</para>
        /// <list type="number">
        ///   <item><description>Принимает название блока операций.</description></item>
        ///   <item><description>Проверяет наличие блока в реестре через <see cref="BlockNotFoundExpertiseException"/>.</description></item>
        ///   <item><description>Создаёт экземпляр блока, вызывая соответствующий делегат.</description></item>
        /// </list>
        /// </summary>
        /// <param name="blockName">Строковое значение типа <see cref="string"/>, представляющее название блока операций.</param>
        /// <returns>Экземпляр блока операций типа <see cref="OperationBlock"/>.</returns>
        /// <exception cref="BlockNotFoundException">Выбрасывается, если блок отсутствует в реестре.</exception>
        #endregion
        public static OperationBlock Create(string blockName)
        {
            // Проверка наличия блока в реестре
            BlockNotFoundExpertiseException.Expertise(blockName, _blockRegistry);
            // Создание экземпляра блока через делегат
            return _blockRegistry[blockName]();
        }

        #region Method Description "Получение или создание экземпляра блока операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="GetOrCreate"/> | Получение или создание экземпляра блока операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Статический метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Статический метод, выполняющий получение или создание экземпляра блока операций с кэшированием:</para>
        /// <list type="number">
        ///   <item><description>Проверяет наличие блока в кэше <see cref="_initializedBlocks"/>.</description></item>
        ///   <item><description>Если блока нет, создаёт новый экземпляр через реестр.</description></item>
        ///   <item><description>Сохраняет созданный экземпляр в кэш и возвращает его.</description></item>
        /// </list>
        /// </summary>
        /// <param name="blockName">Строковое значение типа <see cref="string"/>, представляющее название блока операций.</param>
        /// <returns>Экземпляр блока операций типа <see cref="OperationBlock"/>.</returns>
        /// <exception cref="BlockNotFoundException">Выбрасывается, если блок отсутствует в реестре.</exception>
        #endregion
        public static OperationBlock GetOrCreate(string blockName)
        {
            // Проверка наличия блока в кэше
            if (_initializedBlocks.TryGetValue(blockName, out var block))
                // Возврат существующего экземпляра из кэша
                return block;

            // Проверка наличия фабрики в реестре
            BlockNotFoundExpertiseException.Expertise(blockName, _blockRegistry, out var factory);

            // Создание нового экземпляра блока
            block = factory();

            // Сохранение экземпляра в кэш
            _initializedBlocks.TryAdd(blockName, block);
            // Возврат созданного экземпляра
            return block;
        }

        #region Method Description "Получение списка доступных блоков"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="GetAvailableBlocks"/> | Получение списка доступных блоков.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Статический метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Статический метод, возвращающий коллекцию названий зарегистрированных блоков:</para>
        /// <list type="bullet">
        ///   <item><description>Формирует и возвращает коллекцию ключей словаря <see cref="_blockRegistry"/>.</description></item>
        /// </list>
        /// </summary>
        /// <returns>Коллекция названий блоков типа <see cref="IEnumerable{string}"/>.</returns>
        #endregion
        public static IEnumerable<string> GetAvailableBlocks() => _blockRegistry.Keys; // Возвращает коллекцию ключей словаря
    }
}