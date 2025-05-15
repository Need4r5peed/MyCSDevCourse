using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public static class OperationNotFoundExpertiseException
    {
        public static void Expertise(
            string operationName,
            OperationBlock block)
        {
            if (!block.Operations.ContainsKey(operationName))
                throw new OperationNotAvailableException(operationName, block.BlockName);
        }
    }
}
