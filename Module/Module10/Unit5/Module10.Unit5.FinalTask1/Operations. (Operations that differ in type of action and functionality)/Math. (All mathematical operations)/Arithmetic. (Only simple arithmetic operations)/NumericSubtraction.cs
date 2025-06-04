using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ParameterOrder;
using static Module10.Unit5.FinalTask1.PositionСhangingDelegates;

namespace Module10.Unit5.FinalTask1
{

    public class NumericSubtraction : ISpecializedOperations
    {

        public string Name => "Вычитание";
        public string Description => "Вычитает числа";
        public int MinArgsCount => 1;

        public int MaxArgsCount => 2;

        private readonly ILogger _logger;

        public NumericSubtraction(ILogger logger)
        {
            _logger = logger;
        }

        public ILogger Logger => _logger;

        public double Calculate(double arg)
        {
            throw new NotImplementedException();
        }

        public double Calculate(double arg1, double arg2)
        {
            throw new NotImplementedException();
        }

        public double Calculate(params double[] args)
        {
            throw new NotImplementedException();
        }

        //public override double PerformsAnArithmeticOperation(double a)
        //{
        //    return -a;
        //}


        //public override double PerformsAnArithmeticOperation(double a, double b, ParameterOrder order = AB)
        //{
        //    var (x, y) = order switch
        //    {
        //        AB => PositionAB(a, b),
        //        BA => PositionBA(a, b),
        //        _ => throw new ArgumentException("Недопустимый порядок для 2 параметров")
        //    };
        //    return x - y;
        //}

        //public override double PerformsAnArithmeticOperation(double a, double b, double c, ParameterOrder order = ABC)
        //{
        //    var (x, y, z) = order switch
        //    {
        //        ABC => PositionABC(a, b, c),
        //        ACB => PositionACB(a, b, c),
        //        BAC => PositionBAC(a, b, c),
        //        BCA => PositionBCA(a, b, c),
        //        CAB => PositionCAB(a, b, c),
        //        CBA => PositionCBA(a, b, c),
        //        _ => throw new ArgumentException("Недопустимый порядок для 3 параметров")
        //    };
        //    return x - y - z;
        //}

        //public override void WritesTheResult(double result, double a, double b, ParameterOrder order = AB)
        //{
        //    //(double x1, double x2, double x3) tuple;
        //    //switch (order)
        //    //{
        //    //    case AB:
        //    //        tuple = (a, b, result);
        //    //        break;
        //    //    case BA:
        //    //        tuple = (b, a, result);
        //    //        break;
        //    //    default:
        //    //        throw new ArgumentException("Недопустимый порядок");
        //    //}
        //    //Console.WriteLine($"Результат вычитания из числа {tuple.x1} число {tuple.x2}: {tuple.x3}");
        //    var (x1, x2, x3) = order switch
        //    {
        //        AB => (a, b, result),
        //        BA => (b, a, result),
        //        _ => throw new ArgumentException("Недопустимый порядок для 2 параметров")
        //    };

        //    Console.WriteLine($"Результат вычитания из числа {x1} числа {x2} является {x3}");
        //}

        //public override void WritesTheResult(double result, double a, double b, double c, ParameterOrder order = ABC)
        //{
        //    var (x1, x2, x3, x4) = order switch
        //    {
        //        ABC => (a, b, c, result),
        //        ACB => (a, c, b, result),
        //        BAC => (b, a, c, result),
        //        BCA => (b, c, a, result),
        //        CAB => (c, a, b, result),
        //        CBA => (c, b, a, result),
        //        _ => throw new ArgumentException("Недопустимый порядок для 3 параметров")
        //    };

        //    Console.WriteLine($"Результатом вычитания из числа {x1} чисел {x2} и {x3} является {x4}.");
        //}
    }
}
