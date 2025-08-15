using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Статический класс, содержащий типы регистраторов событий"
    /// <summary>
    /// Статический класс, содержащий типы регистраторов событий.
    /// <para>Предоставляет строковые константы для идентификации различных типов регистраторов событий, используемых в системе:</para>
    /// <list type="bullet">
    ///   <item><description>Определяет типы для точки входа, процедур, операций и прочих случаев.</description></item>
    ///   <item><description>Используется в методе <see cref="ConfigureServices"/> для настройки логирования.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public static class LoggerTypes
    {
        #region Field Description "Тип регистратора событий для точки входа"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Main"/> | Тип регистратора событий для точки входа.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Публичное (<see langword="public"/>) поле-константа (<see langword="const"/>) строкового типа <see cref="string"/>.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Содержит строковую константу, представляющую тип регистратора событий для точки входа программы.</para>
        /// <remarks>
        /// <para><b>ℹ️ Дополнение:</b></para>
        /// <list type="bullet">
        ///   <item><description>Используется в <see cref="ConfigureServices"/> для настройки логирования.</description></item>
        /// </list>
        /// </remarks>
        /// </summary>
        #endregion
        public const string Main = nameof(Main); // Константа для типа регистратора точки входа

        #region Field Description "Тип регистратора событий для процедур калькулятора"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Procedure"/> | Тип регистратора событий для процедур калькулятора.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Публичное (<see langword="public"/>) поле-константа (<see langword="const"/>) строкового типа <see cref="string"/>.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Содержит строковую константу, представляющую тип регистратора событий для процедур калькулятора.</para>
        /// <remarks>
        /// <para><b>ℹ️ Дополнение:</b></para>
        /// <list type="bullet">
        ///   <item><description>Используется в <see cref="ConfigureServices"/> для настройки логирования.</description></item>
        /// </list>
        /// </remarks>
        /// </summary>
        #endregion
        public const string Procedure = nameof(Procedure); // Константа для типа регистратора процедур

        #region Field Description "Тип регистратора событий для операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Operation"/> | Тип регистратора событий для операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Публичное (<see langword="public"/>) поле-константа (<see langword="const"/>) строкового типа <see cref="string"/>.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Содержит строковую константу, представляющую тип регистратора событий для математических операций.</para>
        /// <remarks>
        /// <para><b>ℹ️ Дополнение:</b></para>
        /// <list type="bullet">
        ///   <item><description>Используется в <see cref="ConfigureServices"/> для настройки логирования.</description></item>
        /// </list>
        /// </remarks>
        /// </summary>
        #endregion
        public const string Operation = nameof(Operation); // Константа для типа регистратора операций

        #region Field Description "Тип регистратора событий для незарегистрированных операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Other"/> | Тип регистратора событий для незарегистрированных операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Публичное (<see langword="public"/>) поле-константа (<see langword="const"/>) строкового типа <see cref="string"/>.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Содержит строковую константу, представляющую тип регистратора событий для прочих случаев, не связанных с зарегистрированными операциями.</para>
        /// <remarks>
        /// <para><b>ℹ️ Дополнение:</b></para>
        /// <list type="bullet">
        ///   <item><description>Используется в <see cref="ConfigureServices"/> для настройки логирования.</description></item>
        /// </list>
        /// </remarks>
        /// </summary>
        #endregion
        public const string Other = nameof(Other); // Константа для типа регистратора прочих событий
    }
}