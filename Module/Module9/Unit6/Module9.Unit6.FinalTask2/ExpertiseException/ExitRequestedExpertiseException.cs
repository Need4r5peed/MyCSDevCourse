using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Module9.Unit6.FinalTask2
{
    public static class ExitRequestedExpertiseException
    {
        public static void Expertise(string yourInput)
        {
            if (yourInput.ToLower() == "q" || yourInput.ToLower() == "й")
                throw new ExitRequestedException(yourInput, "выход");
        }
    }
}
