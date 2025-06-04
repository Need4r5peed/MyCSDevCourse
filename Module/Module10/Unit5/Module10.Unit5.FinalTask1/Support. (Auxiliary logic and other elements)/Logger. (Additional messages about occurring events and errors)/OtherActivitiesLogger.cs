using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    class OtherActivitiesLogger: ILogger
    {

        public void Error(string nameActivities, string messageError)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(
                $"Reaction Time: {DateTime.Now},\n" +
                $"Name [OTHER] Activities: {nameActivities},\n" +
                $"Error message: {messageError}.\n");
            Console.ResetColor();
        }


        public void Event(string nameActivities, string messageEvent)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(
                $"Reaction Time: {DateTime.Now},\n" +
                $"Name [OTHER] Activities: {nameActivities},\n" +
                $"Operation Event: {messageEvent}.\n");
            Console.ResetColor();
        }
    }
}
