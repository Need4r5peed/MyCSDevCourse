using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    public interface ILogger
    {
        void Event(string nameOperation, string messageEvent);

        void Error(string nameOperation, string messageError);
    }
}
