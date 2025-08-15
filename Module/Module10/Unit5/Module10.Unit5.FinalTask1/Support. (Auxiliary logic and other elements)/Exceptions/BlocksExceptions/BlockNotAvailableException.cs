using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Класс исключения, сигнализирующий о недоступности блока операций"
    /// <summary>
    /// Класс исключения, сигнализирующий о недоступности блока операций.
    /// <para>Наследуется от <see cref="Exception"/> и предоставляет функциональность для:</para>
    /// <list type="bullet">
    ///   <item><description>хранения имени недоступного блока;</description></item>
    ///   <item><description>формирования сообщения об ошибке с указанием имени блока.</description></item>
    /// </list>
    /// <remarks>
    /// <para><b>ℹ️ Дополнение:</b></para>
    /// <list type="bullet">
    ///   <item><description>Используется для обработки ошибок, связанных с попыткой доступа к несуществующему или неинициализированному блоку операций.</description></item>
    /// </list>
    /// </remarks>
    /// </summary>
    #endregion
    public class BlockNotAvailableException : Exception
    {
        #region Property Description "Имя недоступного блока"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="BlockName"/> | Имя недоступного блока.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Свойство, которое:</para>
        /// <list type="bullet">
        ///   <item><description>Хранит строковое значение имени блока, вызвавшего исключение.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public string BlockName { get; }

        #region Constructor Description "Конструктор класса"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para>Конструктор класса <see cref="BlockNotAvailableException"/>.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Конструктор.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Конструктор, инициализирующий исключение:</para>
        /// <list type="number">
        ///   <item><description>Принимает имя недоступного блока.</description></item>
        ///   <item><description>Передаёт сообщение об ошибке базовому классу <see cref="Exception"/>.</description></item>
        ///   <item><description>Инициализирует свойство <see cref="BlockName"/>.</description></item>
        /// </list>
        /// </summary>
        /// <param name="blockName">Имя недоступного блока операций.</param>
        #endregion
        public BlockNotAvailableException(string blockName)
            : base($"Блок '{blockName}' не доступен!\nТак как ранее не был создан!")
        {
            // Инициализация свойства с именем блока
            BlockName = blockName;
        }
    }
}