using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    class ProcedureLogger: ILogger
    {

        public void Error(string nameProcedure, string messageError)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(
                $"Reaction Time: {DateTime.Now},\n" +
                $"Name Procedure: {nameProcedure},\n" +
                $"Error message: {messageError}.\n");
            Console.ResetColor();
        }


        public void Event(string nameProcedure, string messageEvent)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(
                $"Reaction Time: {DateTime.Now},\n" +
                $"Name Procedure: {nameProcedure},\n" +
                $"Operation Event: {messageEvent}.\n");
            Console.ResetColor();
        }
    }
}
