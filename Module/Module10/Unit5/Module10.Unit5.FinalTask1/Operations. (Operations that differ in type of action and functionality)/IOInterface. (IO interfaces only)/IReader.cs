using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ParameterOrder;

namespace Module10.Unit5.FinalTask1
{
    #region Interface Description "Интерфейс для чтения пользовательского ввода"
    /// <summary>
    /// Интерфейс для чтения пользовательского ввода.
    /// <para>Определяет контракты для чтения пользовательских данных, необходимых для выполнения операций:</para>
    /// <list type="bullet">
    ///   <item><description>Чтение выбора операции или блока операций.</description></item>
    ///   <item><description>Чтение числовых аргументов для операций.</description></item>
    ///   <item><description>Чтение общего пользовательского выбора.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public interface IReader
    {
        #region Method Description "Чтение выбора операции пользователем"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ReadOperationChoice"/> | Чтение выбора операции пользователем.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, предназначенный для чтения пользовательского ввода, представляющего выбор операции:</para>
        /// <list type="bullet">
        ///   <item><description>Возвращает строковое название выбранной операции.</description></item>
        /// </list>
        /// </summary>
        /// <returns>Строковое значение типа <see cref="string"/>, представляющее название выбранной операции.</returns>
        #endregion
        string ReadOperationChoice();

        #region Method Description "Чтение выбора блока операций пользователем"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ReadBlockChoice"/> | Чтение выбора блока операций пользователем.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, предназначенный для чтения пользовательского ввода, представляющего выбор блока операций:</para>
        /// <list type="bullet">
        ///   <item><description>Возвращает строковое название выбранного блока операций.</description></item>
        /// </list>
        /// </summary>
        /// <returns>Строковое значение типа <see cref="string"/>, представляющее название выбранного блока операций.</returns>
        #endregion
        string ReadBlockChoice();

        #region Method Description "Чтение аргументов для операции"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ReadNumbers"/> | Чтение аргументов для операции.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, предназначенный для чтения числовых аргументов, введённых пользователем:</para>
        /// <list type="bullet">
        ///   <item><description>Возвращает массив дробных чисел для использования в математических операциях.</description></item>
        /// </list>
        /// </summary>
        /// <returns>Массив дробных чисел типа <see cref="double"/>[].</returns>
        #endregion
        double[] ReadNumbers();

        #region Method Description "Чтение общего пользовательского выбора"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ReadChoice"/> | Чтение общего пользовательского выбора.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод, предназначенный для чтения общего пользовательского ввода:</para>
        /// <list type="bullet">
        ///   <item><description>Возвращает строковое значение, представляющее выбор пользователя.</description></item>
        /// </list>
        /// </summary>
        /// <returns>Строковое значение типа <see cref="string"/>, представляющее выбор пользователя.</returns>
        #endregion
        string ReadChoice();
    }
}