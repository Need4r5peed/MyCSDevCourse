using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ParameterOrder;

namespace Module10.Unit5.FinalTask1
{
    /// <summary>
    /// Интерфейс для управления выбором операций (меню, навигация)
    /// </summary>
    public interface IOperationSelector
    {
        //Контракты на методы:

        /// <summary>
        /// <para>Контракт метода, которое должен:</para>
        /// <para>1) показывать главное меню</para>
        /// <para>2) возвращать выбранный блок операций</para>
        /// </summary>
        /// <param name="~">
        /// <para>Входных параметров не имеет</para>
        /// <para>● <c>-</c></para>
        /// <para>● <c>-</c></para>
        /// <para>● <c>-</c></para>
        /// </param>
        /// <returns>Реализуемый метод должен возвращать выбранный блок операций строчного типа</returns>
        string BlockSelection();

        OperationBlock BlockSelection(int i);

        /// <summary>
        /// <para>Контракт метода, которое должен:</para>
        /// <para>1) показывать меню операций внутри блока</para>
        /// <para>2) возвращать выбранную операцию</para>
        /// </summary>
        /// <param name="~">
        /// <para>Входных параметров не имеет</para>
        /// <para>● <c>-</c></para>
        /// <para>● <c>-</c></para>
        /// <para>● <c>-</c></para>
        /// </param>
        /// <returns>Реализуемый метод должен возвращать выбранную операцию строчного типа</returns>
        string OperationSelection(string blockName);

        IMathOperation OperationSelection(OperationBlock block);

        double[] ArgSelection(IMathOperation operation);

        string SavingTheResultSelection(double result, ref int counter);

        bool ShouldContinueSelection(string selectionOutput);

        /// <summary>
        /// <para>Контракт метода, которое должен:</para>
        /// <para>1) запрашивать у пользователя дальнейшее действие после вычисления</para>
        /// <para>2) возвращать ответ пользователя</para>
        /// </summary>
        /// <param name="~">
        /// <para>Входных параметров не имеет</para>
        /// <para>● <c>-</c></para>
        /// <para>● <c>-</c></para>
        /// <para>● <c>-</c></para>
        /// </param>
        /// <returns>Реализуемый метод должен возвращать выбор пользователя булевого типа</returns>
        bool AskForContinue();
    }
}
