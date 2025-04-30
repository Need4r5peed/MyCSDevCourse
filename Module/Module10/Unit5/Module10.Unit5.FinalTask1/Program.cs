using Module10.Unit5.FinalTask1.CalculatorClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public class Main_FinalTask1
    {

        public static void Main()
        {
            Console.WriteLine("Hello!");

            //
            Calculator numericAdder = new NumericAdder();
            double result = numericAdder.PerformsAnArithmeticOperation(5, 3); 
            Console.WriteLine(result);
        }
    }
}
