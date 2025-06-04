using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Module10.Unit5.FinalTask1.ParameterOrder;

namespace Module10.Unit5.FinalTask1
{
    /// <summary>
    /// Интерфейс вычислений арифметических операций
    /// </summary>
    public interface IMathOperation
    {
        //Контракты на свойства:

        /// <summary>
        /// <para>Контракт на свойство, которое должен</para>
        /// <para>1) хранить строковое значение "Название операции"</para>
        /// <para>2) выполнять доступ для получения этого значения</para>
        /// </summary>
        string Name { get; }

        /// <summary>
        /// <para>Контракт на свойство, которое должен</para>
        /// <para>1) хранить строковое значение "Описание операции для пользователя"</para>
        /// <para>2) выполнять доступ для получения этого значения</para>
        /// </summary>
        string Description { get; }

        /// <summary>
        /// <para>Контракт на свойство, которое должен</para>
        /// <para>1) хранить строковое значение "Минимальное количество требуемых аргументов"</para>
        /// <para>2) выполнять доступ для получения этого значения</para>
        /// </summary>
        int MinArgsCount { get; }

        int MaxArgsCount { get; }

        ILogger Logger { get; }

        //Контракты на методы:

        /// <summary>
        /// <para>Контракт метода, которое должен:</para>
        /// <para>1) принимать параметр</para>
        /// <para>2) вычислять результат операции</para>
        /// <para>3) возвращать результат операции</para>
        /// </summary>
        /// <param name="args">
        /// <para>Параметр метода - массив аргументов типа double переменной длины</para>
        /// <para>● <c>params</c> — ключевое слово для параметра, позволяющее передавать в метод переменное количество аргументов одного типа</para>
        /// <para>● <c>double[]</c> — double-тип массива дробных чисел</para>
        /// <para>● <c>args</c> — имя параметра "аргументы для математической операции"</para>
        /// </param>
        /// <returns>Реализуемый метод должен возвращать результат математической операции дробного типа double</returns>
        double Calculate(params double[] args);
    }

}
