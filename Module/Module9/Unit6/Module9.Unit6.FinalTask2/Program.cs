using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Module9.Unit6.FinalTask2
{
    public class Main_FinalTask2
    {
        public static void Main()
        {
            List<string> namesOfEmployeesList = new List<string>();
            namesOfEmployeesList.Add("Егоров");
            namesOfEmployeesList.Add("Смирнов");
            namesOfEmployeesList.Add("Виноградов");
            namesOfEmployeesList.Add("Ярцев");
            namesOfEmployeesList.Add("Орехин");
            namesOfEmployeesList.Add("Груздев");
            namesOfEmployeesList.Add("Сизых");
            namesOfEmployeesList.Add("Петренко");
            namesOfEmployeesList.Add("Перов");
            namesOfEmployeesList.Add("Павловский");
            namesOfEmployeesList.Add("Орих");
            namesOfEmployeesList.Add("Сизов");
            namesOfEmployeesList.Add("Груздев");
            namesOfEmployeesList.Add("Петров-Даль");

            NumberReader numberReader = new NumberReader();
            numberReader.NumberEnteredEvent += ShowNumber;

            while (true)
            {
                try
                {
                    numberReader.Read(namesOfEmployeesList);
                }
                catch (ExitRequestedException ex)
                {
                    Console.WriteLine(ex.Message); // "Вы ввели: q. Запрос пользователя: выход!"
                    return; // Выходим из метода и цикла
                }
                catch (EmergencyInputStringLocalException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (EmergencyInputNumberLocalException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
            }

            Console.WriteLine("Программа завершена...");
        }

        static void ShowNumber(int number, List<string> list)
        {
            //Console.Clear();

            switch (number)
            {
                case 1:
                    Console.WriteLine("Введено значение: 1. Выбран 1-й вариант сортировки списка: от А до Я");
                    list.Sort();
                    Console.WriteLine("Первый вариант сортировки выполнен!");
                    break;
                case 2:
                    Console.WriteLine("Введено значение: 2. Выбран 2-й вариант сортировки списка: от Я до А");
                    list.Sort();
                    list.Reverse();
                    Console.WriteLine("Второй вариант сортировки выполнен!");
                    break;
            }

            // Выводим список после сортировки
            Console.WriteLine("nРезультат сортировки: ");
            foreach (var name in list)
            {
                Console.WriteLine(name);
            }
        }
    }
}


