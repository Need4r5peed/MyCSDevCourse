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
    // Класс проверки ввода числа
    public static class EmergencyInputNumberExpertiseException
    {
        public static void Expertise(int yourInput)
        {
            // Правило 1:
            if (yourInput == 1 || yourInput == 2)
                return;

            // Правило 2:
            if (yourInput == 0)
                throw new EmergencyInputNumberLocalException(
                    yourInput,
                    "Вы ввели 0"
                    );

            // Правило 3:
            if (yourInput >= 3 && yourInput <= 9)
                throw new EmergencyInputNumberLocalException(
                    yourInput,
                    "Не та цифра"
                    );

            // Правило 4:
            if (yourInput >= -9 && yourInput <= -1)
                throw new EmergencyInputNumberLocalException(
                    yourInput, "" +
                    "Вы ввели отрицательное число"
                    );

            // Правило 5:
            throw new EmergencyInputNumberLocalException(
                yourInput,
                "Ваш ввод содержит слишком длинное число"
                );
        }
    }
}
