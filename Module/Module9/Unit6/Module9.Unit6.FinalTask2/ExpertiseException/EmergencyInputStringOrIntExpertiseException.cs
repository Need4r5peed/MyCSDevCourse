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
    // Класс начальной проверки ввода строки
    public static class EmergencyInputStringOrIntExpertiseException
    {
        public static void Expertise(string yourInput)
        {
            try
            {
                // Правило 1:
                if (string.IsNullOrWhiteSpace(yourInput))
                    throw new EmergencyInputStringLocalException(
                        yourInput,
                        "Слишком пусто"
                        );

                // Правило 2:
                if (yourInput.Any(char.IsWhiteSpace))
                    throw new EmergencyInputStringLocalException(
                        yourInput,
                        "Содержит пробельные символы"
                        );

                // Правило 3:
                var forbiddenChars = new[] { ',', '.', '\"', '\'', '/', '|', '\\', '<', '>', '?', '!' };
                if (yourInput.Any(c => forbiddenChars.Contains(c)))
                    throw new EmergencyInputStringLocalException(
                        yourInput,
                        $"Содержит запрещённые символы: {forbiddenChars}"
                        );

                // Правило 4:
                if (!yourInput.Any(char.IsDigit))
                    throw new EmergencyInputStringLocalException(
                        yourInput,
                        "Нет цифр"
                        );

                // Правило 5:
                if (yourInput.Any(char.IsDigit) && yourInput.Contains(' '))
                    throw new EmergencyInputStringLocalException(
                        yourInput,
                        "Цифры с пробелами"
                        );
            }
            catch (Exception ex) when (ex is not EmergencyInputStringLocalException)
            {
                throw new FormatException("Непредвиденная ошибка при обработке ввода", ex);
            }

        }
    }
}
