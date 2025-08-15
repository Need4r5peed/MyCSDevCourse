using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Исключение, выбрасываемое при попытке доступа к несуществующему блоку операций в реестре"
    /// <summary>
    /// Исключение, выбрасываемое при попытке доступа к несуществующему блоку операций в реестре.
    /// <para>Наследуется от <see cref="Exception"/> и предоставляет функциональность для:</para>
    /// <list type="bullet">
    ///   <item><description>хранения имени не найденного блока;</description></item>
    ///   <item><description>формирования сообщения об ошибке с указанием имени блока.</description></item>
    /// </list>
    /// <remarks>
    /// <para><b>ℹ️ Дополнение:</b></para>
    /// <list type="bullet">
    ///   <item><description>Используется в системе калькулятора для обработки ошибок, связанных с отсутствием блока операций в реестре.</description></item>
    /// </list>
    /// </remarks>
    /// </summary>
    #endregion
    public class BlockNotFoundException : Exception
    {
        #region Property Description "Имя не найденного блока"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="BlockName"/> | Имя не найденного блока.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Свойство, которое:</para>
        /// <list type="number">
        ///   <item><description>Хранит строковое значение имени не найденного блока.</description></item>
        ///   <item><description>Предоставляет доступ только для чтения этого значения.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public string BlockName { get; }

        #region Constructor Description "Конструктор класса"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para>Конструктор класса <see cref="BlockNotFoundException"/>.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Конструктор.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Инициализирует экземпляр исключения с указанием имени не найденного блока:</para>
        /// <list type="number">
        ///   <item><description>Вызывает базовый конструктор <see cref="Exception"/> с формированием сообщения об ошибке.</description></item>
        ///   <item><description>Инициализирует свойство <see cref="BlockName"/> переданным значением.</description></item>
        /// </list>
        /// </summary>
        /// <param name="blockName">Имя не найденного блока операций.</param>
        #endregion
        public BlockNotFoundException(string blockName)
            : base($"Блок '{blockName}' не найден в реестре.\nУказанный блок операций не создан!")
        {
            // Инициализация свойства с именем не найденного блока
            BlockName = blockName;
        }
    }
}