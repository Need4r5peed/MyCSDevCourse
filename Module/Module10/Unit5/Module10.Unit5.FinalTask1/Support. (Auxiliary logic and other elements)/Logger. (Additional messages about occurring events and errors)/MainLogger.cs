using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    class MainLogger: ILogger
    {
        public void Error(string nameOperation, string messageError)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(
                $"Reaction Time: {DateTime.Now},\n" +
                $"Name Step [MAIN]: {nameOperation},\n" +
                $"Error message: {messageError}.\n");
            Console.ResetColor();
        }


        public void Event(string nameOperation, string messageEvent)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(
                $"Reaction Time: {DateTime.Now},\n" +
                $"Name Step [MAIN]: {nameOperation},\n" +
                $"Operation Event: {messageEvent}.\n");
            Console.ResetColor();
        }
    }
}
