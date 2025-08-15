using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Исключение, выбрасываемое при превышении максимального количества аргументов для математической операции"
    /// <summary>
    /// Исключение, выбрасываемое при превышении максимального количества аргументов для математической операции.
    /// <para>Наследуется от <see cref="FormatException"/> и предоставляет функциональность для:</para>
    /// <list type="bullet">
    ///   <item><description>хранения максимального допустимого количества аргументов;</description></item>
    ///   <item><description>формирования сообщения об ошибке с указанием введённого и допустимого количества аргументов.</description></item>
    /// </list>
    /// <remarks>
    /// <para><b>ℹ️ Дополнение:</b></para>
    /// <list type="bullet">
    ///   <item><description>Используется в системе калькулятора для обработки ошибок, связанных с превышением количества аргументов в операциях, реализующих <see cref="IMathOperation"/>.</description></item>
    /// </list>
    /// </remarks>
    /// </summary>
    #endregion
    public class MaxArgsCountException : FormatException
    {
        #region Property Description "Максимальное количество аргументов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="MaxArgsCount"/> | Максимальное количество аргументов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Свойство, которое:</para>
        /// <list type="bullet">
        ///   <item><description>Хранит целочисленное значение максимального допустимого количества аргументов для операции.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public int MaxArgsCount { get; }

        #region Constructor Description "Конструктор класса"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para>Конструктор класса <see cref="MaxArgsCountException"/>.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Конструктор.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Инициализирует экземпляр исключения с информацией о превышении количества аргументов:</para>
        /// <list type="bullet">
        ///   <item><description>Вызывает базовый конструктор <see cref="FormatException"/> с формированием сообщения об ошибке.</description></item>
        /// </list>
        /// </summary>
        /// <param name="maxArgsCount">Максимальное допустимое количество аргументов.</param>
        /// <param name="yourArgsLength">Фактическое количество переданных аргументов.</param>
        #endregion
        public MaxArgsCountException(
            int maxArgsCount,
            int yourArgsLength) :
            base($"Вы ввели {yourArgsLength} требуется максимум {maxArgsCount} аргументов")
        {
            // Инициализация свойства с максимальным количеством аргументов
            MaxArgsCount = maxArgsCount;
        }
    }
}