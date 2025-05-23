using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public class InvalidArgumentsException : Exception
    {
        public int ExpectedMin { get; }
        public int ExpectedMax { get; }
        public int ActualCount { get; }

        public InvalidArgumentsException(int expectedMin, int expectedMax, int actualCount)
            : base($"Неверное количество аргументов. Ожидается от {expectedMin} до {expectedMax}, получено: {actualCount}")
        {
            ExpectedMin = expectedMin;
            ExpectedMax = expectedMax;
            ActualCount = actualCount;
        }
    }
}
