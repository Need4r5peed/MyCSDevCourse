using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Interface Description "Интерфейс для операций с оптимизированными методами для минимального количества аргументов"
    /// <summary>
    /// Интерфейс для операций с оптимизированными методами для минимального количества аргументов.
    /// <para>Наследует <see cref="IMathOperation"/> и расширяет его функциональность для:</para>
    /// <list type="bullet">
    ///   <item><description>предоставления оптимизированных методов вычисления для одного и двух аргументов;</description></item>
    ///   <item><description>обеспечения совместимости с базовыми контрактами арифметических операций.</description></item>
    /// </list>
    /// <remarks>
    /// <para><b>ℹ️ Дополнение:</b></para>
    /// <list type="bullet">
    ///   <item><description>Используется классами, такими как <see cref="NumericAddition"/> и <see cref="NumericSubtraction"/>, для реализации специализированных методов.</description></item>
    /// </list>
    /// </remarks>
    /// </summary>
    #endregion
    public interface ISpecializedOperations : IMathOperation
    {
        #region Method Description "Оптимизированный метод вычисления для одного аргумента"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Calculate(double)"/> | Оптимизированный метод вычисления для одного аргумента.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Контракт на метод, который:</para>
        /// <list type="bullet">
        ///   <item><description>выполняет оптимизированное вычисление математической операции для одного аргумента.</description></item>
        /// </list>
        /// </summary>
        /// <param name="arg">Единственный аргумент типа <see cref="double"/>.</param>
        /// <returns>Результат вычисления типа <see cref="double"/>.</returns>
        #endregion
        double Calculate(double arg);

        #region Method Description "Оптимизированный метод вычисления для двух аргументов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Calculate(double, double)"/> | Оптимизированный метод вычисления для двух аргументов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Контракт на метод, который:</para>
        /// <list type="bullet">
        ///   <item><description>выполняет оптимизированное вычисление математической операции для двух аргументов.</description></item>
        /// </list>
        /// </summary>
        /// <param name="arg1">Первый аргумент типа <see cref="double"/>.</param>
        /// <param name="arg2">Второй аргумент типа <see cref="double"/>.</param>
        /// <returns>Результат вычисления типа <see cref="double"/>.</returns>
        #endregion
        double Calculate(double arg1, double arg2);
    }
}