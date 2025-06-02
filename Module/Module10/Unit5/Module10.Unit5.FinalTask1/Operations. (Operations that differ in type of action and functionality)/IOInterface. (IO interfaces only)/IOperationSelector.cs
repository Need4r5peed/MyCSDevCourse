using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ParameterOrder;

namespace Module10.Unit5.FinalTask1
{
    /// <summary>
    /// Интерфейс для управления выбором процедур калькулятора
    /// </summary>
    public interface IOperationSelector
    {
        //Контракты на методы:

        /// <summary>
        /// <para>● Название элеиента:</para>
        /// <para><see cref="BlockSelection"/> |
        /// "Выбор блока математических операций".</para>
        /// 
        /// <para>● Тип элемента:</para> 
        /// <para>контракт метода.</para>
        /// 
        /// <para>● Концепция, описание, принцип работы элемента:</para>
        /// <para>Метод возвращающего типа, который должен будет выполнять:</para> 
        /// <list type="number">
        ///    <item><description>процедуру по выбору блока;</description></item>
        ///    <item><description>возврат выбранного блока операций.</description></item>
        /// </list> 
        /// 
        /// </summary>
        /// 
        /// <param name="~">
        /// <para>Входных параметров не имеет</para>
        /// </param>
        /// 
        /// <returns>Результат выбранных и найденных данных соответствующего типа <see cref="OperationBlock"/></returns>
        OperationBlock BlockSelection();

        /// <summary>
        /// <para>● Название элеиента:</para>
        /// <para><see cref="OperationSelection"/> |
        /// "Выбор математической операции".</para>
        /// 
        /// <para>● Тип элемента:</para> 
        /// <para>контракт метода.</para>
        /// 
        /// <para>● Концепция, описание, принцип работы элемента:</para>
        /// <para>Метод возвращающего типа, который должен будет выполнять:</para> 
        /// <list type="number">
        ///    <item><description>приём параметра;</description></item>
        ///    <item><description>процедуру по выбору операции;</description></item>
        ///    <item><description>возврат выбранной операции.</description></item>
        /// </list> 
        /// 
        /// </summary>
        /// 
        /// <param name="block">
        /// <para><c>-</c> единственный параметр, запрашивающий данные о "Блоке математических операций" типа <see cref="OperationBlock"/>.</para>
        /// </param>
        /// 
        /// <returns>Результат выбранных и найденных данных соответствующего типа <see cref="IMathOperation"/></returns>
        IMathOperation OperationSelection(OperationBlock block);

        /// <summary>
        /// <para>● Название элеиента:</para>
        /// <para><see cref="ArgSelection"/> |
        /// "Выбор аргументов".</para>
        /// 
        /// <para>● Тип элемента:</para> 
        /// <para>контракт метода.</para>
        /// 
        /// <para>● Концепция, описание, принцип работы элемента:</para>
        /// <para>Метод возвращающего типа, который должен будет выполнять:</para> 
        /// <list type="number">
        ///    <item><description>приём параметра;</description></item>
        ///    <item><description>процедуру по выбору аргументов;</description></item>
        ///    <item><description>возврат выбранных аргументов.</description></item>
        /// </list> 
        /// 
        /// </summary>
        /// 
        /// <param name="operation">
        /// <para><c>-</c> единственный параметр, запрашивающий данные о "Математической операции" типа <see cref="IMathOperation"/>.</para>
        /// </param>
        /// 
        /// <returns>Результат выбранных и найденных данных соответствующего типа <see cref="double[]"/></returns>
        double[] ArgSelection(IMathOperation operation);

        /// <summary>
        /// <para>● Название элеиента:</para>
        /// <para><see cref="ArgSelection"/> |
        /// "Выбор варианта сохранения результата вычислений прошедшей математечской операции".</para>
        /// 
        /// <para>● Тип элемента:</para> 
        /// <para>контракт метода.</para>
        /// 
        /// <para>● Концепция, описание, принцип работы элемента:</para>
        /// <para>Метод возвращающего типа, который должен будет выполнять:</para> 
        /// <list type="number">
        ///    <item><description>приём двух параметров;</description></item>
        ///    <item><description>процедуру по выбору варианта сохранения;</description></item>
        ///    <item><description>возврат выбранного варианта, а также одного из параметров.</description></item>
        /// </list> 
        /// 
        /// </summary>
        /// 
        /// <param name="result">
        /// <para><c>-</c> 1-й параметр, запрашивающий данные о "Результате операции" типа <see cref="double"/>.</para>
        /// </param>
        /// <param name="counter">
        /// <para><c>-</c> 2-й параметр, запрашивающий данные о "Номере итерации", 
        /// передаваемого поссылке (<see langword="ref"/>), типа <see cref="int"/>.</para>
        /// </param>
        /// 
        /// <returns>Результат выбранных данных соответствующего типа <see cref="string"/>, 
        /// а также данные параметра типа <see langword="ref"/></returns>
        string SavingTheResultSelection(double result, ref int counter);

        /// <summary>
        /// <para>● Название элеиента:</para>
        /// <para><see cref="ShouldContinueSelection"/> |
        /// "Выбор вариант продолжения работы калькулятора".</para>
        /// 
        /// <para>● Тип элемента:</para> 
        /// <para>контракт метода.</para>
        /// 
        /// <para>● Концепция, описание, принцип работы элемента:</para>
        /// <para>Метод возвращающего типа, который должен будет выполнять:</para> 
        /// <list type="number">
        ///    <item><description>приём параметра;</description></item>
        ///    <item><description>процедуру по выбору варианта;</description></item>
        ///    <item><description>возврат выбранного варианта.</description></item>
        /// </list> 
        /// 
        /// </summary>
        /// 
        /// <param name="selectionOutput">
        /// <para><c>-</c> единственный параметр, запрашивающий данные о "Выборе варианта сохранения результата" типа <see cref="string"/>.</para>
        /// </param>
        /// 
        /// <returns>Результат выбранных данных соответствующего типа <see cref="bool"/></returns>
        bool ShouldContinueSelection(string selectionOutput);
    }
}
