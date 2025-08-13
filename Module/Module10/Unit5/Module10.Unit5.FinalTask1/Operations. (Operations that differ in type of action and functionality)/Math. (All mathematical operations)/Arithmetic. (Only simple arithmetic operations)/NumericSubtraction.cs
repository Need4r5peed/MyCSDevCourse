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
            throw new IncompleteOperationException(Name);
        }

        public double Calculate(double arg1, double arg2)
        {
            throw new IncompleteOperationException(Name);
        }

        public double Calculate(params double[] args)
        {
            throw new IncompleteOperationException(Name);
        }
    }
}
