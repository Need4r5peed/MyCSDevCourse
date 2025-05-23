using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public class OperationNotAvailableException : Exception
    {
        public string OperationName { get; }

        public string BlockName { get; }

        public OperationNotAvailableException(string operationName, string blockName)
            : base($"Операция '{operationName}' не доступна в блоке '{blockName}'")
        {
            OperationName = operationName;
            BlockName = blockName;
        }
    }
}
