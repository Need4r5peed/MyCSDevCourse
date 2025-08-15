using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Unit5.FinalTask1
{
    #region Описание класса "Статический класс для проверки доступности операции в блоке операций"
    /// <summary>
    /// Статический класс для проверки доступности операции в блоке операций.
    /// <para>Предоставляет метод для:</para>
    /// <list type="bullet">
    ///   <item><description>валидации наличия операции по имени в указанном блоке операций.</description></item>
    /// </list>
    /// <remarks>
    /// <para><b>ℹ️ Дополнение:</b></para>
    /// <list type="bullet">
    ///   <item><description>Используется в системе калькулятора для проверки, зарегистрирована ли операция в блоке операций, и выбрасывает исключение <see cref="OperationNotAvailableException"/> при её отсутствии.</description></item>
    /// </list>
    /// </remarks>
    /// </summary>
    #endregion
    public static class OperationNotFoundExpertiseException
    {
        #region Описание метода "Проверка доступности операции в блоке"
        /// <summary>
        /// <para><b>ℹ️ Название элемента:</b></para>
        /// <para><see cref="Expertise"/> | Проверка доступности операции в блоке.</para>
        /// <para><b>ℹ️ Тип элемента:</b></para>
        /// <para>Статический метод.</para>
        /// <para><b>ℹ️ Концепция, описание, принцип работы элемента:</b></para>
        /// <para>Проверяет наличие операции с указанным именем в блоке операций:</para>
        /// <list type="number">
        ///   <item><description>Принимает имя операции и объект блока операций.</description></item>
        ///   <item><description>Проверяет наличие операции в словаре операций блока.</description></item>
        ///   <item><description>Выбрасывает исключение, если операция не найдена.</description></item>
        /// </list>
        /// </summary>
        /// <param name="operationName">Имя операции для проверки.</param>
        /// <param name="block">Блок операций типа <see cref="OperationBlock"/>, в котором выполняется проверка.</param>
        /// <exception cref="OperationNotAvailableException">Выбрасывается, если операция с указанным именем не найдена в блоке.</exception>
        #endregion
        public static void Expertise(
            string operationName,
            OperationBlock block)
        {
            // Проверка наличия операции в словаре блока
            if (!block.Operations.ContainsKey(operationName))
                // Выброс исключения при отсутствии операции
                throw new OperationNotAvailableException(operationName, block.BlockName);
        }
    }
}