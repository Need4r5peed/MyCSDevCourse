using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{ 
    public class MinArgsCountException : FormatException
    {

        public int MinArgsCount { get; }

        public MinArgsCountException(
            int minArgsCount, 
            int yourArgsLength) : 
            base($"Вы ввели {yourArgsLength} требуется минимум {minArgsCount} аргументов")
            => MinArgsCount = minArgsCount;
    }
}
