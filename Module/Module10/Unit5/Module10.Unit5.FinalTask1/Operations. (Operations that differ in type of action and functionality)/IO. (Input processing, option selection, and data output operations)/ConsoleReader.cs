using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    /// <summary>
    /// Класс обработки пользовательского ввода в консоль
    /// </summary>
    public class ConsoleReader : IReader
    {
        /// <summary>
        /// <para>Метод: "Обработка пользовательского ввода — приём аргументов"</para>
        /// <para>Реализация контракта <see cref="IReader"/>.</para>
        /// <para>Особенности кода:</para>
        /// <code>
        /// input.Split(' ') // (1)
        /// .Select(double.Parse) // (2)
        /// .ToArray() // (3)
        /// </code>
        /// <para>1. Разбивает строку по пробелам, возвращая массив подстрок (<see cref="string"/>[]).</para>
        /// <para>2. Применяет <see cref="double.Parse"/> к каждому элементу, преобразуя строки в числа типа <see cref="double"/> (возвращает <see cref="IEnumerable{T}"/>).</para>
        /// <para>3. Преобразует последовательность <see cref="IEnumerable{T}"/> в массив <see cref="double"/>[].</para>
        /// </summary>
        /// <returns>Массив чисел типа <see cref="double"/>, полученных из пользовательского ввода.</returns>
        public double[] ReadNumbers()
        {
            var input = Console.ReadLine();
            return input.Split(' ')
                .Select(double.Parse)
                .ToArray();
        }

        /// <summary>
        /// <para>Метод: "Обработка пользовательского ввода - выбор операции"</para>
        /// <para>Реализация контракта <see cref="IReader"/></para>
        /// <para>Особенности кода:</para>
        /// <para>лямбда-оператор:</para>
        /// <code>
        /// =>
        /// </code>
        /// <para>Выражение:</para>
        /// <code>
        /// => Console.ReadLine();
        /// </code>
        /// <para>Аналогично:</para>
        /// <code>
        /// {
        ///     return Console.ReadLine();
        /// }
        /// </code>
        /// </summary>
        /// <returns>Возвращает строковое название выбранной операции</returns>
        public string ReadOperationChoice() => Console.ReadLine();
    }
}
