using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    class IncompleteOperationException: Exception
    {
        public IncompleteOperationException(string nameOperation)
            : base($"Операция {nameOperation} не завершена") { }
    }
}
