using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Module9.Unit6.FinalTask2
{
    public class EmergencyInputStringLocalException : FormatException
    {
        //Свойство с модификатором общего доступа, хранящее строковое значение "Проблемный строковый ввод",
        //выполняющее доступ к получению этого значения.
        public string EmergencyInputString { get; }

        //Конструктор с общим модификаторо доступа, принимающий строковый параметр "Ввод и строковый параметр "Исключение",
        //инициализирующий свойство "Проблемный строковый ввод".
        //Возвращает базовое сообщение из свойства "Message"
        public EmergencyInputStringLocalException(string yourInput, string yourTextOfException)
            : base(FormatMessage(yourInput, yourTextOfException))
            => EmergencyInputString = yourInput;
        //Статический метод с общим модификаторо доступа,принимающий строковый параметр "Ввод и строковый параметр "Исключение",
        //выполняющий комплектацию сообщения для свойства "Message".
        //Возвращает строковое значение созданного сообщения.
        private static string FormatMessage(string input, string error)
        {
            // 1) Создаём объект StackTrace, который захватывает текущий стек вызовов (состоящий из стековых кадров (stack frame)).
            var stackTrace = new StackTrace();
            // 2) Выполняем поиск нужного кадра (с методом - где произошло исключение)
            for (int i = 0; i < stackTrace.FrameCount; i++)
            {
                // 2) Берём 1-й кадр (0 кадр - текущий кадр или последний вызов)
                var frame = stackTrace.GetFrame(i);
                // 4) Получаем MethodInfo из кадра стека (может быть null, если стек недоступен).
                var method = frame?.GetMethod();
                // 5) Извлекаем имя метода или "unknown", если метод неизвестен.
                string methodName = method?.Name ?? "unknown";
                // 6) Извлекаем имя класса или "unknown", если метод неизвестен.
                string className = method?.DeclaringType?.Name ?? "unknown";

                // 7) Фильтр. Пропускаем служебные методы, конструкторы и системные классы
                if (methodName == ".ctor" || methodName == "Throw" || className.Contains("System"))
                    continue;
                // 8) Создаём и возвращаем сообщение из полученных данных
                return $"В методе \"{className}.{methodName}\" вы ввели: {input}. Ошибка: {error}!";
            }

            // 9) Запасной вариант: создаём и возвращаем сообщение из данных, если поиск не дал результатаов
            return $"В методе \"{"unknown"}.{"unknown"}\" вы ввели: {input}. Ошибка: {error}!";
        }
    }
}
