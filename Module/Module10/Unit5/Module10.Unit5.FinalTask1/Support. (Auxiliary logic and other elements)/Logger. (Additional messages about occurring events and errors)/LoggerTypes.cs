using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    
    /// <summary>
    /// Статический класс "Тип регистратора событий"
    /// </summary>
    public static class LoggerTypes
    {
        /// <summary>
        /// 
        /// <para><b>● Название элемента:</b></para>
        /// <para><see cref="Main"/> | Тип регистратора событий "Для точки входа <see cref="Main"/>".</para>
        /// 
        /// <para><b>● Тип элемента:</b></para>
        /// <para>Публичное(<see langword="public"/>) поле-константа (<see langword="const"/>) строковго типа <see cref="string"/> .</para>
        /// 
        /// <para><b>● Описание:</b></para>
        /// <para>Содержит строковыю константу.</para>
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <para><b>● Дополнение:</b></para>
        /// <list type="">
        ///    <item><description>Используется в <see cref="ConfigureServices"/>.</description></item>
        /// </list> 
        /// </remarks>
        public const string Main = nameof(Main);

        /// <summary>
        /// 
        /// <para><b>● Название элемента:</b></para>
        /// <para><see cref="Procedure"/> | Тип регистратора событий "Для процедрур <see cref="Calculator"/>".</para>
        /// 
        /// <para><b>● Тип элемента:</b></para>
        /// <para>Публичное(<see langword="public"/>) поле-константа (<see langword="const"/>) строковго типа <see cref="string"/> .</para>
        /// 
        /// <para><b>● Описание:</b></para>
        /// <para>Содержит строковыю константу.</para>
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <para><b>● Дополнение:</b></para>
        /// <list type="">
        ///    <item><description>Используется в <see cref="ConfigureServices"/>.</description></item>
        /// </list> 
        /// </remarks>
        public const string Procedure = nameof(Procedure);

        /// <summary>
        /// 
        /// <para><b>● Название элемента:</b></para>
        /// <para><see cref="Operation"/> | Тип Регистратора данных "Для операций <see cref="ISpecializedOperations"/>".</para>
        /// 
        /// <para><b>● Тип элемента:</b></para>
        /// <para>Публичное(<see langword="public"/>) поле-константа (<see langword="const"/>) строковго типа <see cref="string"/> .</para>
        /// 
        /// <para><b>● Описание:</b></para>
        /// <para>Содержит строковыю константу.</para>
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <para><b>● Дополнение:</b></para>
        /// <list type="">
        ///    <item><description>Используется в <see cref="ConfigureServices"/>.</description></item>
        /// </list> 
        /// </remarks>
        public const string Operation = nameof(Operation);

        /// <summary>
        /// 
        /// <para><b>● Название элемента:</b></para>
        /// <para><see cref="Other"/> | Тип Регистратора данных "Для незарегистрированных в фабрике".</para>
        /// 
        /// <para><b>● Тип элемента:</b></para>
        /// <para>Публичное(<see langword="public"/>) поле-константа (<see langword="const"/>) строковго типа <see cref="string"/> .</para>
        /// 
        /// <para><b>● Описание:</b></para>
        /// <para>Содержит строковыю константу.</para>
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// <para><b>● Дополнение:</b></para>
        /// <list type="">
        ///    <item><description>Используется в <see cref="ConfigureServices"/>.</description></item>
        /// </list> 
        /// </remarks>
        public const string Other = nameof(Other);
    }
}
