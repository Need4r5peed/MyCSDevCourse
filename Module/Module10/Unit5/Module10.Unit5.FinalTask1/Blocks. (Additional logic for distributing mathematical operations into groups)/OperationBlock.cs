using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{

    /// <summary>
    /// "Блок математических операций".
    /// <para>Абстрактный класс, формирующий общую структуру для всех наследуемых классов</para>
    /// </summary>
    public abstract class OperationBlock
    {
        /// <summary>
        /// "Название блока".
        /// <para>Абстрактный контракт на свойство, которое должно</para>
        /// <para>● хранить строковое значение "Названия блока математических операций"</para>
        /// <para>● выполнять доступ для получения этого значения</para>
        /// </summary>
        public abstract string BlockName { get; }

        /// <summary>
        /// "Список математических операций блока".
        /// <para>Абстрактный контракт на свойство-словарь, которое должно</para>
        /// <para>● хранить пару: строковый ключ, IMathOperation значение, формирующих "Список математических операций блока"</para>
        /// <para>● выполнять доступ для получения этого списка значений</para>
        /// </summary>
        public abstract Dictionary<string, IMathOperation> Operations { get; }

        /// <summary>
        /// "Поиск блока по названию".
        /// <para>Метод, который выполняет:</para>
        /// <para>1) приём параметра</para>
        /// <para>2) поиск по ключу</para>
        /// <para>3) возвращение результата поиска</para>
        /// </summary>
        /// <param name="operationName">
        /// <para>Параметр метода - строковое значение</para>
        /// <para>● <c>string</c> — string-тип строкового значения</para>
        /// <para>● <c>operationName</c> — имя параметра "Название математической операции"</para>
        /// </param>
        /// <returns>Возвращает результат поиска в виде булевого значения</returns>
        public bool ContainsOperation(string operationName) => Operations.ContainsKey(operationName);
    }
}
