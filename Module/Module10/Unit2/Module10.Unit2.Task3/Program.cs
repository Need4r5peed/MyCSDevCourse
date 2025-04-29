using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Module10.Unit2.Task3
{
    public class Main_Task2
    {

        public static void Main()
        {
            Console.WriteLine("Hello!");

            //Task3 + Task4

            MyWorker2 myWorker2 = new MyWorker2();
            ((IWorker)myWorker2).Build();
        }
    }
}
