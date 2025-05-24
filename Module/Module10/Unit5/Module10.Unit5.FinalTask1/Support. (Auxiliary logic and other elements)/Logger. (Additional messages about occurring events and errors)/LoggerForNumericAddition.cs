using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public class LoggerForOperation : ILogger
    {

        public void Error(string nameOperation, string messageError)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(
                $"Reaction Time: {DateTime.Now},\n" +
                $"Name Operation: {nameOperation},\n" +
                $"Error message: {messageError}.\n");
            Console.ResetColor();
        }

        public void Event(string nameOperation, string messageEvent)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                $"Reaction Time: {DateTime.Now},\n" +
                $"Name Operation: {nameOperation},\n" +
                $"Operation Event: {messageEvent}.\n");
            Console.ResetColor();
        }
    }
}
