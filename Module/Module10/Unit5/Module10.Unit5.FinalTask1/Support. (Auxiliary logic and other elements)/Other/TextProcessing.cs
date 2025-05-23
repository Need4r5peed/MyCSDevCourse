using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public static class TextProcessing
    {
        public static string ReadWithPrompt(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
    }

    public static class ОбработкаТекста
    {
        public static string ЧитатьВнутриПодсказка(string подсказка)
        {
            Console.WriteLine(подсказка);
            return Console.ReadLine();
        }
    }
}
