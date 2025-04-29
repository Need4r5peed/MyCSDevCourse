using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit3.Task3
{
    class ElectronicBook :
        IDevice,
        IBook
    {
        void IBook.Read()
        {
            throw new NotImplementedException();
        }

        void IDevice.TurnOff()
        {
            throw new NotImplementedException();
        }

        void IDevice.TurnOn()
        {
            throw new NotImplementedException();
        }
    }
}
