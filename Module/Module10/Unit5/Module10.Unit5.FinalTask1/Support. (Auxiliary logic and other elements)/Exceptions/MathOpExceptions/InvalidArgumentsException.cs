using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Исключение, выбрасываемое при передаче некорректного количества аргументов для математической операции"
    /// <summary>
    /// Исключение, выбрасываемое при передаче некорректного количества аргументов для математической операции.
    /// <para>Наследуется от <see cref="Exception"/> и предоставляет функциональность для:</para>
    /// <list type="bullet">
    ///   <item><description>хранения ожидаемого минимального и максимального количества аргументов, а также фактического количества переданных аргументов;</description></item>
    ///   <item><description>формирования сообщения об ошибке с указанием деталей о количестве аргументов.</description></item>
    /// </list>
    /// <remarks>
    /// <para><b>ℹ️ Дополнение:</b></para>
    /// <list type="bullet">
    ///   <item><description>Используется в системе калькулятора для обработки ошибок, связанных с некорректным количеством аргументов для операций, реализующих <see cref="IMathOperation"/>.</description></item>
    /// </list>
    /// </remarks>
    /// </summary>
    #endregion
    public class InvalidArgumentsException : Exception
    {
        #region Property Description "Ожидаемое минимальное количество аргументов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ExpectedMin"/> | Ожидаемое минимальное количество аргументов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Свойство, которое:</para>
        /// <list type="bullet">
        ///   <item><description>Хранит целочисленное значение минимального количества аргументов, ожидаемого для операции.</description></item>
        ///   <item><description>Предоставляет доступ только для чтения этого значения.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public int ExpectedMin { get; }

        #region Property Description "Ожидаемое максимальное количество аргументов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ExpectedMax"/> | Ожидаемое максимальное количество аргументов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Свойство, которое:</para>
        /// <list type="bullet">
        ///   <item><description>Хранит целочисленное значение максимального количества аргументов, допустимого для операции.</description></item>
        ///   <item><description>Предоставляет доступ только для чтения этого значения.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public int ExpectedMax { get; }

        #region Property Description "Фактическое количество переданных аргументов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ActualCount"/> | Фактическое количество переданных аргументов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Свойство, которое:</para>
        /// <list type="bullet">
        ///   <item><description>Хранит целочисленное значение фактического количества аргументов, переданных в операцию.</description></item>
        ///   <item><description>Предоставляет доступ только для чтения этого значения.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public int ActualCount { get; }

        #region Constructor Description "Конструктор класса"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para>Конструктор класса <see cref="InvalidArgumentsException"/>.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Конструктор.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Инициализирует экземпляр исключения с информацией о некорректном количестве аргументов:</para>
        /// <list type="bullet">
        ///   <item><description>Вызывает базовый конструктор <see cref="Exception"/> с формированием сообщения об ошибке.</description></item>
        ///   <item><description>Инициализирует свойства <see cref="ExpectedMin"/>, <see cref="ExpectedMax"/> и <see cref="ActualCount"/> переданными значениями.</description></item>
        /// </list>
        /// </summary>
        /// <param name="expectedMin">Ожидаемое минимальное количество аргументов.</param>
        /// <param name="expectedMax">Ожидаемое максимальное количество аргументов.</param>
        /// <param name="actualCount">Фактическое количество переданных аргументов.</param>
        #endregion
        public InvalidArgumentsException(
            int expectedMin, 
            int expectedMax, 
            int actualCount)
            : base($"Неверное количество аргументов. Ожидается от {expectedMin} до {expectedMax}, получено: {actualCount}")
        {
            // Инициализация минимального ожидаемого количества аргументов
            ExpectedMin = expectedMin;
            // Инициализация максимального ожидаемого количества аргументов
            ExpectedMax = expectedMax;
            // Инициализация фактического количества аргументов
            ActualCount = actualCount;
        }
    }
}