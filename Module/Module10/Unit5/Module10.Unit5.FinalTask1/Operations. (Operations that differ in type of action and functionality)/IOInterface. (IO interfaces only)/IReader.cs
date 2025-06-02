using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ParameterOrder;

namespace Module10.Unit5.FinalTask1
{

    /// <summary>
    /// Интерфейс для операций по вводу данных / читает пользовательский ввод
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Читает выбор операции пользователем
        /// </summary>
        /// <returns>Вовзращает строковое название выбранной операции</returns>
        string ReadOperationChoice();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string ReadBlockChoice();

        /// <summary>
        /// Читает аргументы для операции
        /// </summary>
        /// <returns>Возвращает дробный массив</returns>
        double[] ReadNumbers();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string ReadChoice();
    }
}
