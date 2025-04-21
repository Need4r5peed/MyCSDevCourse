using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Module9.Unit6.FinalTask2
{
    public class ExitRequestedException : FormatException
    {
        public string ExitRequestedInputString { get; }

        public ExitRequestedException(string yourInput, string yourTextOfException) :
            base($"Вы ввели: {yourInput}. Запрос пользователя: {yourTextOfException}!")
            => ExitRequestedInputString = yourInput;
    }
}
