using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Class Description "Абстрактный класс для блока математических операций"
    /// <summary>
    /// Абстрактный класс для блока математических операций.
    /// <para>Формирует общую структуру для всех наследуемых классов, определяющих блоки операций:</para>
    /// <list type="bullet">
    ///   <item><description>Предоставляет свойства для хранения названия блока и списка операций.</description></item>
    ///   <item><description>Обеспечивает метод для проверки наличия операции в блоке.</description></item>
    /// </list>
    /// </summary>
    #endregion
    public abstract class OperationBlock
    {
        #region Property Description "Название блока операций"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="BlockName"/> | Название блока операций.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Абстрактное свойство.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Абстрактное свойство строкового типа <see cref="string"/>, которое:</para>
        /// <list type="number">
        ///   <item><description>Хранит строковое значение названия блока математических операций.</description></item>
        ///   <item><description>Предоставляет доступ только для чтения.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public abstract string BlockName { get; } // Абстрактное свойство для названия блока

        #region Property Description "Список математических операций блока"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Operations"/> | Список математических операций блока.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Абстрактное свойство.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Абстрактное свойство типа <see cref="Dictionary{string, IMathOperation}"/>, которое:</para>
        /// <list type="number">
        ///   <item><description>Хранит пары ключ-значение, где ключ — строка, а значение — объект типа <see cref="IMathOperation"/>.</description></item>
        ///   <item><description>Предоставляет доступ только для чтения к списку операций блока.</description></item>
        /// </list>
        /// </summary>
        #endregion
        public abstract Dictionary<string, IMathOperation> Operations { get; } // Абстрактное свойство для списка операций

        #region Method Description "Поиск операции по названию"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="ContainsOperation"/> | Поиск операции по названию.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Метод.</para>
        /// <para><b>ℹ️ Описание:</b></para>
        /// <para>Метод возвращающего типа, выполняющий проверку наличия операции в блоке:</para>
        /// <list type="number">
        ///   <item><description>Принимает строковый параметр с названием операции.</description></item>
        ///   <item><description>Проверяет наличие ключа в словаре операций.</description></item>
        ///   <item><description>Возвращает результат поиска в виде булевого значения.</description></item>
        /// </list>
        /// </summary>
        /// <param name="operationName">Строковое значение типа <see cref="string"/>, представляющее название операции.</param>
        /// <returns>Булево значение типа <see cref="bool"/>, указывающее, содержится ли операция в блоке.</returns>
        #endregion
        public bool ContainsOperation(string operationName) => Operations.ContainsKey(operationName); // Проверяет наличие операции в словаре
    }
}