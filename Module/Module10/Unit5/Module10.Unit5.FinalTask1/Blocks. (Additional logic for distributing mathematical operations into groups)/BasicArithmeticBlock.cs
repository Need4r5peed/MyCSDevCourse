using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ParameterOrder;
using static Module10.Unit5.FinalTask1.PositionСhangingDelegates;

namespace Module10.Unit5.FinalTask1
{
    /// <summary>
    /// <para>Класс: "Блок базовых арифметических операций"</para>
    /// <para>Выполняет наследование от <see cref="OperationBlock"/></para>
    /// </summary>
    public class BasicArithmeticBlock : OperationBlock
    {
        /// <summary>
        /// 
        /// </summary>
        public override string BlockName => "basic arithmetic";

        /// <summary>
        /// Свойство-словарь
        /// </summary>
        public override Dictionary<string, IMathOperation> Operations { get; } =
            new Dictionary<string, IMathOperation>(StringComparer.OrdinalIgnoreCase)
            {
                ["+"] = new NumericAddition(),
                ["-"] = new NumericSubtraction(),
                // Место ещё для двух операций: умножения и деления.
            };
    }
}
