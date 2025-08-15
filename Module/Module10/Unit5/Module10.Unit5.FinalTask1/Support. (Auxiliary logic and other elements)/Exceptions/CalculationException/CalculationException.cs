using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Исключение, выбрасываемое при ошибке выполнения математической операции"
    /// <summary>
    /// Исключение, выбрасываемое при ошибке выполнения математической операции.
    /// <para>Наследуется от <see cref="Exception"/> и предоставляет функциональность для:</para>
    /// <list type="bullet">
    ///   <item><description>хранения информации об ошибке, аргументах и операции;</description></item>
    ///   <item><description>формирования сообщения об ошибке с указанием деталей.</description></item>
    /// </list>
    /// <remarks>
    /// <para><b>ℹ️ Дополнение:</b></para>
    /// <list type="bullet">
    ///   <item><description>Используется в системе калькулятора для обработки ошибок, возникающих при выполнении арифметических операций, таких как деление на ноль или неверные аргументы.</description></item>
    /// </list>
    /// </remarks>
    /// </summary>
    #endregion
    public class CalculationException : Exception
    {
        #region Property Description "Тип ошибки вычисления"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ErrorType"/> | Тип ошибки вычисления.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Свойство, которое:</para>
        /// <list type="bullet">
        ///   <item><description>Хранит значение перечисления <see cref="CalculationErrorType"/>, указывающее тип ошибки.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public CalculationErrorType ErrorType { get; }

        #region Property Description "Аргументы операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Arguments"/> | Аргументы операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Свойство, которое:</para>
        /// <list type="bullet">
        ///   <item><description>Хранит массив аргументов типа <see cref="double"/>[], переданных в операцию.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public double[] Arguments { get; }

        #region Property Description "Название операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="OperationName"/> | Название операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Свойство, которое:</para>
        /// <list type="bullet">
        ///   <item><description>Хранит строковое название операции, вызвавшей ошибку.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public string OperationName { get; }

        #region Constructor Description "Конструктор класса"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para>Конструктор класса <see cref="CalculationException"/>.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Конструктор.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Инициализирует экземпляр исключения с информацией об ошибке:</para>
        /// <list type="number">
        ///   <item><description>Вызывает базовый конструктор <see cref="Exception"/> с формированием сообщения об ошибке.</description></item>
        ///   <item><description>Инициализирует свойства <see cref="ErrorType"/>, <see cref="OperationName"/> и <see cref="Arguments"/> переданными значениями.</description></item>
        /// </list>
        /// </summary>
        /// <param name="operation">Объект операции типа <see cref="IMathOperation"/>, вызвавшей ошибку.</param>
        /// <param name="args">Массив аргументов типа <see cref="double"/>[], переданных в операцию.</param>
        /// <param name="errorType">Тип ошибки вычисления из перечисления <see cref="CalculationErrorType"/>.</param>
        /// <param name="details">Дополнительные детали ошибки (опционально).</param>
        #endregion
        public CalculationException(
            IMathOperation operation,
            double[] args,
            CalculationErrorType errorType,
            string details = null)
            : base($"Операция '{operation.Name}' завершилась с ошибкой! \nКод: {errorType}. \nДетали: {details}.")
        {
            // Инициализация типа ошибки
            ErrorType = errorType;
            // Инициализация имени операции
            OperationName = operation.Name;
            // Инициализация массива аргументов
            Arguments = args;
        }
    }
}