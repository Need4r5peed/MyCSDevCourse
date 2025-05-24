using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public class CalculationException : Exception
    {
        public CalculationErrorType ErrorType { get; }
        public double[] Arguments { get; }
        public string OperationName { get; }

        public CalculationException(
            IMathOperation operation,
            double[] args,
            CalculationErrorType errorType,
            string details = null)
            : base($"Операция '{operation.Name}' завершилась с ошибкой! \nКод: {errorType}. \nДетали: {details}.")
        {
            ErrorType = errorType;
            OperationName = operation.Name;
            Arguments = args;
        }
    }
}
