using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public class NumericAdder : Calculator
    {
        public override double PerformsAnArithmeticOperation(double a, double b)
        {
            return a + b;
        }
    }
}
