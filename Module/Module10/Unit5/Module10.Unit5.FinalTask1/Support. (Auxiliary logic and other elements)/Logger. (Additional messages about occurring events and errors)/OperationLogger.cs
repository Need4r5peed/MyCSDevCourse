using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Класс регистрации событий для математических операций"
    /// <summary>
    /// Класс регистрации событий для математических операций.
    /// <para>Реализует интерфейс <see cref="ILogger"/> для логирования событий и ошибок, связанных с операциями <see cref="IMathOperation"/>:</para>
    /// <list type="bullet">
    ///   <item><description>Предоставляет свойство для указания типа регистратора.</description></item>
    ///   <item><description>Обеспечивает вывод сообщений о событиях и ошибках в консоль с цветовым форматированием.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public class OperationLogger : ILogger
    {
        #region Property Description "Тип регистратора событий"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Type"/> | Тип регистратора событий.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Свойство.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Публичное свойство строкового типа <see cref="string"/>, которое:</para>
        /// <list type="number">
        ///   <item><description>Хранит тип регистратора, возвращая значение из <see cref="LoggerTypes.Operation"/>.</description></item>
        ///   <item><description>Предоставляет доступ только для чтения.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public string Type => LoggerTypes.Operation; // Возвращает тип регистратора для операций

        #region Method Description "Регистрация события об ошибках в системе"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Error"/> | Регистрация события об ошибках в системе.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод не возвращающего типа, реализующий вывод сообщения об ошибке в консоль:</para>
        /// <list type="number">
        ///   <item><description>Устанавливает цвет текста и фона для выделения ошибки.</description></item>
        ///   <item><description>Выводит информацию о времени, операции и сообщении об ошибке.</description></item>
        ///   <item><description>Сбрасывает настройки консоли и очищает буфер вывода.</description></item>
        /// </list>
        /// </summary>
        /// <param name="nameOperation">Строковый параметр типа <see cref="string"/>, представляющий название операции.</param>
        /// <param name="messageError">Строковый параметр типа <see cref="string"/>, содержащий сообщение об ошибке в системе.</param>
        #endregion
        public void Error(
            string nameOperation, 
            string messageError)
        {
            // Установка цветового оформления для ошибки
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            // Вывод сообщения об ошибке
            Console.WriteLine(
                $"Reaction Time: {DateTime.Now},\n" +
                $"Name Operation: {nameOperation},\n" +
                $"Error message: {messageError}.");
            // Сброс цветового оформления
            Console.ResetColor();
            // Очистка буфера вывода
            Console.Out.Flush();
        }

        #region Method Description "Регистрация события о работе системы"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Event"/> | Регистрация события о работе системы.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод не возвращающего типа, реализующий вывод сообщения о событии в консоль:</para>
        /// <list type="number">
        ///   <item><description>Устанавливает цвет текста и фона для выделения события.</description></item>
        ///   <item><description>Выводит информацию о времени, операции и сообщении о событии.</description></item>
        ///   <item><description>Сбрасывает настройки консоли и очищает буфер вывода.</description></item>
        /// </list>
        /// </summary>
        /// <param name="nameOperation">Строковый параметр типа <see cref="string"/>, представляющий название операции.</param>
        /// <param name="messageEvent">Строковый параметр типа <see cref="string"/>, содержащий сообщение о событии в системе.</param>
        #endregion
        public void Event(
            string nameOperation, 
            string messageEvent)
        {
            // Установка цветового оформления для события
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            // Вывод сообщения о событии
            Console.WriteLine(
                $"Reaction Time: {DateTime.Now},\n" +
                $"Name Operation: {nameOperation},\n" +
                $"Operation Event: {messageEvent}.");
            // Сброс цветового оформления
            Console.ResetColor();
            // Очистка буфера вывода
            Console.Out.Flush();
        }
    }
}