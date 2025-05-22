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
    /// <para>● Выполняет наследование от <see cref="OperationBlock"/></para>
    /// <para>● Определяет специфику группы математических операций</para>
    /// <para>● Формирует словарь доступных операций для данного блока</para>
    /// </summary>
    public class BasicArithmeticBlock : OperationBlock
    {
        /// <summary>
        /// <para>Переопределение свойства типа <see cref="string"/>, которое выполняет</para>
        /// <para>● хранение строкового значение "Названия блока математических операций"</para>
        /// <para>● доступ для получения этого значения</para>
        /// <para>● присваивается значение по умолчанию</para>
        /// </summary>
        public override string BlockName => "basic arithmetic";

        /// <summary>
        /// <para>Название элемента: Operations | "Реестр математических операций"</para>
        /// <para>Концепция элемента: Переопределение свойства типа <see cref="Dictionary&lt;string, IMathOperation&gt;"/>, 
        /// где <typeparamref name="TKey"/> = <see cref="string"/>, а <typeparamref name="TValue"/> = <see cref="IMathOperation"/>, 
        /// которое выполняет</para>
        /// <para>● хранение словаря"</para>
        /// <para>● доступ для получения содержащихся в словаре Value</para>
        /// <para>● присваивание значения по умолчанию</para>
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
