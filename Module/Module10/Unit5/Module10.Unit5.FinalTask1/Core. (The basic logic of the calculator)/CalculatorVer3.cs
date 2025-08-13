using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static Module10.Unit5.FinalTask1.ResultOfPreviousIterations;
using System.Diagnostics.Metrics;

namespace Module10.Unit5.FinalTask1
{

    /// <summary>
    /// Основной класс калькулятора. Обрабатывает арифметические и другие операции,
    /// сгруппированные в блоки (OperationBlock).
    /// </summary>
    public class Calculator2
    {
        /// <summary>
        /// Название элеиента: <see cref="_reader"/> | 
        /// "Интерфейс для чтения ввода пользователя".
        /// 
        /// Тип элемента: поле. 
        /// 
        /// </summary>
        private readonly IReader _reader;

        /// <summary>
        /// Название элеиента: <see cref="_writer"/> | 
        /// "Интерфейс для вывода сообщений".
        /// Тип элемента: поле. 
        /// </summary>
        private readonly IWriter _writer;

        /// <summary>
        /// Название элеиента: <see cref="_selector"/> | 
        /// "Интерфейс для выбор операций и аргументов".
        /// Тип элемента: поле. 
        /// </summary>
        private readonly IOperationSelector _selector;

        /// <summary>
        /// Название элеиента: <see cref="_logger"/> | 
        /// "Интерфейс для логирования событий и ошибок".
        /// Тип элемента: поле.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Название элеиента: <see cref="repeatNumber"/> | 
        /// "Cчётчик итераций калькулятора".
        /// Тип элемента: поле.
        /// </summary>
        private int repeatNumber = 0;

        /// <summary>
        /// Название элеиента: <see cref="Calculator"/> | 
        /// "Инициализация необходимых зависимостей калькулятора".
        /// Тип элемента: конструктор.
        /// </summary>
        public Calculator2(
            IReader reader,
            IWriter writer,
            IOperationSelector selector,
            ILogger logger)
        {
            _reader = reader;
            _writer = writer;
            _selector = selector;
            _logger = logger;
            _logger.Event(
                $"\n" +
                $"{nameof(Calculator)}",
                $"Запуск конструктора: зависимости успешно внедрены");
        }

        /// <summary>
        /// Название элеиента: <see cref="Run"/> | 
        /// "Основной цикл работы калькулятора".
        /// Тип элемента: метод.
        /// 
        /// <para>● Концепция, описание, принцип работы элемента:</para>
        /// <para>Метод невозвращающего типа, который выполняет:</para> 
        /// <para><c>1)</c> инициализацию счётчика итераций;</para>
        /// <para><c>2)</c> последовательно блоки основных процедур в бесконечном цикле.</para>
        /// <para><c>3)</c> обработку исключения через <see cref = "RetryProcedure{T}" />.</para>
        /// 
        /// <para>● Блоки основных процедур элемента:</para>
        /// <para><c>— Блок #1</c> — Выбор блока математических операций (<see cref="OperationBlock"/>).</para>
        /// <para><c>— Блок #2</c> — Выбор конкретной математической операции (<see cref="IMathOperation"/>).</para>
        /// <para><c>— Блок #3</c> — Вывод результатов прошлых итераций (<see cref="ResultOfPreviousIterations"/>).</para>  
        /// <para><c>— Блок #4</c> — Ввод аргументов и вычисление результата (<see cref="double[]"/>).</para> 
        /// <para><c>— Блок #5</c> — Работа с результатом (<see cref="string"/>).</para> 
        /// <para><c>— Блок #6</c> — Запрос на продолжение (<see cref="bool"/>).</para> 
        /// 
        /// <para>● Условия выхода элемента:</para>
        /// <para><c>—</c> пользователь отказался продолжать (<c>choosing == false</c>).</para>
        /// <para><c>—</c> необработанное исключение (пробрасывается выше).</para>
        /// </summary>
        public void Run()
        {
            _logger.Event(nameof(Run), "Запуск главного while");
            _writer.WriteMessage("Запуск Калькулятора");
            Thread.Sleep(1000);

            while (true)
            {
                repeatNumber += 1;
                _logger.Event(nameof(Run), $"Итерация: №{repeatNumber}");
                _writer.WriteMessage($"Итерация: №{repeatNumber}");
                Thread.Sleep(1000);

                // Блок 1: Выбор блока операций
                OperationBlock block = RetryProcedure(
                    () => _selector.BlockSelection(),
                    nameof(_selector.BlockSelection),
                    "Выбор блока операций"
                );

                // Блок 2: Выбор операции
                IMathOperation operation = RetryProcedure(
                    () => _selector.OperationSelection(block),
                    nameof(_selector.OperationSelection),
                    "Выбор операции"
                );

                // Блок 3: Вывод прошлых результатов
                if (repeatNumber > 1)
                {
                    ListingTheResultsOfPastIterations();
                }

                // Блок 4: Ввод аргументов и вычисление
                double[] args = RetryProcedure(
                    () => _selector.ArgSelection(operation),
                    nameof(_selector.ArgSelection),
                    "Ввод аргументов"
                );

                double result = RetryProcedure(
                    () => _writer.CalculateAndDisplayResult(operation, args),
                    nameof(_writer.CalculateAndDisplayResult),
                    "Вычисление результата"
                );

                // Блок 5: Работа с результатом
                string memory = RetryProcedure(
                    () => _selector.SavingTheResultSelection(result, ref repeatNumber),
                    nameof(_selector.SavingTheResultSelection),
                    "Сохранение результата"
                );

                // Блок 6: Запрос на продолжение
                bool choosing = RetryProcedure(
                    () => _selector.ShouldContinueSelection(memory),
                    nameof(_selector.ShouldContinueSelection),
                    "Запрос на продолжение"
                );

                // Блок 7: Выход из основного цикла
                if (!choosing) break;
            }
        }

        /// <summary>
        /// Название элеиента: <see cref="RetryProcedure"/> | 
        /// "Механизм повторного выполнения основной процедуры с обработкой исключений".
        /// Тип элемента: метод.
        /// 
        /// <para>● Концепция, описание, принцип работы элемента:</para>
        /// <para>Обобщённый (generic) метод возвращающего типа, который выполняет:</para> 
        /// <para><c>1)</c> приём обобщённого и основных параметров;</para>
        /// <para><c>2)</c> базовую процедуру;</para>
        /// <para><c>3)</c> если возникает ожидаемое исключение: логирование + повтор попытки;</para>
        /// <para><c>4)</c> если возникает критическое исключение: логирование + проброс выше;</para> 
        /// <para><c>5)</c> при успешном выполнения базовой процедуры: возврат результата выполненной процедуры.</para>
        /// 
        /// <para>● Составляющие элемента:</para>
        /// <para><c>— RetryProcedure</c> — название метода.</para>
        /// <para><c>— T</c> — тип T возвращаемых данных.</para>
        /// <para><c>— &lt;T&gt;</c> — обобщённый параметр типа T.</para>  
        /// <para><c>— Func&lt;T&gt; basicProcedure</c> — 1-й параметр, 
        /// делегат "Выполняемая основаня роцедура", возвращающий данные типа T</para> 
        /// <para><c>— string procedureName</c> — 2-й параметр "Название основной поцедуры" строкового типа string</para> 
        /// <para><c>— string context</c> — 3-й параметр 
        /// "Конктекст выполнения основной процедуры" строкового типа string</para>  
        /// 
        /// <para>● Условия выхода элемента:</para>
        /// <para><c>—</c> Успешное выполнение операции.</para>
        /// <para><c>—</c> Необрабатываемое исключение.</para>
        /// </summary>
        /// 
        /// <typeparam name="T">Тип возвращаемого значения базовой процедуры.</typeparam>
        /// <param name="basicProcedure">Основная процедура для выполнения.</param>
        /// <param name="procedureName">Название базовой процедуры | Логирование</param>
        /// <param name="context">Дополнительный контекст выполнения базовой процедуры | Логирование</param>
        /// 
        /// <returns>Результат выполнения процедуры типа T</returns>
        private T RetryProcedure<T>(
            Func<T> basicProcedure, 
            string procedureName, 
            string context)
        {
            while (true)
            {
                try
                {
                    return basicProcedure();
                }
                // Обработка исключения о недоступности блока операций с заданным именем
                catch (BlockNotAvailableException ex)
                {
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                }
                // Обработка исключения об отсутствии фабрики в реестре 
                catch (BlockNotFoundException ex)
                {
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                }
                // Обработка исключения при недоступности операции с заданным именем
                catch (OperationNotAvailableException ex)
                {
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                }
                // Обработка исключения при некорректном количестве аргументов
                catch (InvalidArgumentsException ex)
                {
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                }
                // Обработка исключения при ----------------
                catch (IncompleteOperationException ex)
                {
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                    return default(T);
                }
                // Обработка исключения при несоответствии формата ввода
                catch (FormatException ex)
                {
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                }
                // Обработка исключения при неудачном вычислении
                catch (CalculationException ex)
                {
                    CommonConcentratorMoulderOfExceptions(ex, procedureName, context);
                }
                // Обработка исключения при каких-либо других непредвиденных обстоятельствах
                catch (Exception ex)
                {
                    _logger.Error($"Исключение: {ex.GetType().Name},\nГде: {procedureName}", ex.Message);
                    _writer.WriteError($"Критическая ошибка: {ex.Message}");
                    throw; // Пробрасываем выше
                }
            }
        }

        /// <summary>
        /// Название элемента: <see cref="CommonConcentratorMoulderOfExceptions"/> | 
        /// "Общий концентратор, формирующий исключения".
        /// Тип элемента: метод.
        /// 
        /// <para>● Концепция, описание, принцип работы элемента:</para>
        /// <para><c>1.</c> Принимает исключение и контекст выполнения.</para>
        /// <para><c>2.</c> Форматирует сообщение об ошибке по шаблону:</para>
        /// <para><c>— Тип исключения</c></para>
        /// <para><c>— Где возникло</c></para>
        /// <para><c>— Контекст</c></para>
        /// <para><c>— Сообщение</c></para>
        /// <para><c>3.</c> Логирует ошибку через <see cref="_logger"/>.</para>
        /// <para><c>4.</c> Выводит сообщение пользователю через <see cref="_writer"/>.</para>
        /// 
        /// <para>● Ключевые особенности элемента:</para>
        /// <para><c>—</c> Стандартизирует формат сообщений об ошибках.</para>
        /// <para><c>—</c> Изолирует логику обработки исключений.</para>
        /// <para><c>—</c> Поддерживает все типы исключений (ожидаемые и критические).</para>
        /// 
        /// <para>● Состав параметров элемента:</para>
        /// <para><c>ex</c> - исключение для обработки</para>
        /// <para><c>operationName</c> - имя метода, где произошла ошибка</para>
        /// <para><c>context</c> - контекст: этап работы калькулятора</para>
        /// </summary>
        /// <param name="ex">Объект исключения</param>
        /// <param name="procedureName">Название операции (для идентификации в логах)</param>
        /// <param name="context">Контекст выполнения (например, "Выбор блока операций")</param>
        /// 
        /// <remarks>
        /// <para>● Отличия <see cref="CommonConcentratorMoulderOfExceptions"/> 
        /// от <see cref="RetryProcedure{T}"/>:</para>
        /// <para><c>—</c> Не принимает решений о повторе операции.</para>
        /// <para><c>—</c> Не возвращает результат.</para>
        /// <para><c>—</c> Фокусируется только на логировании и уведомлениях.</para>
        /// </remarks>
        private void CommonConcentratorMoulderOfExceptions(Exception ex, string procedureName, string context)
        {
            _logger.Error($"Исключение: {ex.GetType().Name},\nГде: {procedureName}", ex.Message);
            _writer.WriteError(ex.Message);
        }
    }
}

