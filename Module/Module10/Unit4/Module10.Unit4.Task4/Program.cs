using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit4.Task4
{
    public class Main_Task1
    {

        public static void Main()
        {
            Console.WriteLine("Hello!");

            IUpdater<User> userServiceInUser1 = new UserService<User>();

            IUpdater<Account> userServiceInUser2 = new UserService<User>();
        }
    }
}
