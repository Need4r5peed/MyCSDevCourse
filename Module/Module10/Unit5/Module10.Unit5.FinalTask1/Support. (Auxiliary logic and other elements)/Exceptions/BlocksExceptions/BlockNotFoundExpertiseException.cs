using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Статический класс для проверки доступности и существования блоков операций в реестре или коллекции"
    /// <summary>
    /// Статический класс для проверки доступности и существования блоков операций в реестре или коллекции.
    /// <para>Предоставляет методы для:</para>
    /// <list type="bullet">
    ///   <item><description>проверки наличия блока операций в реестре по имени;</description></item>
    ///   <item><description>получения фабрики блока операций из реестра;</description></item>
    ///   <item><description>проверки доступности блока операций в коллекции доступных блоков.</description></item>
    /// </list>
    /// <remarks>
    /// <para><b>ℹ️ Дополнение:</b></para>
    /// <list type="bullet">
    ///   <item><description>Используется в системе калькулятора для валидации блоков операций перед их использованием.</description></item>
    /// </list>
    /// </remarks>
    /// </summary>
    #endregion
    public static class BlockNotFoundExpertiseException
    {
        #region Method Description "Проверка наличия блока в реестре"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Expertise(string, Dictionary{string, Func{OperationBlock}})"/> | Проверка наличия блока в реестре.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Статический метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Метод, проверяющий наличие блока операций в реестре по его имени:</para>
        /// <list type="bullet">
        ///   <item><description>Выбрасывает исключение, если блок с указанным именем не найден в реестре.</description></item>
        /// </list>
        /// </summary>
        /// <param name="blockName">Имя блока операций для проверки.</param>
        /// <param name="blockRegistry">Словарь-реестр, содержащий имена блоков и их фабрики.</param>
        /// <exception cref="BlockNotFoundException">Выбрасывается, если блок с указанным именем не найден в реестре.</exception>
        #endregion
        public static void Expertise(
            string blockName,
            Dictionary<string, Func<OperationBlock>> blockRegistry)
        {
            // Проверка наличия ключа в словаре-реестре
            if (!blockRegistry.ContainsKey(blockName))
                throw new BlockNotFoundException(blockName);
        }

        #region Method Description "Проверка и получение фабрики блока"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Expertise(string, Dictionary{string, Func{OperationBlock}}, out Func{OperationBlock})"/> | Проверка и получение фабрики блока.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Статический метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Метод, проверяющий наличие фабрики блока операций в реестре и возвращающий её через out-параметр:</para>
        /// <list type="bullet">
        ///   <item><description>Выбрасывает исключение, если фабрика для указанного блока не найдена, иначе возвращает фабрику через out-параметр.</description></item>
        /// </list>
        /// </summary>
        /// <param name="blockName">Имя блока операций для проверки.</param>
        /// <param name="blockRegistry">Словарь-реестр, содержащий имена блоков и их фабрики.</param>
        /// <param name="factory">Out-параметр для возврата фабрики блока операций типа <see cref="Func{OperationBlock}"/>.</param>
        /// <exception cref="BlockNotFoundException">Выбрасывается, если фабрика для указанного блока не найдена в реестре.</exception>
        #endregion
        public static void Expertise(
            string blockName,
            Dictionary<string, Func<OperationBlock>> blockRegistry,
            out Func<OperationBlock> factory)
        {
            // Попытка получения фабрики из реестра
            if (!blockRegistry.TryGetValue(blockName, out factory))
                throw new BlockNotFoundException(blockName);
        }

        #region Method Description "Проверка доступности блока в коллекции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Expertise(string, IEnumerable{OperationBlock})"/> | Проверка доступности блока в коллекции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Статический метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Метод, проверяющий наличие блока операций с указанным именем в коллекции доступных блоков:</para>
        /// <list type="bullet">
        ///   <item><description>Выбрасывает исключение, если блок с указанным именем отсутствует в коллекции.</description></item>
        /// </list>
        /// </summary>
        /// <param name="blockName">Имя блока операций для проверки.</param>
        /// <param name="availableBlocks">Коллекция доступных блоков операций.</param>
        /// <exception cref="BlockNotAvailableException">Выбрасывается, если блок с указанным именем не найден в коллекции.</exception>
        #endregion
        public static void Expertise(
            string blockName,
            IEnumerable<OperationBlock> availableBlocks)
        {
            // Проверка наличия блока в коллекции
            if (!availableBlocks.Any(b => b.BlockName.Equals(blockName)))
                throw new BlockNotAvailableException(blockName);
        }
    }
}