using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ParameterOrder;
using static Module10.Unit5.FinalTask1.OperationType;

namespace Module10.Unit5.FinalTask1
{
    /// <summary>
    /// Интерфейс для операций вывода данных | выводит результаты и информацию
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Контракт на вывод результата вычисления
        /// </summary>
        /// <param name="result">Результат решения | дробное число типа double</param>
        void WriteResult(double result);

        /// <summary>
        /// Контракт на вывод сообщения об ошибке
        /// </summary>
        /// <param name="message">Текст ошибки | строковое значение</param>
        void WriteError(string message);

        /// <summary>
        /// Контракт на вывод информационного сообщения
        /// </summary>
        /// <param name="message">Текст сообщения | строковое значение</param>
        void WriteMessage(string message);

        /// <summary>
        /// Контракт на вывод списока доступных операций.
        /// <para>Основано на интерфейсах:</para>
        /// <code>
        /// public interface IEnumerable&lt;out T&gt; 
        /// {
        ///     IEnumerator&lt;T&gt; GetEnumerator();
        /// }
        /// 
        /// public interface IEnumerator&lt;out T&gt; 
        /// {
        ///     T Current { get; }
        ///     bool MoveNext();
        ///     void Reset(); // Устарел
        /// }
        /// </code>
        /// <para>Компилятор преобразует foreach в:</para>
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
        /// <param name="operations">
        /// <para>Перебираемая коллекция элементов типа OperationType</para>
        /// <para><c>IEnumerable&lt;T&gt;</c> — интерфейс перечислимой коллекции</para>
        /// <para><c>&lt;OperationType&gt;</c> — enum-тип элементов "Тип операций"</para>
        /// <para><c>operations</c> — имя параметра "список операций"</para>
        /// </param>
        void WriteAvailableOperations(IEnumerable<OperationType> operations);

        void WriteAvailableOperations(IEnumerable<string> operationNames);

        void WriteAvailableBlocks(IEnumerable<string> blockNames);

        public double CalculateAndDisplayResult(IMathOperation operation, double[] args);
    }
}
