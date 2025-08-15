using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ParameterOrder;
using static Module10.Unit5.FinalTask1.PositionСhangingDelegates;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Класс, реализующий операцию сложения чисел"
    /// <summary>
    /// Класс, реализующий операцию сложения чисел.
    /// <para>Реализует интерфейсы <see cref="IMathOperation"/> и <see cref="ISpecializedOperations"/> для:</para>
    /// <list type="bullet">
    ///   <item><description>выполнения сложения чисел с переменным количеством аргументов;</description></item>
    ///   <item><description>предоставления оптимизированных методов для одного и двух аргументов;</description></item>
    ///   <item><description>логирования процесса вычисления.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public class NumericAddition : ISpecializedOperations
    {
        #region Field Description "Реализация интерфейса для логирования событий"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="_logger"/> | Реализация интерфейса для логирования событий.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное (<see langword="private"/>) поле только для чтения (<see langword="readonly"/>).</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Содержит экземпляр класса, реализующего интерфейс <see cref="ILogger"/> для логирования событий и ошибок.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Используется для записи событий, связанных с вычислением операции сложения.</para>
        /// <remarks>
        /// <para><b>ℹ️ Дополнение:</b></para>
        /// <list type="bullet">
        ///   <item><description>Инициализируется через внедрение зависимости в конструкторе.</description></item>
        /// </list>
        /// </remarks>
        /// </summary>
        #endregion
        private readonly ILogger _logger;

        #region Property Description "Название операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Name"/> | Название операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Реализует свойство интерфейса <see cref="IMathOperation"/> для предоставления названия операции.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Возвращает строковое значение "Сложение".</para>
        /// </summary>
        #endregion
        public string Name => "Сложение"; // Возвращает название операции

        #region Property Description "Информация об операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Description"/> | Информация об операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Реализует свойство интерфейса <see cref="IMathOperation"/> для предоставления описания операции.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Возвращает строковое описание "Складывает числа".</para>
        /// </summary>
        #endregion
        public string Description => "Складывает числа"; // Возвращает описание операции

        #region Property Description "Минимальное количество аргументов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="MinArgsCount"/> | Минимальное количество аргументов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Реализует свойство интерфейса <see cref="IMathOperation"/> для указания минимального количества аргументов.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Возвращает значение 1, указывающее минимальное количество аргументов для операции сложения.</para>
        /// </summary>
        #endregion
        public int MinArgsCount => 1; // Возвращает минимальное количество аргументов

        #region Property Description "Максимальное количество аргументов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="MaxArgsCount"/> | Максимальное количество аргументов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Реализует свойство интерфейса <see cref="IMathOperation"/> для указания максимального количества аргументов.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Возвращает значение 2, указывающее максимальное количество аргументов для операции сложения.</para>
        /// </summary>
        #endregion
        public int MaxArgsCount => 2; // Возвращает максимальное количество аргументов

        #region Property Description "Логгер операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Logger"/> | Логгер операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Реализует свойство интерфейса <see cref="ISpecializedOperations"/> для предоставления доступа к логгеру.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Возвращает экземпляр логгера, используемого для записи событий вычисления.</para>
        /// </summary>
        #endregion
        public ILogger Logger => _logger; // Возвращает логгер операции

        #region Constructor Description "Конструктор класса"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para>Конструктор класса <see cref="NumericAddition"/>.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Конструктор.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Инициализирует поле класса через внедрение зависимости.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <list type="number">
        ///   <item><description>Принимает зависимость через параметр конструктора.</description></item>
        ///   <item><description>Присваивает переданную зависимость приватному полю <see cref="_logger"/>.</description></item>
        /// </list>
        /// </summary>
        /// <param name="logger">Экземпляр интерфейса <see cref="ILogger"/> для логирования событий.</param>
        #endregion
        public NumericAddition(ILogger logger)
        {
            // Инициализация логгера через внедрение зависимости
            _logger = logger;
        }

        #region Method Description "Вычисление суммы аргументов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Calculate(double[])"/> | Вычисление суммы аргументов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Метод возвращающего типа, реализующий вычисление суммы чисел:</para>
        /// <list type="number">
        ///   <item><description>Логирует входные аргументы с помощью <see cref="_logger"/>.</description></item>
        ///   <item><description>Проверяет количество аргументов с помощью <see cref="RequiredArgsCountExpertiseException.Expertise"/>.</description></item>
        ///   <item><description>Вычисляет сумму аргументов с помощью <see cref="Enumerable.Sum"/>.</description></item>
        ///   <item><description>Логирует результат вычисления.</description></item>
        ///   <item><description>Возвращает результат суммы типа <see cref="double"/>.</description></item>
        /// </list>
        /// <para><b>ℹ️ Особенности кода:</b></para>
        /// <para>Использует <see cref="Enumerable.Sum"/> для вычисления суммы, что эквивалентно:</para>
        /// <code>
        /// double sum = 0;
        /// foreach (var num in args)
        /// {
        ///     sum += num;
        /// }
        /// return sum;
        /// </code>
        /// </summary>
        /// <param name="args">Массив аргументов типа <see cref="double"/>[] для сложения.</param>
        /// <returns>Результат суммы аргументов типа <see cref="double"/>.</returns>
        /// <exception cref="RequiredArgsCountException">Выбрасывается, если количество аргументов не соответствует диапазону <see cref="MinArgsCount"/>..<see cref="MaxArgsCount"/>.</exception>
        #endregion
        public double Calculate(params double[] args)
        {
            // Логирование входных аргументов
            _logger.Event(nameof(Calculate), $"Вычисление суммы для аргументов: [{string.Join(", ", args)}]");

            // Проверка корректности количества аргументов
            RequiredArgsCountExpertiseException.Expertise(MinArgsCount, MaxArgsCount, args);

            // Вычисление суммы аргументов
            double result = args.Sum();

            // Логирование результата
            _logger.Event(nameof(Calculate), $"Результат: {result}");

            // Возврат результата
            return result;
        }

        #region Method Description "Оптимизированное вычисление для одного аргумента"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Calculate(double)"/> | Оптимизированное вычисление для одного аргумента.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Метод-обёртка, реализующий вычисление для одного аргумента:</para>
        /// <list type="number">
        ///   <item><description>Создаёт массив из одного аргумента с помощью collection expression.</description></item>
        ///   <item><description>Делегирует вычисление основному методу <see cref="Calculate(double[])"/>.</description></item>
        /// </list>
        /// <para><b>ℹ️ Особенности кода:</b></para>
        /// <para>Использует collection expression:</para>
        /// <code>
        /// [arg]
        /// </code>
        /// <para>Эквивалентно:</para>
        /// <code>
        /// new[] { arg }
        /// </code>
        /// </summary>
        /// <param name="arg">Единственный аргумент типа <see cref="double"/>.</param>
        /// <returns>Результат вычисления типа <see cref="double"/>.</returns>
        #endregion
        public double Calculate(double arg)
        {
            // Делегирование вычисления основному методу с одним аргументом
            return Calculate([arg]);
        }

        #region Method Description "Оптимизированное вычисление для двух аргументов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Calculate(double, double)"/> | Оптимизированное вычисление для двух аргументов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Метод-обёртка, реализующий вычисление для двух аргументов:</para>
        /// <list type="number">
        ///   <item><description>Создаёт массив из двух аргументов с помощью collection expression.</description></item>
        ///   <item><description>Делегирует вычисление основному методу <see cref="Calculate(double[])"/>.</description></item>
        /// </list>
        /// <para><b>ℹ️ Особенности кода:</b></para>
        /// <para>Использует collection expression:</para>
        /// <code>
        /// [arg1, arg2]
        /// </code>
        /// <para>Эквивалентно:</para>
        /// <code>
        /// new[] { arg1, arg2 }
        /// </code>
        /// </summary>
        /// <param name="arg1">Первый аргумент типа <see cref="double"/>.</param>
        /// <param name="arg2">Второй аргумент типа <see cref="double"/>.</param>
        /// <returns>Результат вычисления типа <see cref="double"/>.</returns>
        #endregion
        public double Calculate(
            double arg1, 
            double arg2)
        {
            // Делегирование вычисления основному методу с двумя аргументами
            return Calculate([arg1, arg2]);
        }
    }
}