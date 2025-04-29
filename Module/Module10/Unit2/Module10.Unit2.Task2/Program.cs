using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit2.Task2
{
    public class Main_Task2
    {

        public static void Main()
        {
            Console.WriteLine("Hello!");

            MyWriter myWriter = new MyWriter();

            ((IWriter)myWriter).Write();
        }
    }
}