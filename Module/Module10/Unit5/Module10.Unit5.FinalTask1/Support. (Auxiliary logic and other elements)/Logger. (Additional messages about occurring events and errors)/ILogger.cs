using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Interface Description "Интерфейс регистратора событий"
    /// <summary>
    /// Интерфейс регистратора событий.
    /// <para>Создаёт контракты для записи или вывода данных о событиях работы системы и её ошибках:</para>
    /// <list type="bullet">
    ///   <item><description>Определяет свойство для хранения типа регистратора.</description></item>
    ///   <item><description>Определяет методы для логирования событий и ошибок.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public interface ILogger
    {
        #region Property Description "Тип регистратора событий"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Type"/> | Тип регистратора событий.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт свойства.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Свойство строкового типа <see cref="string"/>, предназначенное для:</para>
        /// <list type="number">
        ///   <item><description>Хранения данных о типе регистратора событий.</description></item>
        ///   <item><description>Предоставления доступа к этим данным только для чтения.</description></item>
        /// </list>
        /// </summary>
        #endregion
        string Type { get; }

        #region Method Description "Регистрация события о работе системы."
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Event"/> | Регистрация события о работе системы.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод не возвращающего типа, предназначенный для:</para>
        /// <list type="number">
        ///   <item><description>Получения данных о событии в системе.</description></item>
        ///   <item><description>Записи или вывода данных о событии.</description></item>
        /// </list>
        /// </summary>
        /// <param name="nameOperation">Строковый параметр типа <see cref="string"/>, представляющий название операции.</param>
        /// <param name="messageEvent">Строковый параметр типа <see cref="string"/>, содержащий сообщение о событии в системе.</param>
        #endregion
        void Event(
            string nameOperation, 
            string messageEvent);

        #region Method Description "Регистрация события об ошибках в системе"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Error"/> | Регистрация события об ошибках в системе.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Контракт метода.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод не возвращающего типа, предназначенный для:</para>
        /// <list type="number">
        ///   <item><description>Получения данных об ошибке в системе.</description></item>
        ///   <item><description>Записи или вывода данных об ошибке.</description></item>
        /// </list>
        /// </summary>
        /// <param name="nameOperation">Строковый параметр типа <see cref="string"/>, представляющий название операции.</param>
        /// <param name="messageError">Строковый параметр типа <see cref="string"/>, содержащий сообщение об ошибке в системе.</param>
        #endregion
        void Error(
            string nameOperation, 
            string messageError);
    }
}