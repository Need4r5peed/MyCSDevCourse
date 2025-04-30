using Module10.Unit5.FinalTask1.CalculatorInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    /// <summary>
    /// 
    /// </summary>
    
    public abstract class Calculator: ICalculating, IReader
    {
        public abstract double PerformsAnArithmeticOperation(double a, double b);

        public void ReadsTheInput(string a, string b)
        {
            throw new NotImplementedException();
        }
    }
}
