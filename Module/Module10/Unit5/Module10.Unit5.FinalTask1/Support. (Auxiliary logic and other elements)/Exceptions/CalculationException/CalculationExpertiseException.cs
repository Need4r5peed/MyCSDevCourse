using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Статический класс для проверки корректности результатов математических операций"
    /// <summary>
    /// Статический класс для проверки корректности результатов математических операций.
    /// <para>Предоставляет методы для:</para>
    /// <list type="bullet">
    ///   <item><description>валидации результатов вычислений на корректность;</description></item>
    ///   <item><description>обнаружения ошибок, таких как переполнение или нечисловой результат;</description></item>
    ///   <item><description>проверки специфичных условий для определённых операций.</description></item>
    /// </list>
    /// <remarks>
    /// <para><b>ℹ️ Дополнение:</b></para>
    /// <list type="bullet">
    ///   <item><description>Используется в системе калькулятора для обработки ошибок вычислений, вызванных некорректными результатами операций, реализующих <see cref="IMathOperation"/>.</description></item>
    ///   <item><description>Выбрасывает исключения <see cref="CalculationException"/> или <see cref="IncompleteOperationException"/> при обнаружении ошибок.</description></item>
    /// </list>
    /// </remarks>
    /// </summary>
    #endregion
    public static class CalculationExpertiseException
    {
        #region Method Description "Проверка корректности результата операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Expertise"/> | Проверка корректности результата операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Статический метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Проверяет результат математической операции на корректность:</para>
        /// <list type="number">
        ///   <item><description>Проверяет, является ли результат бесконечностью (<see cref="double.IsInfinity"/>).</description></item>
        ///   <item><description>Проверяет, является ли результат нечислом (<see cref="double.IsNaN"/>).</description></item>
        ///   <item><description>Проверяет специфичные условия для операции вычитания.</description></item>
        ///   <item><description>Возвращает результат, если проверки пройдены успешно.</description></item>
        /// </list>
        /// </summary>
        /// <param name="operation">Операция типа <see cref="IMathOperation"/>, результат которой проверяется.</param>
        /// <param name="args">Массив аргументов типа <see cref="double"/>[], переданных в операцию.</param>
        /// <param name="result">Результат вычисления операции типа <see cref="double"/>.</param>
        /// <returns>Результат вычисления типа <see cref="double"/>, если он корректен.</returns>
        /// <exception cref="CalculationException">Выбрасывается, если результат является бесконечностью или нечислом.</exception>
        /// <exception cref="IncompleteOperationException">Выбрасывается, если операция вычитания не реализована.</exception>
        #endregion
        public static double Expertise(
            IMathOperation operation, 
            double[] args, 
            double result)
        {
            // Проверка на бесконечность результата
            if (double.IsInfinity(result))
                // Выброс исключения при переполнении
                throw new CalculationException(operation, args, CalculationErrorType.Overflow, "Слишком большое число.");

            // Проверка на нечисловой результат
            if (double.IsNaN(result))
                // Выброс исключения при нечисловом результате
                throw new CalculationException(operation, args, CalculationErrorType.NaNResult, "Результат не является числом.");

            // Проверка для операции вычитания
            if (operation.Name == "Вычитание")
                // Выброс исключения для незавершённой операции вычитания
                throw new IncompleteOperationException(operation.Name);

            // Дополнительные проверки могут быть добавлены здесь

            // Возврат корректного результата
            return result;
        }
    }
}