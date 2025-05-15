using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{

    public class MaxArgsCountException : FormatException
    {
        public int MaxArgsCount { get; }

        public MaxArgsCountException(
            int maxArgsCount, 
            int yourArgsLength) : 
            base($"Вы ввели {yourArgsLength} требуется максимум {maxArgsCount} аргументов")
            => MaxArgsCount = maxArgsCount;
    }
}
