using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>
            {
                new Patient("Иванов Виктор Сергеевич", 36, "бронхит"),
                new Patient("Наливайкин Петр Степанович", 47, "грипп"),
                new Patient("Самойлов Альберт Геннадьевич", 57, "воспаление легких"),
                new Patient("Кравчук Людмила Дмитриевна", 28, "ОРЗ"),
                new Patient("Норкина Наталья Ивановна", 22, "гайморит"),
                new Patient("Рыбины Дарья Константиновна", 25, "танзилит"),
                new Patient("Дружко Сергей Михайлович", 29, "грипп"),
                new Patient("Горкин Степан Васильевич", 37, "воспаление легких"),
                new Patient("Шелетсова Любовь Петоровна", 28, "ОРЗ"),
                new Patient("Базарова Светлана Леонидовна", 28, "бронхит"),
            };

            string userInput;
            bool isExit = false, isRightValue;

            while (isExit == false) 
            {
                Console.Clear();
                isRightValue = true;
                Console.WriteLine("Меню больницы:");
                Console.WriteLine("1 - отсортировать всех больных по ФИО");
                Console.WriteLine("2 - отсортировать всех больных по возрасту");
                Console.WriteLine("3 - вывести больных с определенным заболеванием");
                Console.WriteLine("4 - выход из программы");
                userInput = Console.ReadLine();
                IEnumerable<Patient> filteredPatients = null;
                switch (userInput)
                {
                    case "1":
                        filteredPatients = patients.OrderBy(patient => patient.FullName);
                        break;
                    case "2":
                        filteredPatients = patients.OrderBy(patient => patient.Age);
                        break;
                    case "3":
                        Console.WriteLine("Введите заболевание");
                        userInput = Console.ReadLine();
                        filteredPatients = patients.Where(patient => patient.Illness == userInput);
                        break;
                    case "4":
                        isExit = true;
                        break;
                    default:
                        isRightValue = false;
                        Console.WriteLine("Введено неверное значение");
                        break;
                }

                if (isExit != true) 
                {
                    if (isRightValue == true)
                    {
                        foreach (Patient patient in filteredPatients)
                        {
                            patient.Show();
                        }
                    }

                    Console.WriteLine("Нажмите любую клавишу для рподолжения...");
                    Console.ReadKey();
                }                                         
            }

            Environment.Exit(0);         
        }     
    }

    class Patient 
    {
        public string FullName { get; private set; }
        public int Age { get; private set; }
        public string Illness { get; private set; }

        public Patient(string fullName, int age, string illness) 
        {
            FullName = fullName;
            Age = age;
            Illness = illness;
        }

        public void Show() 
        {
            Console.WriteLine("ФИО: " + FullName);
            Console.WriteLine("Возраст: " + Age.ToString());
            Console.WriteLine("Заболевание: " + Illness);
        }
    }
}
