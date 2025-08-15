using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ParameterOrder;
using static Module10.Unit5.FinalTask1.PositionСhangingDelegates;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Класс блока базовых арифметических операций"
    /// <summary>
    /// Класс блока базовых арифметических операций.
    /// <para>Наследуется от <see cref="OperationBlock"/> и определяет группу базовых арифметических операций:</para>
    /// <list type="bullet">
    ///   <item><description>Формирует словарь доступных операций для блока.</description></item>
    ///   <item><description>Хранит делегат для создания логгеров.</description></item>
    ///   <item><description>Предоставляет название блока и его операции.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public class BasicArithmeticBlock : OperationBlock
    {
        #region Field Description "Фабрика для создания логгеров"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="_loggerFactory"/> | Фабрика для создания логгеров.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное поле.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Поле типа <see cref="Func{string, ILogger}"/>, которое:</para>
        /// <list type="number">
        ///   <item><description>Хранит делегат для создания экземпляров логгеров.</description></item>
        ///   <item><description>Используется при создании операций блока.</description></item>
        /// </list>
        /// </summary>
        #endregion
        private readonly Func<string, ILogger> _loggerFactory; // Делегат для создания логгеров

        #region Constructor Description "Конструктор класса"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para>Конструктор класса <see cref="BasicArithmeticBlock"/>.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Конструктор.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Инициализирует экземпляр класса <see cref="BasicArithmeticBlock"/>:</para>
        /// <list type="number">
        ///   <item><description>Сохраняет делегат для создания логгеров.</description></item>
        ///   <item><description>Инициализирует словарь операций вызовом метода <see cref="CreateOperations"/>.</description></item>
        /// </list>
        /// </summary>
        /// <param name="loggerFactory">Делегат типа <see cref="Func{string, ILogger}"/> для создания логгеров.</param>
        #endregion
        public BasicArithmeticBlock(Func<string, ILogger> loggerFactory)
        {
            // Сохранение делегата для создания логгеров
            _loggerFactory = loggerFactory;
            // Инициализация словаря операций
            Operations = CreateOperations();
        }

        #region Property Description "Название блока операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="BlockName"/> | Название блока операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Переопределённое свойство.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Переопределённое свойство типа <see cref="string"/>, которое:</para>
        /// <list type="number">
        ///   <item><description>Хранит строковое значение названия блока операций.</description></item>
        ///   <item><description>Возвращает фиксированное значение "basic arithmetic".</description></item>
        /// </list>
        /// </summary>
        #endregion
        public override string BlockName => "basic arithmetic"; // Возвращает название блока

        #region Property Description "Реестр математических операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Operations"/> | Реестр математических операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Переопределённое свойство.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Переопределённое свойство типа <see cref="Dictionary{string, IMathOperation}"/>, которое:</para>
        /// <list type="number">
        ///   <item><description>Хранит словарь операций, где ключ — строка, а значение — объект типа <see cref="IMathOperation"/>.</description></item>
        ///   <item><description>Инициализируется в конструкторе через метод <see cref="CreateOperations"/>.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public override Dictionary<string, IMathOperation> Operations { get; } // Словарь операций блока

        #region Method Description "Создание словаря операций."
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="CreateOperations"/> | Создание словаря операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватный метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, создающий и возвращающий словарь операций блока:</para>
        /// <list type="number">
        ///   <item><description>Создаёт словарь с учётом регистра символов (игнорирование).</description></item>
        ///   <item><description>Добавляет операции сложения и вычитания с использованием логгера.</description></item>
        /// </list>
        /// </summary>
        /// <returns>Словарь операций типа <see cref="Dictionary{string, IMathOperation}"/>.</returns>
        #endregion
        private Dictionary<string, IMathOperation> CreateOperations()
        {
            // Создание словаря операций с игнорированием регистра
            return new Dictionary<string, IMathOperation>(StringComparer.OrdinalIgnoreCase)
            {
                // Добавление операции сложения
                ["+"] = new NumericAddition(_loggerFactory("Operation")),
                // Добавление операции вычитания
                ["-"] = new NumericSubtraction(_loggerFactory("Operation")),
                // ["*"] = new NumericMultiplication(_loggerFactory("Operation")),
                // ["/"] = new NumericDivision(_loggerFactory("Operation"))
            };
        }
    }
}