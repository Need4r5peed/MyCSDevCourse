using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ParameterOrder;

namespace Module10.Unit5.FinalTask1
{
    #region Interface Description "Интерфейс, определяющий контракт для выполнения арифметических операций"
    /// <summary>
    /// Интерфейс, определяющий контракт для выполнения арифметических операций.
    /// <para>Предоставляет свойства и методы для:</para>
    /// <list type="bullet">
    ///   <item><description>указания названия и описания операции;</description></item>
    ///   <item><description>определения минимального и максимального количества аргументов;</description></item>
    ///   <item><description>предоставления логгера для записи событий;</description></item>
    ///   <item><description>вычисления результата математической операции.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public interface IMathOperation
    {
        #region Property Description "Название операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Name"/> | Название операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Контракт на свойство, которое должно:</para>
        /// <list type="bullet">
        ///   <item><description>хранить строковое значение с названием операции;</description></item>
        ///   <item><description>обеспечивать доступ для получения этого значения.</description></item>
        /// </list>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Предоставляет уникальное название операции для идентификации в пользовательском интерфейсе.</para>
        /// </summary>
        #endregion
        string Name { get; }

        #region Property Description "Описание операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Description"/> | Описание операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Контракт на свойство, которое должно:</para>
        /// <list type="bullet">
        ///   <item><description>хранить строковое значение с описанием операции для пользователя;</description></item>
        ///   <item><description>обеспечивать доступ для получения этого значения.</description></item>
        /// </list>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Предоставляет описание операции для информирования пользователя о её назначении.</para>
        /// </summary>
        #endregion
        string Description { get; }

        #region Property Description "Минимальное количество аргументов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="MinArgsCount"/> | Минимальное количество аргументов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Контракт на свойство, которое должно:</para>
        /// <list type="bullet">
        ///   <item><description>хранить целочисленное значение минимального количества аргументов;</description></item>
        ///   <item><description>обеспечивать доступ для получения этого значения.</description></item>
        /// </list>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Определяет минимальное количество аргументов, необходимых для выполнения операции.</para>
        /// </summary>
        #endregion
        int MinArgsCount { get; }

        #region Property Description "Максимальное количество аргументов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="MaxArgsCount"/> | Максимальное количество аргументов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Контракт на свойство, которое должно:</para>
        /// <list type="bullet">
        ///   <item><description>хранить целочисленное значение максимального количества аргументов;</description></item>
        ///   <item><description>обеспечивать доступ для получения этого значения.</description></item>
        /// </list>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Определяет максимальное количество аргументов, допустимых для выполнения операции.</para>
        /// </summary>
        #endregion
        int MaxArgsCount { get; }

        #region Property Description "Логгер для записи событий"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Logger"/> | Логгер для записи событий.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Контракт на свойство, которое должно:</para>
        /// <list type="bullet">
        ///   <item><description>предоставлять доступ к экземпляру логгера типа <see cref="ILogger"/>;</description></item>
        ///   <item><description>обеспечивать доступ для получения этого экземпляра.</description></item>
        /// </list>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Позволяет реализующим классам использовать логгер для записи событий, связанных с выполнением операции.</para>
        /// </summary>
        #endregion
        ILogger Logger { get; }

        #region Method Description "Метод вычисления результата операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Calculate"/> | Метод вычисления результата операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Контракт на метод, который должен:</para>
        /// <list type="bullet">
        ///   <item><description>принимать массив аргументов переменной длины типа <see cref="double"/>;</description></item>
        ///   <item><description>вычислять результат математической операции;</description></item>
        ///   <item><description>возвращать результат типа <see cref="double"/>.</description></item>
        /// </list>
        /// <para><b>ℹ️ Особенности кода:</b></para>
        /// <para>Использует ключевое слово <c>params</c> для поддержки переменного количества аргументов:</para>
        /// <code>
        /// params double[] args
        /// </code>
        /// </summary>
        /// <param name="args">
        /// Массив аргументов типа <see cref="double"/> для выполнения математической операции.
        /// <para><b>ℹ️ Подробности:</b></para>
        /// <list type="bullet">
        ///   <item><description><c>params</c> — позволяет передавать переменное количество аргументов.</description></item>
        ///   <item><description><c>double[]</c> — массив дробных чисел.</description></item>
        ///   <item><description><c>args</c> — имя параметра, обозначающее аргументы операции.</description></item>
        /// </list>
        /// </param>
        /// <returns>Результат математической операции типа <see cref="double"/>.</returns>
        #endregion
        double Calculate(params double[] args);
        
    }
}