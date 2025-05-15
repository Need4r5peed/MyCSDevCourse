using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public class ResultOfPreviousIterations
    {
        public int _iterationNumber = 0;
        public Dictionary<int, double> _storageByNumbers = new Dictionary<int, double>();

        public void SavingTheResults(int iterationNumber, double result)
        {
            _storageByNumbers[iterationNumber] = result;
            _iterationNumber = iterationNumber;
        }

        public void ClearingTheMemory()
        {
            _storageByNumbers.Clear();
            _iterationNumber = 0;
        }

        public void ListingTheResultsOfPastIterations(Dictionary<int, double> storageByNumbers)
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
