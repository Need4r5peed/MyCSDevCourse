using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Класс "Исключение, выбрасываемое при попытке использовать недоступную операцию в указанном блоке"
    /// <summary>
    /// Исключение, выбрасываемое при попытке использовать недоступную операцию в указанном блоке.
    /// <para>Наследуется от <see cref="Exception"/> и предоставляет функциональность для:</para>
    /// <list type="bullet">
    ///   <item><description>хранения имени недоступной операции и имени блока;</description></item>
    ///   <item><description>формирования сообщения об ошибке с указанием операции и блока.</description></item>
    /// </list>
    /// <remarks>
    /// <para><b>ℹ️ Дополнение:</b></para>
    /// <list type="bullet">
    ///   <item><description>Используется в системе калькулятора для обработки ошибок, связанных с попыткой выполнения операции, не доступной в выбранном блоке операций.</description></item>
    /// </list>
    /// </remarks>
    /// </summary>
    #endregion
    public class OperationNotAvailableException : Exception
    {
        #region Свойство "Имя недоступной операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="OperationName"/> | Имя недоступной операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Свойство, которое:</para>
        /// <list type="bullet">
        ///   <item><description>Хранит строковое значение имени операции, вызвавшей ошибку.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public string OperationName { get; }

        #region Свойство "Имя блока операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="BlockName"/> | Имя блока операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Свойство, которое:</para>
        /// <list type="bullet">
        ///   <item><description>Хранит строковое значение имени блока, в котором операция недоступна.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public string BlockName { get; }

        #region Конструктор класса
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para>Конструктор класса <see cref="OperationNotAvailableException"/>.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Конструктор.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Инициализирует экземпляр исключения с информацией о недоступной операции и блоке:</para>
        /// <list type="number">
        ///   <item><description>Вызывает базовый конструктор <see cref="Exception"/> с формированием сообщения об ошибке.</description></item>
        ///   <item><description>Инициализирует свойства <see cref="OperationName"/> и <see cref="BlockName"/> переданными значениями.</description></item>
        /// </list>
        /// </summary>
        /// <param name="operationName">Имя недоступной операции.</param>
        /// <param name="blockName">Имя блока операций, в котором операция недоступна.</param>
        #endregion
        public OperationNotAvailableException(
            string operationName, 
            string blockName)
            : base($"Операция '{operationName}' не доступна в блоке '{blockName}'")
        {
            // Инициализация имени операции
            OperationName = operationName;
            // Инициализация имени блока
            BlockName = blockName;
        }
    }
}