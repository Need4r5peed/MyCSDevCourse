using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Класс проверки количества введённых аргументов для математических операций"
    /// <summary>
    /// Класс проверки количества введённых аргументов для математических операций.
    /// <para>Класс предоставляет статические методы для проверки соответствия количества аргументов требованиям операции:</para>
    /// <list type="bullet">
    ///   <item><description>Проверяет минимальное и максимальное количество аргументов.</description></item>
    ///   <item><description>Выбрасывает исключения при несоответствии количества аргументов.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public static class RequiredArgsCountExpertiseException
    {
        #region Method Description "Проверка количества аргументов по заданным границам"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Expertise(int, int, double[])"/> | Проверка количества аргументов по заданным границам.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Статический метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод проверяет, соответствует ли количество введённых аргументов заданным минимальному и максимальному значениям:</para>
        /// <list type="number">
        ///   <item><description>Сравнивает длину массива аргументов с минимальным количеством (<paramref name="minArgsCount"/>).</description></item>
        ///   <item><description>Сравнивает длину массива аргументов с максимальным количеством (<paramref name="maxArgsCount"/>).</description></item>
        ///   <item><description>Выбрасывает исключение, если количество аргументов выходит за допустимые границы.</description></item>
        /// </list>
        /// </summary>
        /// <param name="minArgsCount">Минимальное допустимое количество аргументов.</param>
        /// <param name="maxArgsCount">Максимальное допустимое количество аргументов.</param>
        /// <param name="args">Массив введённых аргументов типа <see cref="double"/>[].</param>
        /// <exception cref="MinArgsCountException">Выбрасывается, если количество аргументов меньше <paramref name="minArgsCount"/> или больше <paramref name="maxArgsCount"/>.</exception>
        #endregion
        public static void Expertise(
            int minArgsCount,
            int maxArgsCount,
            double[] args)
        {
            // Проверка на минимальное количество аргументов
            if (args.Length < minArgsCount)
                throw new MinArgsCountException(minArgsCount, args.Length);

            // Проверка на максимальное количество аргументов
            if (args.Length > maxArgsCount)
                throw new MinArgsCountException(maxArgsCount, args.Length);
        }

        #region Method Description "Проверка количества аргументов для операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Expertise(double[], IMathOperation)"/> | Проверка количества аргументов для операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Статический метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод проверяет, соответствует ли количество введённых аргументов требованиям математической операции:</para>
        /// <list type="number">
        ///   <item><description>Получает минимальное и максимальное количество аргументов из объекта операции (<see cref="IMathOperation"/>).</description></item>
        ///   <item><description>Сравнивает длину массива аргументов с допустимыми границами.</description></item>
        ///   <item><description>Выбрасывает исключение, если количество аргументов не соответствует требованиям.</description></item>
        /// </list>
        /// </summary>
        /// <param name="args">Массив введённых аргументов типа <see cref="double"/>[].</param>
        /// <param name="operation">Экземпляр математической операции типа <see cref="IMathOperation"/>.</param>
        /// <exception cref="InvalidArgumentsException">Выбрасывается, если количество аргументов не соответствует требованиям операции.</exception>
        #endregion
        public static void Expertise(
            double[] args,
            IMathOperation operation)
        {
            // Проверка соответствия количества аргументов требованиям операции
            if (args.Length < operation.MinArgsCount || args.Length > operation.MaxArgsCount)
            {
                throw new InvalidArgumentsException(
                    operation.MinArgsCount,
                    operation.MaxArgsCount,
                    args.Length);
            }
        }
    }
}