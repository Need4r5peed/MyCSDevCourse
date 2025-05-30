using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    /// <summary>
    /// "Реестр блоков математических операций".
    /// <para>Класс,</para>
    /// <para>● описывающий объект типа словарь</para>
    /// <para>● данный словарь, в свою очередь, содержит названия блоков операций и инструкции по созданию экземпляров соответствующих блоков</para>
    /// </summary>
    public static class BlockRegistry
    {
        /// <summary>
        /// "Словарь блоков математических операций".
        /// <para>Приватное статическое поле-словарь, которое</para>
        /// <para>● хранит данные ключа типа string словоря "Названия блока математических операций"</para>
        /// <para>● хранит данные значение типа Func<OperationBlock> "Инструкции по созданию экземпляра блока математических операций"</para>
        /// <para>● имеет значение по умолчанию: новый пустой словарь с соответствующими типами key и value</para>
        /// </summary>
        internal static readonly Dictionary<string, Func<OperationBlock>> _blockRegistry = new Dictionary<string, Func<OperationBlock>>();

        /// <summary>
        /// Что-то там про потокобезопасность...
        /// </summary>
        internal static readonly ConcurrentDictionary<string, OperationBlock> _initializedBlocks = new();

        /// <summary>
        /// <para>Статический конструктор</para>
        /// <para>● вызывается один раз при первом обращении к классу</para>
        /// <para>● инициализирует словарь с переданными в него данными</para>
        /// </summary>
        static BlockRegistry()
        {
            // Вызов метода для регистрации конкретного блока <BasicArithmeticBlock> под именем "basic arithmetic"
            Register<BasicArithmeticBlock>("basic arithmetic");
        }

        /// <summary>
        /// <para>"Регистратор" - статиечский обобщённый метод невозвращающего типа, который выполняет:</para>
        /// <para>1) приём параметров</para>
        /// <para>2) регистрацию нового типа блока</para>
        /// <para>Описание метода:</para>
        /// <para>● <c>Register&lt;T&gt;</c> - указатель обобщённому методу для использования инструкции по подстановке 
        /// конкретного типа (логической генерации кода с необходимыми параметрами)</para>
        /// <para>● <c>&lt;T&gt;</c> - Обобщённый (generic) параметр типа T</para>
        /// <para>● <c>string blockName</c> - Параметр метода типа <see cref="string"/>, передающий "Название блока"</para>
        /// <para>● <c>where T : OperationBlock, new()</c> - Перечисление ограничений для типа Т:</para>
        /// <para>1) OperationBlock - ограничение на использование только данного типа <see cref="OperationBlock"/> 
        /// (должен наследоваться от)</para>
        /// <para>2) new() - ограничение на применение конструктора без параметров для используемого типа</para>
        /// <para>Тело метода:</para>
        /// <para>● <c>_blockRegistry</c> - Хранит "инструкции"(делегаты) создания блоков, 
        /// тип: Dictionary&lt;string, Func&lt;OperationBlock&gt;&gt;</para>
        /// <para>● <c>blockName</c> - 	Уникальный идентификатор блока ("Название блока" / ключ словаря), тип: string</para>
        /// <para>● <c>() =&gt; new T()</c> - Отложенное создание экземпляра через анонимный метод(лямбда-выражение) 
        /// (Func&lt;OperationBlock&gt;)</para>
        /// <para>● <c>new T()</c> - Вызов конструктора типа T с ограничением new()</para>
        /// </summary>
        /// <typeparam name="T">
        /// <para>Тип обобщённого параметра с ограничениями <see cref="OperationBlock"/>  
        /// и <see cref="new()"/></para>
        /// <para>● <c>where T : OperationBlock</c> — с ограничением типа - только <see cref="OperationBlock"/>"</para>
        /// <para>● <c>where T : new()</c> — с ограничением для конструктора типа - только без параметров"</para>
        /// </typeparam>
        /// <param name="blockName">
        /// <para>Параметр метода - строковое значение</para>
        /// <para>● <c>string</c> — string-тип строкового значения</para>
        /// <para>● <c>blockName</c> — имя параметра "Название блока математических операций"</para>
        /// </param>
        public static void Register<T>(string blockName) where T : OperationBlock, new()
        {
            // Описание процедуры регистрации - сохранения ссылки на анонимный метод (инструкции), который
            // в будущем может создать экземпляр по указанному имени-индексатору
            _blockRegistry[blockName] = () => new T();
        }

        /// <summary>
        /// <para>"Создатель" - статиечский метод возвращающего типа <see cref="OperationBlock"/>, который выполняет:</para>
        /// <para>1) приём параметра</para>
        /// <para>2) проверку на исключение</para>
        /// <para>3) создание экземпляра указанного типа по вызванной инструкции-делегату</para>
        /// <para>4) возвращение созданного экземпляра указанного типа</para>
        /// <para>Тело метода:</para>
        /// <para>● <c>BlockNotFoundExpertiseException.Expertise(blockName, _blockRegistry)</c> - Вызов обрабочика исключений</para>
        /// <para>● <c>_blockRegistry[blockName]()</c> - Поиск инструкции по индексатору и создание по ней экземпляра</para>
        /// </summary>
        /// <param name="blockName"> 
        /// <para>Параметр метода - строковое значение</para>
        /// <para>● <c><see cref="string"/></c> — string-тип строкового значения</para>
        /// <para>● <c>blockName</c> — имя параметра "Название блока математических операций"</para>
        /// <para>● <c>where T : OperationBlock</c> — с ограничением типа - только <see cref="OperationBlock"/>"</para>
        /// </param>
        /// <returns>Возвращает результат поиска в виде булевого значения</returns>
        /// <exception cref="BlockNotFoundException">Выбрасывается, если отсутствует блок в реестре.</exception>
        /// <remarks>
        /// <b>BlockNotFoundException</b>: Выбрасывается, если отсутствует блок в реестре.
        /// </remarks>
        public static OperationBlock Create(string blockName)
        {
            //Проверка существование инструкции в реестре
            BlockNotFoundExpertiseException.Expertise(blockName, _blockRegistry);

            // 1. Доступ к словарю
            // 2. Ключ для поиска
            // 3. Вызов делегата
            return _blockRegistry[blockName]();
        }

        /// <summary>
        /// Дополнительная приблуда для кэширования экземпляров
        /// </summary>
        /// <param name="blockName"></param>
        /// <returns></returns>
        /// <exception cref="BlockNotFoundException"></exception>
        public static OperationBlock GetOrCreate(string blockName)
        {
            // 1. Проверяем, есть ли уже созданный экземпляр блока
            if (_initializedBlocks.TryGetValue(blockName, out var block))
                // Точка возврата №1
                return block; // Если есть - возвращаем существующий

            // 2. Проверяем, зарегистрирована ли фабрика для этого блока
            BlockNotFoundExpertiseException.Expertise(blockName, _blockRegistry, out var factory);

            // 3. Создаём новый экземпляр через фабрику
            block = factory(); // Вызываем делегат Func<OperationBlock>

            // 4. Сохраняем в кэш перед возвратом
            _initializedBlocks.TryAdd(blockName, block);
            // Точка возврата №2
            return block;
        }

        /// <summary>
        /// <para>"Информатор" - статиечский метод возвращающего типа <see cref="IEnumerable&lt;string&gt;"/>, 
        /// где <typeparamref name="T"/> = <see cref="string"/>, 
        /// которое выполняет</para>
        /// <para>1) формирование коллекции ключей словаря</para>
        /// <para>2) возвращение коллекции указанного типа</para>
        /// <para>Описание метода:</para>
        /// <para>● <c>IEnumerable&lt;string&gt;</c> - интерфейс, представляющий последовательность строк</para>
        /// <para>Тело метода:</para>
        /// <para>● <c>_blockRegistry.Keys</c> - Применение специального свойства Keys для получения 
        /// Dictionary.KeyCollection, скрытой в IEnumerable&lt;string&gt;</para>
        /// </summary>
        /// <param name="~">
        /// <para>Входных параметров не имеет</para>
        /// <para>● <c>-</c></para>
        /// <para>● <c>-</c></para>
        /// <para>● <c>-</c></para>
        /// </param>
        /// <returns>Возвращает сформированную коллекцию ключей словаря (все зарегистрированные имена блоков)</returns>
        public static IEnumerable<string> GetAvailableBlocks() => _blockRegistry.Keys;
    }
}
