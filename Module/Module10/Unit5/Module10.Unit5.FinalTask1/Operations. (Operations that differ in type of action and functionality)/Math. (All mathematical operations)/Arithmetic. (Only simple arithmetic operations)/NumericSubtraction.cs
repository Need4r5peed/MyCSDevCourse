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
    #region Class Description "Класс, реализующий операцию вычитания чисел"
    /// <summary>
    /// Класс, реализующий операцию вычитания чисел.
    /// <para>Реализует интерфейс <see cref="ISpecializedOperations"/> для:</para>
    /// <list type="bullet">
    ///   <item><description>выполнения операции вычитания с переменным количеством аргументов;</description></item>
    ///   <item><description>предоставления оптимизированных методов для одного и двух аргументов;</description></item>
    ///   <item><description>логирования этапов вычисления.</description></item>
    /// </list>
    /// <remarks>
    /// <para><b>ℹ️ Дополнение:</b></para>
    /// <para>В текущей реализации методы выбрасывают исключение <see cref="IncompleteOperationException"/>, так как операция не реализована.</para>
    /// </remarks>
    /// </summary>
    #endregion
    public class NumericSubtraction : ISpecializedOperations
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
        /// <para>Предназначено для записи событий, связанных с вычислением операции вычитания.</para>
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
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Реализует свойство интерфейса <see cref="IMathOperation"/> для предоставления названия операции.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Возвращает строковое значение "Вычитание".</para>
        /// </summary>
        #endregion
        public string Name => "Вычитание";

        #region Property Description "Описание операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Description"/> | Описание операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Реализует свойство интерфейса <see cref="IMathOperation"/> для предоставления описания операции.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Возвращает строковое значение "Вычитает числа".</para>
        /// </summary>
        #endregion
        public string Description => "Вычитает числа";

        #region Property Description "Минимальное количество аргументов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="MinArgsCount"/> | Минимальное количество аргументов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Реализует свойство интерфейса <see cref="IMathOperation"/> для указания минимального количества аргументов.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Возвращает значение 1, указывая, что операция требует минимум один аргумент.</para>
        /// </summary>
        #endregion
        public int MinArgsCount => 1;

        #region Property Description "Максимальное количество аргументов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="MaxArgsCount"/> | Максимальное количество аргументов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Реализует свойство интерфейса <see cref="IMathOperation"/> для указания максимального количества аргументов.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Возвращает значение 2, указывая, что операция поддерживает до двух аргументов.</para>
        /// </summary>
        #endregion
        public int MaxArgsCount => 2;

        #region Property Description "Логгер операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Logger"/> | Логгер операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство только для чтения.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Реализует свойство интерфейса <see cref="ISpecializedOperations"/> для предоставления доступа к логгеру.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Возвращает экземпляр логгера, переданный через конструктор.</para>
        /// </summary>
        #endregion
        public ILogger Logger => _logger;

        #region Constructor Description "Конструктор класса"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para>Конструктор класса <see cref="NumericSubtraction"/>.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Конструктор.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Инициализирует поле класса через внедрение зависимости.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <list type="bullet">
        ///   <item><description>Принимает зависимость через параметр конструктора.</description></item>
        /// </list>
        /// </summary>
        /// <param name="logger">Экземпляр интерфейса <see cref="ILogger"/> для логирования событий.</param>
        #endregion
        public NumericSubtraction(ILogger logger)
        {
            // Инициализация логгера через внедрение зависимости
            _logger = logger;
        }

        #region Method Description "Оптимизированный метод для одного аргумента"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Calculate(double)"/> | Оптимизированный метод для одного аргумента.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Метод возвращающего типа, реализующий перегрузку для одного аргумента:</para>
        /// <list type="bullet">
        ///   <item><description>Выбрасывает исключение <see cref="IncompleteOperationException"/>, так как операция не реализована.</description></item>
        /// </list>
        /// </summary>
        /// <param name="arg">Единственный аргумент типа <see cref="double"/>.</param>
        /// <returns>Не возвращает значение, так как выбрасывает исключение.</returns>
        /// <exception cref="IncompleteOperationException">Выбрасывается, так как операция вычитания не реализована.</exception>
        #endregion
        public double Calculate(double arg)
        {
            // Выброс исключения, так как операция не реализована
            throw new IncompleteOperationException(Name);
        }

        #region Method Description "Оптимизированный метод для двух аргументов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Calculate(double, double)"/> | Оптимизированный метод для двух аргументов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Метод возвращающего типа, реализующий перегрузку для двух аргументов:</para>
        /// <list type="bullet">
        ///   <item><description>Выбрасывает исключение <see cref="IncompleteOperationException"/>, так как операция не реализована.</description></item>
        /// </list>
        /// </summary>
        /// <param name="arg1">Первый аргумент типа <see cref="double"/>.</param>
        /// <param name="arg2">Второй аргумент типа <see cref="double"/>.</param>
        /// <returns>Не возвращает значение, так как выбрасывает исключение.</returns>
        /// <exception cref="IncompleteOperationException">Выбрасывается, так как операция вычитания не реализована.</exception>
        #endregion
        public double Calculate(
            double arg1, 
            double arg2)
        {
            // Выброс исключения, так как операция не реализована
            throw new IncompleteOperationException(Name);
        }

        #region Method Description "Основной метод вычисления вычитания"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Calculate(double[])"/> | Основной метод вычисления вычитания.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Метод возвращающего типа, реализующий вычисление вычитания для переменного количества аргументов:</para>
        /// <list type="bullet">
        ///   <item><description>Выбрасывает исключение <see cref="IncompleteOperationException"/>, так как операция не реализована.</description></item>
        /// </list>
        /// </summary>
        /// <param name="args">Массив чисел типа <see cref="double"/> для вычитания.</param>
        /// <returns>Не возвращает значение, так как выбрасывает исключение.</returns>
        /// <exception cref="IncompleteOperationException">Выбрасывается, так как операция вычитания не реализована.</exception>
        #endregion
        public double Calculate(params double[] args)
        {
            // Выброс исключения, так как операция не реализована
            throw new IncompleteOperationException(Name);
        }
    }
}