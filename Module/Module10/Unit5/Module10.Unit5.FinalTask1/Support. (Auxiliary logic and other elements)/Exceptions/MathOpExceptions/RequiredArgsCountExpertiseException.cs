using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    // Класс проверки ввода числа
    public static class RequiredArgsCountExpertiseException
    {
        public static void Expertise(
            int minArgsCount, 
            int maxArgsCount, 
            double[] args)
        {
            if (args.Length < minArgsCount)
                throw new MinArgsCountException(minArgsCount, args.Length);

            if (args.Length > maxArgsCount)
                throw new MinArgsCountException(maxArgsCount, args.Length);
        }

        public static void Expertise(
            double[] args,
            IMathOperation operation)
        {
            if (args.Length < operation.MinArgsCount || args.Length > operation.MaxArgsCount)
            {
                throw new InvalidArgumentsException(
                    operation.MinArgsCount,
                    operation.MaxArgsCount,
                    args.Length);
            }
        }
    }
}
