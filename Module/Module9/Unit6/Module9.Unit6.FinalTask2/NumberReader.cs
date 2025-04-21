using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Module9.Unit6.FinalTask2
{
    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number, List<string> list);
        public event NumberEnteredDelegate NumberEnteredEvent;

        internal void Read(List<string> list)
        {

            Console.WriteLine();
            Console.WriteLine("Необходимо ввести значение, либо \"1\", либо \"2\" (если нужно выйти из дальнейшего выполнения задания - введите \"q\")");

            //int number = Convert.ToInt32(Console.ReadLine());
            //if (number != 1 && number != 2) throw new FormatException();
            string input = Console.ReadLine();
            ExitRequestedExpertiseException.Expertise(input);
            EmergencyInputStringOrIntExpertiseException.Expertise(input);
            int number = Convert.ToInt32(input);
            EmergencyInputNumberExpertiseException.Expertise(number);

            NumberEntered(number, list);
        }

        protected virtual void NumberEntered(int number, List<string> list)
        {
            NumberEnteredEvent?.Invoke(number, list);
        }
    }
}
