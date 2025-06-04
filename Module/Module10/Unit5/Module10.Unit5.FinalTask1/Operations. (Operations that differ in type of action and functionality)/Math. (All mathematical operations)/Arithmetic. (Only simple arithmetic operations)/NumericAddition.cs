using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ParameterOrder;
using static Module10.Unit5.FinalTask1.PositionСhangingDelegates;

namespace Module10.Unit5.FinalTask1
{


    public class NumericAddition : ISpecializedOperations
    {

        // Поля и свойства:
        //
        //

        /// <summary>
        /// Название операции
        /// Реализация интерфейса IMathOperation
        /// </summary>
        public string Name => "Сложение";

        /// <summary>
        /// Информация об операции
        /// Реализация интерфейса IMathOperation
        /// </summary>
        public string Description => "Складывает числа";

        /// <summary>
        /// Минимальное количество аргументов для выполнения операции
        /// Реализация интерфейса IMathOperation
        /// </summary>
        public int MinArgsCount => 1;

        /// <summary>
        /// Максимальное количество аргументов для выполнения операции
        /// Реализация интерфейса IMathOperation
        /// </summary>
        public int MaxArgsCount => 2;

        private readonly ILogger _logger;

        public NumericAddition(ILogger logger)
        {
            _logger = logger;
        }

        public ILogger Logger => _logger;

        // Главный метод:
        //
        //

        /// <summary>
        /// <para>Основной метод вычисления для любого количества аргументов</para>
        /// <para>Реализация IMathOperation</para>
        /// <para>Под капотом args.Sum:</para>
        /// <code>
        /// double sum = 0
        /// foreach (var num in args)
        /// {
        ///     sum += num;
        /// }
        /// return sum
        /// </code>
        /// </summary>
        public double Calculate(params double[] args)
        {
            _logger.Event(nameof(Calculate), $"Вычисление суммы для аргументов: [{string.Join(", ", args)}]");

            RequiredArgsCountExpertiseException.Expertise(MinArgsCount, MaxArgsCount, args);

            double result = args.Sum();

            _logger.Event(nameof(Calculate), $"Результат: {result}");

            return result;
        }

        // Методы-перегрузки:

        // Реализация обвёрток (шаблон делегирование вызова основному методу) с использованием перегрузки методов (method overloading) -
        // для некой "условной конструкции" (статического разрешения пепегрузок) в выборе последовательности выполнения - от наиболее
        // специфичного (с 1-м параметром) к менее специфичному (с наибольшим количеством параметров):

        /// <summary>
        /// Оптимизированный метод-обвёртка для одного аргумента
        /// <para>Реализация ISpecializedOperations</para>
        /// <para>Особенности кода:</para>
        /// <code>
        /// Сокращение "collection expressions":
        /// [arg]
        /// - это аналог выражения:
        /// new[] { arg }
        /// </code>
        /// </summary>
        public double Calculate(double arg) => Calculate([arg]);

        /// <summary>
        /// Оптимизированный метод-обвёрка для 2-х аргументов
        /// <para>Реализация ISpecializedOperations</para>
        /// <para>Особенности кода:</para>
        /// <para>Сокращение "collection expressions":</para>
        /// <code>
        /// [arg1, arg2]
        /// </code>
        /// <para>- это аналог выражения:</para>
        /// <code>
        /// new[] { arg1, arg2 }
        /// </code>
        /// </summary>
        public double Calculate(double arg1, double arg2) => Calculate([arg1, arg2]);
    }
}
