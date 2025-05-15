using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    /// <summary>
    /// Реализация операций консольного выбора
    /// </summary>
    public class ConsoleOperationSelector : IOperationSelector
    {
        private readonly IWriter _writer;

        public ConsoleOperationSelector(IWriter writer)
        {
            _writer = writer;
        }

        public string SelectOperationBlock()
        {
            _writer.WriteMessage("Выберите и введите название блока операций в консоль:");
            return Console.ReadLine();
        }

        public string SelectOperation(string blockName)
        {
            _writer.WriteMessage($"Выберите в введите название операции из блока '{blockName}':");
            return Console.ReadLine();
        }

        public bool AskForContinue()
        {
            _writer.WriteMessage("Продолжить? (y/n)");
            return Console.ReadLine().ToLower() == "y";
        }
    }
}
