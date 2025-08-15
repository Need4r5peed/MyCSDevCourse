using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Исключение, выбрасываемое при попытке выполнения незавершённой операции"
    /// <summary>
    /// Исключение, выбрасываемое при попытке выполнения незавершённой операции.
    /// <para>Наследуется от <see cref="Exception"/> и предоставляет функциональность для:</para>
    /// <list type="bullet">
    ///   <item><description>формирования сообщения об ошибке с указанием имени незавершённой операции.</description></item>
    /// </list>
    /// <remarks>
    /// <para><b>ℹ️ Дополнение:</b></para>
    /// <list type="bullet">
    ///   <item><description>Используется в системе калькулятора для обработки ошибок, связанных с незавершёнными операциями, такими как вычитание в <see cref="NumericSubtraction"/>.</description></item>
    /// </list>
    /// </remarks>
    /// </summary>
    #endregion
    class IncompleteOperationException : Exception
    {
        #region Constructor Description "Конструктор класса"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para>Конструктор класса <see cref="IncompleteOperationException"/>.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Конструктор.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Инициализирует экземпляр исключения с указанием имени незавершённой операции:</para>
        /// <list type="bullet">
        ///   <item><description>Вызывает базовый конструктор <see cref="Exception"/> с формированием сообщения об ошибке.</description></item>
        /// </list>
        /// </summary>
        /// <param name="nameOperation">Имя операции, которая не была завершена.</param>
        #endregion
        public IncompleteOperationException(string nameOperation)
            : base($"Операция {nameOperation} не завершена")
        {
            // Инициализация базового конструктора с сообщением об ошибке
        }
    }
}