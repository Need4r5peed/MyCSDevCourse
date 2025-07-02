using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{

    /// <summary>
    /// Интерфейс Регистратора событий | создаёт контракты для для записи или вывода 
    /// данных о событиях работы системы и её ошибках
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// <para>● Название элеиента:</para>
        /// <para><see cref="Type"/> |
        /// "Тип регистратора событий".</para>
        /// 
        /// <para>● Тип элемента:</para> 
        /// <para>контракт свойства.</para>
        /// 
        /// <para>● Концепция, описание, принцип работы элемента:</para>
        /// <para>Cвойство строковго типа <see cref="string"/>, которое должно будет:</para> 
        /// <list type="number">
        ///    <item><description>выполнять хранение данных;</description></item>
        ///    <item><description>и предоставлять доступ для чтения этих данных.</description></item>
        /// </list> 
        /// 
        /// </summary>
        string Type { get; }

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
        void Event(string nameOperation, string messageEvent);

        /// <summary>
        /// <para>● Название элеиента:</para>
        /// <para><see cref="Error"/> |
        /// "Регистрация события об ошибках в системе".</para>
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
        /// <param name="messageError">Строковый параметр типа <see cref="string"/> "Сообщение об ошибке в системе"</param>
        void Error(string nameOperation, string messageError);
    }
}
