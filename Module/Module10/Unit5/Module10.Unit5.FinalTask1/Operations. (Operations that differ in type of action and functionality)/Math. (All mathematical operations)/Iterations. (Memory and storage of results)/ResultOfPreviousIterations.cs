using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Статический класс для управления результатами предыдущих итераций калькулятора"
    /// <summary>
    /// Статический класс для управления результатами предыдущих итераций калькулятора.
    /// <para>Предназначен для:</para>
    /// <list type="bullet">
    ///   <item><description>хранения результатов вычислений по номерам итераций;</description></item>
    ///   <item><description>очистки памяти результатов;</description></item>
    ///   <item><description>вывода списка сохранённых результатов.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public static class ResultOfPreviousIterations
    {
        #region Field Description "Номер текущей итерации"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="_iterationNumber"/> | Номер текущей итерации.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное (<see langword="private"/>) статическое (<see langword="static"/>) поле.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Хранит номер последней сохранённой итерации.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Обновляется при сохранении результата и сбрасывается при очистке памяти.</para>
        /// </summary>
        #endregion
        private static int _iterationNumber = 0;

        #region Field Description "Хранилище результатов итераций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="_storageByNumbers"/> | Хранилище результатов итераций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Приватное (<see langword="private"/>) статическое (<see langword="static"/>) поле.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Словарь, хранящий результаты вычислений, где ключ — номер итерации, а значение — результат типа <see cref="double"/>.</para>
        /// <para><b>ℹ️ Принцип работы:</b></para>
        /// <para>Используется для сохранения и получения результатов по номеру итерации.</para>
        /// </summary>
        #endregion
        private static Dictionary<int, double> _storageByNumbers = new Dictionary<int, double>();

        #region Method Description "Сохранение результата итерации"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="SavingTheResults"/> | Сохранение результата итерации.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Статический метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Метод, реализующий сохранение результата вычисления для указанной итерации:</para>
        /// <list type="bullet">
        ///   <item><description>Сохраняет результат в словаре <see cref="_storageByNumbers"/> и обновляет номер текущей итерации.</description></item>
        /// </list>
        /// </summary>
        /// <param name="iterationNumber">Номер итерации для сохранения результата.</param>
        /// <param name="result">Результат вычисления типа <see cref="double"/>.</param>
        #endregion
        public static void SavingTheResults(
            int iterationNumber, 
            double result)
        {
            // Сохранение результата в словарь по номеру итерации
            _storageByNumbers[iterationNumber] = result;
            // Обновление номера текущей итерации
            _iterationNumber = iterationNumber;
        }

        #region Method Description "Очистка памяти результатов"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ClearingTheMemory"/> | Очистка памяти результатов.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Статический метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Метод, реализующий очистку всех сохранённых результатов и сброс номера итерации:</para>
        /// <list type="bullet">
        ///   <item><description>Очищает словарь <see cref="_storageByNumbers"/> и сбрасывает <see cref="_iterationNumber"/> до 0.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public static void ClearingTheMemory()
        {
            // Очистка словаря результатов
            _storageByNumbers.Clear();
            // Сброс номера итерации
            _iterationNumber = 0;
        }

        #region Method Description "Вывод списка результатов прошлых итераций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ListingTheResultsOfPastIterations"/> | Вывод списка результатов прошлых итераций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Статический метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Метод, реализующий вывод всех сохранённых результатов в консоль:</para>
        /// <list type="bullet">
        ///   <item><description>Перебирает словарь <see cref="_storageByNumbers"/> и выводит результаты по номерам итераций.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public static void ListingTheResultsOfPastIterations()
        {
            // Вывод заголовка для списка результатов
            Console.WriteLine("Текущее состояние словаря:");
            // Перебор и вывод всех сохранённых результатов
            foreach (var item in _storageByNumbers)
            {
                Console.WriteLine($"Итерация {item.Key}: {item.Value}");
            }
            // Добавление пустой строки для читаемости
            Console.WriteLine();
        }
    }
}