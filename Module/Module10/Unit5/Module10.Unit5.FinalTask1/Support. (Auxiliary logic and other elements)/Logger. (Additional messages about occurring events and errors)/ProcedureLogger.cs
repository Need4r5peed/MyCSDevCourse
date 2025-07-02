using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    /// <summary>
    /// Регистрация событий "Для процедрур <see cref="Calculator"/>" через реализацию <see cref="ILogger"/>.
    /// </summary>
    class ProcedureLogger : ILogger
    {
        /// <summary>
        /// <para>● Название элемента:</para>
        /// <para><see cref="Type"/> |
        /// Тип регистратора событий
        /// 
        /// <para>● Тип элемента:</para> 
        /// <para>контракт свойства.</para>
        /// 
        /// <para>● Концепция, описание, принцип работы элемента:</para>
        /// <para>Публичное(<see langword="public"/>) свойство строковго типа <see cref="string"/>, которое:</para> 
        /// <list type="number">
        ///    <item><description>выполняет хранение данных;</description></item>
        ///    <item><description>и предоставляет доступ для чтения этих данных.</description></item>
        /// </list> 
        /// 
        /// </summary>
        public string Type => LoggerTypes.Procedure;

        /// <summary>
        /// <para>● Название элеиента:</para>
        /// <para><see cref="Error"/> |
        /// "Регистрация события об ошибках в системе".</para>
        /// 
        /// <para>● Тип элемента:</para> 
        /// <para>Метод.</para>
        /// 
        /// <para>● Концепция, описание, принцип работы элемента:</para>
        /// <para>Метод не возвращающего типа, который выполняет:</para> 
        /// <list type="number">
        ///    <item><description>процедуру по получению данных;</description></item>
        ///    <item><description>процедуру по выводу данных.</description></item>
        /// </list> 
        /// 
        /// </summary>
        /// 
        /// <param name="nameOperation">Строковый параметр типа <see cref="string"/> "Название операции"</param>
        /// <param name="messageError">Строковый параметр типа <see cref="string"/> "Сообщение об ошибке в системе"</param>
        public void Error(string nameProcedure, string messageError)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine(
                $"Reaction Time: {DateTime.Now},\n" +
                $"Name Procedure: {nameProcedure},\n" +
                $"Error message: {messageError}.");
            Console.ResetColor();
            Console.Out.Flush();
        }

        /// <summary>
        /// <para>● Название элеиента:</para>
        /// <para><see cref="Event"/> |
        /// "Регистрация события о работе системы".</para>
        /// 
        /// <para>● Тип элемента:</para> 
        /// <para>контракт метода.</para>
        /// 
        /// <para>● Концепция, описание, принцип работы элемента:</para>
        /// <para>Метод не возвращающего типа, который должен будет выполнять:</para> 
        /// <list type="number">
        ///    <item><description>процедуру по получению данных;</description></item>
        ///    <item><description>процедуру по записи или выводу данных.</description></item>
        /// </list> 
        /// 
        /// </summary>
        /// 
        /// <param name="nameOperation">Строковый параметр типа <see cref="string"/> "Название операции"</param>
        /// <param name="messageEvent">Строковый параметр типа <see cref="string"/> "Сообщение о событии в системе"</param>
        public void Event(string nameProcedure, string messageEvent)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine(
                $"Reaction Time: {DateTime.Now},\n" +
                $"Name Procedure: {nameProcedure},\n" +
                $"Operation Event: {messageEvent}.");
            Console.ResetColor();
            Console.Out.Flush();
        }
    }
}

