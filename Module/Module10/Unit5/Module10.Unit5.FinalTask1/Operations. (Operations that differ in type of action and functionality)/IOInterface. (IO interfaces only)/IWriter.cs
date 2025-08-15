using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ParameterOrder;
using static Module10.Unit5.FinalTask1.OperationType;

namespace Module10.Unit5.FinalTask1
{
    #region Interface Description "Интерфейс для вывода данных"
    /// <summary>
    /// Интерфейс для вывода данных.
    /// <para>Определяет контракты для вывода результатов вычислений, сообщений об ошибках, информационных сообщений и списков доступных операций:</para>
    /// <list type="bullet">
    ///   <item><description>Вывод результатов математических операций.</description></item>
    ///   <item><description>Вывод сообщений об ошибках и информационных сообщений.</description></item>
    ///   <item><description>Вывод перечня доступных операций и блоков.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public interface IWriter
    {
        #region Method Description "Вывод результата вычисления"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="WriteResult"/> | Вывод результата вычисления.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод не возвращающего типа, предназначенный для вывода результата математической операции:</para>
        /// <list type="bullet">
        ///   <item><description>Принимает результат вычисления и отображает его.</description></item>
        /// </list>
        /// </summary>
        /// <param name="result">Результат вычисления, дробное число типа <see cref="double"/>.</param>
        #endregion
        void WriteResult(double result);

        #region Method Description "Вывод сообщения об ошибке"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="WriteError"/> | Вывод сообщения об ошибке.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод не возвращающего типа, предназначенный для вывода сообщения об ошибке:</para>
        /// <list type="bullet">
        ///   <item><description>Принимает текстовое сообщение об ошибке и отображает его.</description></item>
        /// </list>
        /// </summary>
        /// <param name="message">Текст сообщения об ошибке, строковое значение типа <see cref="string"/>.</param>
        #endregion
        void WriteError(string message);

        #region Method Description "Вывод информационного сообщения"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="WriteMessage"/> | Вывод информационного сообщения.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод не возвращающего типа, предназначенный для вывода информационного сообщения:</para>
        /// <list type="bullet">
        ///   <item><description>Принимает текстовое информационное сообщение и отображает его.</description></item>
        /// </list>
        /// </summary>
        /// <param name="message">Текст информационного сообщения, строковое значение типа <see cref="string"/>.</param>
        #endregion
        void WriteMessage(string message);

        #region Method Description "Вывод списка доступных операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="WriteAvailableOperations(IEnumerable{OperationType})"/> | Вывод списка доступных операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод не возвращающего типа, предназначенный для вывода перечня доступных операций:</para>
        /// <list type="number">
        ///   <item><description>Принимает перебираемую коллекцию элементов типа <see cref="OperationType"/>.</description></item>
        ///   <item><description>Использует интерфейсы <see cref="IEnumerable{T}"/> и <see cref="IEnumerator{T}"/> для перебора.</description></item>
        ///   <item><description>Компилятор преобразует foreach в цикл с использованием <c>GetEnumerator</c>, <c>MoveNext</c>, и <c>Current</c>.</description></item>
        /// </list>
        /// <para>Пример преобразования foreach:</para>
        /// <code>
        /// var enumerator = operations.GetEnumerator();
        /// try 
        /// {
        ///     while (enumerator.MoveNext())
        ///     {
        ///         var op = enumerator.Current;
        ///         // ... логика вывода
        ///     }
        /// }
        /// finally 
        /// {
        ///     (enumerator as IDisposable)?.Dispose();
        /// }
        /// </code>
        /// </summary>
        /// <param name="operations">Перебираемая коллекция операций типа <see cref="IEnumerable{OperationType}"/>.</param>
        #endregion
        void WriteAvailableOperations(IEnumerable<OperationType> operations);

        #region Method Description "Вывод списка имен операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="WriteAvailableOperations(IEnumerable{string})"/> | Вывод списка имен операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод не возвращающего типа, предназначенный для вывода перечня имен операций:</para>
        /// <list type="number">
        ///   <item><description>Принимает перебираемую коллекцию строковых имен операций.</description></item>
        ///   <item><description>Использует интерфейсы <see cref="IEnumerable{T}"/> и <see cref="IEnumerator{T}"/> для перебора.</description></item>
        ///   <item><description>Выводит имена операций в удобном формате.</description></item>
        /// </list>
        /// </summary>
        /// <param name="operationNames">Перебираемая коллекция имен операций типа <see cref="IEnumerable{string}"/>.</param>
        #endregion
        void WriteAvailableOperations(IEnumerable<string> operationNames);

        #region Method Description "Вывод списка имен блоков операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="WriteAvailableBlocks"/> | Вывод списка имен блоков операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод не возвращающего типа, предназначенный для вывода перечня имен блоков операций:</para>
        /// <list type="number">
        ///   <item><description>Принимает перебираемую коллекцию строковых имен блоков.</description></item>
        ///   <item><description>Использует интерфейсы <see cref="IEnumerable{T}"/> и <see cref="IEnumerator{T}"/> для перебора.</description></item>
        ///   <item><description>Выводит имена блоков в удобном формате.</description></item>
        /// </list>
        /// </summary>
        /// <param name="blockNames">Перебираемая коллекция имен блоков типа <see cref="IEnumerable{string}"/>.</param>
        #endregion
        void WriteAvailableBlocks(IEnumerable<string> blockNames);

        #region Method Description "Вычисление и отображение результата операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="CalculateAndDisplayResult"/> | Вычисление и отображение результата операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, выполняющий вычисление и отображение результата математической операции:</para>
        /// <list type="number">
        ///   <item><description>Принимает объект операции и массив аргументов.</description></item>
        ///   <item><description>Вычисляет результат с использованием метода операции.</description></item>
        ///   <item><description>Отображает результат вычисления.</description></item>
        /// </list>
        /// </summary>
        /// <param name="operation">Объект математической операции типа <see cref="IMathOperation"/>.</param>
        /// <param name="args">Массив аргументов типа <see cref="double"/>[].</param>
        /// <returns>Результат вычисления, дробное число типа <see cref="double"/>.</returns>
        #endregion
        public double CalculateAndDisplayResult(
            IMathOperation operation, 
            double[] args);
    }
}