using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module9.Unit6.FinalTask1
{
    /// <summary>
    ///     1) Создание своего класса исключений.
    /// </summary>
    public class MyException : Exception
    {
        public MyException() :
            base("^___^")
        { }

        public MyException(string message) :
            base(message)
        { }

        public MyException(string message, Exception innerException) :
            base(message, innerException)
        { }
    }
}
