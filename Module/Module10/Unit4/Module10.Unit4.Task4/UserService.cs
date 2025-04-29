using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit4.Task4
{
    class UserService <T>:
        IUpdater<T> where T : User, new()

    {
        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
