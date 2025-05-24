using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public static class CalculationExpertiseException
    {
        public static double Expertise(IMathOperation operation, double[] args, double result)
        {
            if (double.IsInfinity(result))
                throw new CalculationException(operation, args, CalculationErrorType.Overflow, "Слишком большое число.");

            if (double.IsNaN(result))
                throw new CalculationException(operation, args, CalculationErrorType.NaNResult, "Результат не является числом.");

            // Другие проверки...

            return result; // Если всё ок — возвращаем результат
        }
    }
}
