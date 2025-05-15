using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public class CalculationException : Exception
    {
        public double[] Arguments { get; }

        public CalculationException(double[] args, string message)
            : base(message) => Arguments = args;
    }
}
