using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Реализация интерфейса IReader для обработки пользовательского ввода в консоль"
    /// <summary>
    /// Класс обработки пользовательского ввода в консоль.
    /// <para>Реализует интерфейс <see cref="IReader"/> для:</para>
    /// <list type="bullet">
    ///   <item><description>чтения пользовательского ввода для выбора блоков операций;</description></item>
    ///   <item><description>чтения пользовательского ввода для выбора математических операций;</description></item>
    ///   <item><description>чтения числовых аргументов для операций;</description></item>
    ///   <item><description>чтения пользовательских решений о дальнейшем действии.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public class ConsoleReader : IReader
    {
        #region Method Description "Обработка пользовательского ввода — приём аргументов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ReadNumbers"/> | Обработка пользовательского ввода — приём аргументов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод возвращающего типа, реализующий чтение числовых аргументов из консоли:</para>
        /// <list type="number">
        ///   <item><description>Считывает строку пользовательского ввода через <see cref="Console.ReadLine"/>.</description></item>
        ///   <item><description>Разбивает строку на подстроки по пробелам.</description></item>
        ///   <item><description>Преобразует подстроки в числа типа <see cref="double"/>.</description></item>
        ///   <item><description>Возвращает массив чисел типа <see cref="double"/>[].</description></item>
        /// </list>
        /// <para><b>ℹ️ Особенности кода:</b></para>
        /// <code>
        /// input.Split(' ') // Разбивает строку по пробелам, возвращая массив подстрок (<see cref="string"/>[]).
        /// .Select(double.Parse) // Применяет <see cref="double.Parse"/> к каждому элементу, преобразуя строки в числа типа <see cref="double"/> (возвращает <see cref="IEnumerable{T}"/>).
        /// .ToArray() // Преобразует последовательность <see cref="IEnumerable{T}"/> в массив <see cref="double"/>[].
        /// </code>
        /// </summary>
        /// <returns>Массив чисел типа <see cref="double"/>, полученных из пользовательского ввода.</returns>
        /// <exception cref="FormatException">Выбрасывается, если введённые данные не могут быть преобразованы в числа типа <see cref="double"/>.</exception>
        #endregion
        public double[] ReadNumbers()
        {
            // Считывание строки ввода из консоли
            var input = Console.ReadLine();
            // Разбиение строки на подстроки, преобразование в числа и возврат массива
            return input.Split(' ')
                .Select(double.Parse)
                .ToArray();
        }

        #region Method Description "Обработка пользовательского ввода — выбор операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ReadOperationChoice"/> | Обработка пользовательского ввода — выбор операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод возвращающего типа, реализующий чтение строки с названием выбранной операции:</para>
        /// <list type="number">
        ///   <item><description>Считывает строку пользовательского ввода через <see cref="Console.ReadLine"/>.</description></item>
        ///   <item><description>Возвращает введённую строку без дополнительной обработки.</description></item>
        /// </list>
        /// <para><b>ℹ️ Особенности кода:</b></para>
        /// <para>Использует лямбда-выражение для компактной записи:</para>
        /// <code>
        /// => Console.ReadLine();
        /// </code>
        /// <para>Эквивалентно:</para>
        /// <code>
        /// {
        ///     return Console.ReadLine();
        /// }
        /// </code>
        /// </summary>
        /// <returns>Строковое название выбранной математической операции.</returns>
        #endregion
        public string ReadOperationChoice()
        {
            // Считывание строки с названием операции из консоли
            return Console.ReadLine();
        }

        #region Method Description "Обработка пользовательского ввода — выбор блока операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ReadBlockChoice"/> | Обработка пользовательского ввода — выбор блока операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод возвращающего типа, реализующий чтение строки с названием выбранного блока операций:</para>
        /// <list type="number">
        ///   <item><description>Считывает строку пользовательского ввода через <see cref="Console.ReadLine"/>.</description></item>
        ///   <item><description>Возвращает введённую строку без дополнительной обработки.</description></item>
        /// </list>
        /// <para><b>ℹ️ Особенности кода:</b></para>
        /// <para>Использует лямбда-выражение для компактной записи:</para>
        /// <code>
        /// => Console.ReadLine();
        /// </code>
        /// <para>Эквивалентно:</para>
        /// <code>
        /// {
        ///     return Console.ReadLine();
        /// }
        /// </code>
        /// </summary>
        /// <returns>Строковое название выбранного блока операций.</returns>
        #endregion
        public string ReadBlockChoice()
        {
            // Считывание строки с названием блока операций из консоли
            return Console.ReadLine();
        }

        #region Method Description "Обработка пользовательского ввода — выбор действия"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ReadChoice"/> | Обработка пользовательского ввода — выбор действия.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод возвращающего типа, реализующий чтение строки с пользовательским выбором действия:</para>
        /// <list type="number">
        ///   <item><description>Считывает строку пользовательского ввода через <see cref="Console.ReadLine"/>.</description></item>
        ///   <item><description>Возвращает введённую строку без дополнительной обработки.</description></item>
        /// </list>
        /// <para><b>ℹ️ Особенности кода:</b></para>
        /// <para>Использует лямбда-выражение для компактной записи:</para>
        /// <code>
        /// => Console.ReadLine();
        /// </code>
        /// <para>Эквивалентно:</para>
        /// <code>
        /// {
        ///     return Console.ReadLine();
        /// }
        /// </code>
        /// </summary>
        /// <returns>Строковое значение, представляющее пользовательский выбор действия.</returns>
        #endregion
        public string ReadChoice()
        {
            // Считывание строки с пользовательским выбором действия из консоли
            return Console.ReadLine();
        }
    }
}