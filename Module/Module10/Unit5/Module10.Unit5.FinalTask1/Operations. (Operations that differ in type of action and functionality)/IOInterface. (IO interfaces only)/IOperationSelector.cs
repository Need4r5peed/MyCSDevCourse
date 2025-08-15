using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ParameterOrder;

namespace Module10.Unit5.FinalTask1
{
    #region Interface Description "Интерфейс для управления выбором процедур калькулятора"
    /// <summary>
    /// Интерфейс для управления выбором процедур калькулятора.
    /// <para>Определяет контракты для выбора блоков операций, математических операций, аргументов и вариантов сохранения результатов:</para>
    /// <list type="bullet">
    ///   <item><description>Обеспечивает выбор блока операций и конкретной операции.</description></item>
    ///   <item><description>Позволяет выбирать аргументы для операций.</description></item>
    ///   <item><description>Управляет сохранением результатов и продолжением работы калькулятора.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public interface IOperationSelector
    {
        #region Method Description "Выбор блока математических операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="BlockSelection"/> | Выбор блока математических операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод возвращающего типа, предназначенный для выбора блока операций:</para>
        /// <list type="number">
        ///   <item><description>Выполняет процедуру выбора блока операций.</description></item>
        ///   <item><description>Возвращает выбранный блок операций.</description></item>
        /// </list>
        /// </summary>
        /// <returns>Выбранный блок операций типа <see cref="OperationBlock"/>.</returns>
        #endregion
        OperationBlock BlockSelection();

        #region Method Description "Выбор математической операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="OperationSelection"/> | Выбор математической операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод возвращающего типа, предназначенный для выбора математической операции:</para>
        /// <list type="number">
        ///   <item><description>Принимает параметр, представляющий блок операций.</description></item>
        ///   <item><description>Выполняет процедуру выбора операции.</description></item>
        ///   <item><description>Возвращает выбранную операцию.</description></item>
        /// </list>
        /// </summary>
        /// <param name="block">Блок математических операций типа <see cref="OperationBlock"/>.</param>
        /// <returns>Выбранная математическая операция типа <see cref="IMathOperation"/>.</returns>
        #endregion
        IMathOperation OperationSelection(OperationBlock block);

        #region Method Description "Выбор аргументов для операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ArgSelection"/> | Выбор аргументов для операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод возвращающего типа, предназначенный для выбора аргументов для операции:</para>
        /// <list type="number">
        ///   <item><description>Принимает параметр, представляющий математическую операцию.</description></item>
        ///   <item><description>Выполняет процедуру выбора аргументов.</description></item>
        ///   <item><description>Возвращает массив выбранных аргументов.</description></item>
        /// </list>
        /// </summary>
        /// <param name="operation">Математическая операция типа <see cref="IMathOperation"/>.</param>
        /// <returns>Массив аргументов типа <see cref="double"/>[].</returns>
        #endregion
        double[] ArgSelection(IMathOperation operation);

        #region Method Description "Выбор варианта сохранения результата вычисления"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="SavingTheResultSelection"/> | Выбор варианта сохранения результата вычисления.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод возвращающего типа, предназначенный для выбора варианта сохранения результата:</para>
        /// <list type="number">
        ///   <item><description>Принимает результат операции и номер итерации.</description></item>
        ///   <item><description>Выполняет процедуру выбора варианта сохранения.</description></item>
        ///   <item><description>Возвращает строковое значение выбранного варианта и обновляет номер итерации.</description></item>
        /// </list>
        /// </summary>
        /// <param name="result">Результат операции типа <see cref="double"/>.</param>
        /// <param name="counter">Номер итерации типа <see cref="int"/>, передаваемый по ссылке (<see langword="ref"/>).</param>
        /// <returns>Строковое значение типа <see cref="string"/>, представляющее выбранный вариант сохранения.</returns>
        #endregion
        string SavingTheResultSelection(
            double result, 
            ref int counter);

        #region Method Description "Выбор варианта продолжения работы калькулятора"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ShouldContinueSelection"/> | Выбор варианта продолжения работы калькулятора.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод возвращающего типа, предназначенный для определения продолжения работы калькулятора:</para>
        /// <list type="number">
        ///   <item><description>Принимает параметр, представляющий выбор варианта сохранения результата.</description></item>
        ///   <item><description>Выполняет процедуру выбора продолжения работы.</description></item>
        ///   <item><description>Возвращает булево значение, указывающее, продолжать ли работу.</description></item>
        /// </list>
        /// </summary>
        /// <param name="selectionOutput">Выбор варианта сохранения результата типа <see cref="string"/>.</param>
        /// <returns>Булево значение типа <see cref="bool"/>, указывающее, продолжать ли работу калькулятора.</returns>
        #endregion
        bool ShouldContinueSelection(string selectionOutput);
    }
}