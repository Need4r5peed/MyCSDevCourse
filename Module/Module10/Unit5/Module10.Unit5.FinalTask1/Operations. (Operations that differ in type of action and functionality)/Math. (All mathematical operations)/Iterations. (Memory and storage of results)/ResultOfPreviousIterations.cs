using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public static class ResultOfPreviousIterations
    {
        private static int _iterationNumber = 0;
        private static Dictionary<int, double> _storageByNumbers = new Dictionary<int, double>();

        public static void SavingTheResults(int iterationNumber, double result)
        {
            _storageByNumbers[iterationNumber] = result;
            _iterationNumber = iterationNumber;
        }

        public static void ClearingTheMemory()
        {
            _storageByNumbers.Clear();
            _iterationNumber = 0;
        }

        public static void ListingTheResultsOfPastIterations()
        {
            // Показываем текущее состояние словаря
            Console.WriteLine("Текущее состояние словаря:");
            foreach (var item in _storageByNumbers)
            {
                Console.WriteLine($"Итерация {item.Key}: {item.Value}");
            }
            Console.WriteLine();
        }
    }
}
