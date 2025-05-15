using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    /// <summary>
    /// Интерфейс для операций с оптимизированными методами под минимальное количество аргументов
    /// </summary>
    public interface ISpecializedOperations : IMathOperation
    {
        /// <summary>
        /// Оптимизированный расчет для одного аргумента
        /// </summary>
        double Calculate(double arg);

        /// <summary>
        /// Оптимизированный расчет для двух аргументов
        /// </summary>
        double Calculate(double arg1, double arg2);
    }
}
