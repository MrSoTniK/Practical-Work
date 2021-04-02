using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DossierList2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Criminal> criminals = new List<Criminal>
            {
                new Criminal("Самойлов Александр Иванович", 175, 68, "русский", false),
                new Criminal("Гаврилов Петр Иванович", 182, 75, "русский", false),
                new Criminal("Шайхудинов Мурат Аскарович ", 190, 90, "узбек", false),
                new Criminal("Агишев Айрат Муслимович ", 172, 79, "татарин", false),
                new Criminal("Стрекоткин Василий Александрович", 185, 82, "русский", false),
                new Criminal("Плеханов Виктор Геннадьевич", 191, 73, "русский", false),
                new Criminal("Иванчук Роман Викторович ", 175, 62, "русский", true),
                new Criminal("Алеев Абдулла Беркутович  ", 170, 60, "татарин", false),
                new Criminal("Шлепкин Филипп Романович", 173, 74, "русский", false),
                new Criminal("Громов Андрей Сергеевич", 185, 81, "русский", false),
                new Criminal("Ротченко Сергей Леонидович", 191, 72, "русский", false),
                new Criminal("Нектаров Виктор Сергеевич ", 186, 95, "русский", false)
            };
          
            bool isExit = false;
            while(isExit == false)
            {
                bool isHeightNumber = false, isWeightNumber = false;
                string userName, userHeight, userWeight, userNationality, userInput;
                int heightValue = 0, weightValue = 0;

                Console.Clear();
                Console.WriteLine("Меню поиска преступника:");
                Console.WriteLine("Введите имя или часть имени");
                userName = Console.ReadLine();
                while (isHeightNumber == false) 
                {
                    Console.WriteLine("Введите рост в сантиметрах");
                    userHeight = Console.ReadLine();
                    isHeightNumber = Int32.TryParse(userHeight, out heightValue);
                    if (isHeightNumber == false)
                    {
                        Console.WriteLine("Введено не число! Повторите ввод параметра роста.");
                    }
                }
                while (isWeightNumber == false)
                {
                    Console.WriteLine("Введите вес в килограммах");
                    userWeight = Console.ReadLine();
                    isWeightNumber = Int32.TryParse(userWeight, out weightValue);
                    if (isHeightNumber == false)
                    {
                        Console.WriteLine("Введено не число! Повторите ввод параметра веса.");
                    }
                }              
                Console.WriteLine("Введите национальность");
                userNationality = Console.ReadLine();

                var filteredCriminals = from Criminal criminal in criminals
                                        where criminal.FullName.Contains(userName)
                                        where criminal.Height == heightValue
                                        where criminal.Weight == weightValue
                                        where criminal.Nationality == userNationality
                                        where criminal.IsArrested == false
                                        select criminal;

                Console.WriteLine();
                foreach(Criminal criminal in filteredCriminals)
                {                   
                    criminal.Show();                                   
                }
                Console.WriteLine("Начать новый ввод или выйти? 1- выйти, люб. др. значение - начать новый ввод");
                userInput = Console.ReadLine();
                if (userInput == "1") 
                {
                    isExit = true;
                }
            }
            Environment.Exit(0);         
        }
    }

    class Criminal 
    {
        public string FullName { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }
        public bool IsArrested { get; private set; }

        public Criminal(string fullName, int height, int weight, string nationality, bool isArrested) 
        {
            FullName = fullName;
            Height = height;
            Weight = weight;
            Nationality = nationality;
            IsArrested = isArrested;
        }

        public void Show()
        {
            Console.WriteLine("ФИО: " + FullName);
            Console.WriteLine("рост: " + Height.ToString());
            Console.WriteLine("вес: " + Weight.ToString());
            Console.WriteLine("национальность: " + Nationality);
            Console.WriteLine();
        }
    }
}
