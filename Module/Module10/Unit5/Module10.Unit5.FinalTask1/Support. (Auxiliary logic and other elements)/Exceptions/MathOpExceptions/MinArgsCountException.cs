using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Исключение, выбрасываемое при передаче недостаточного количества аргументов для математической операции"
    /// <summary>
    /// Исключение, выбрасываемое при передаче недостаточного количества аргументов для математической операции.
    /// <para>Наследуется от <see cref="FormatException"/> и предоставляет функциональность для:</para>
    /// <list type="bullet">
    ///   <item><description>хранения минимального необходимого количества аргументов;</description></item>
    ///   <item><description>формирования сообщения об ошибке с указанием введённого и минимального количества аргументов.</description></item>
    /// </list>
    /// <remarks>
    /// <para><b>ℹ️ Дополнение:</b></para>
    /// <list type="bullet">
    ///   <item><description>Используется в системе калькулятора для обработки ошибок, связанных с недостаточным количеством аргументов в операциях, реализующих <see cref="IMathOperation"/>.</description></item>
    /// </list>
    /// </remarks>
    /// </summary>
    #endregion
    public class MinArgsCountException : FormatException
    {
        #region Property Description "Минимальное количество аргументов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="MinArgsCount"/> | Минимальное количество аргументов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Свойство, которое:</para>
        /// <list type="number">
        ///   <item><description>Хранит целочисленное значение минимального необходимого количества аргументов для операции.</description></item>
        ///   <item><description>Предоставляет доступ только для чтения этого значения.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public int MinArgsCount { get; }

        #region Constructor Description "Конструктор класса"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para>Конструктор класса <see cref="MinArgsCountException"/>.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Конструктор.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Инициализирует экземпляр исключения с информацией о недостаточном количестве аргументов:</para>
        /// <list type="number">
        ///   <item><description>Вызывает базовый конструктор <see cref="FormatException"/> с формированием сообщения об ошибке.</description></item>
        ///   <item><description>Инициализирует свойство <see cref="MinArgsCount"/> переданным значением.</description></item>
        /// </list>
        /// </summary>
        /// <param name="minArgsCount">Минимальное необходимое количество аргументов для операции.</param>
        /// <param name="yourArgsLength">Фактическое количество переданных аргументов.</param>
        #endregion
        public MinArgsCountException(
            int minArgsCount,
            int yourArgsLength) :
            base($"Вы ввели {yourArgsLength} требуется минимум {minArgsCount} аргументов")
        {
            // Инициализация минимального количества аргументов
            MinArgsCount = minArgsCount;
        }
    }
}