using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public abstract class OperationBlock
    {
        /// <summary>
        /// Название блока операций (например, "Арифметические")
        /// </summary>
        public abstract string BlockName { get; }

        /// <summary>
        /// Список операций в этом блоке
        /// </summary>
        public abstract Dictionary<string, IMathOperation> Operations { get; }

        /// <summary>
        /// Проверяет, содержит ли блок указанную операцию
        /// </summary>
        public bool ContainsOperation(string operationName) => Operations.ContainsKey(operationName);
    }
}
