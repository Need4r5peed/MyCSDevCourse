using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit3.Task1
{
    class FileManager : 
        IWriter, 
        IReader, 
        IMailer
    {
        void IReader.Read()
        {
            throw new NotImplementedException();
        }

        void IMailer.SendEmail()
        {
            throw new NotImplementedException();
        }

        void IWriter.Write()
        {
            throw new NotImplementedException();
        }
    }
}
