using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
   public class PositionСhangingDelegates
    {
        //Функции, меняющие порядок аргументов

        public static Func<double, double, (double, double)> PositionAB = (a, b) => (a, b);
        public static Func<double, double, (double, double)> PositionBA = (a, b) => (b, a);
        public static Func<double, double, double, (double, double, double)> PositionABC = (a, b, c) => (a, b, c);
        public static Func<double, double, double, (double, double, double)> PositionACB = (a, b, c) => (a, c, b);
        public static Func<double, double, double, (double, double, double)> PositionBAC = (a, b, c) => (b, a, c);
        public static Func<double, double, double, (double, double, double)> PositionBCA = (a, b, c) => (b, c, a);
        public static Func<double, double, double, (double, double, double)> PositionCAB = (a, b, c) => (c, a, b);
        public static Func<double, double, double, (double, double, double)> PositionCBA = (a, b, c) => (c, b, a);
    }
}
