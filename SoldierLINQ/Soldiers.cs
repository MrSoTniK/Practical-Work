using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldiers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>
            {
                new Soldier("Шайхудинов Мурат Аскарович", "автомат", "рядовой", 15),
                new Soldier("Агишев Айрат Муслимович", "автомат", "рядовой", 16),
                new Soldier("Гаврилов Петр Иванович", "винтовка", "рядовой", 13),
                new Soldier("Шлепкин Филипп Романович", "автомат", "рядовой", 13),
                new Soldier("Стрекоткин Василий Александрович", "винтовка", "младший сержант", 22),
                new Soldier("Громов Андрей Сергеевич", "пистолет", "старшина", 25),
                new Soldier("Ротченко Сергей Леонидович", "пистолет", "прапорщик", 30),
                new Soldier("Нектаров Виктор Сергеевич", "пистолет", "лейтенант", 40),
            };

            Console.WriteLine("Личный состав:");
            foreach(Soldier soldier in soldiers)
            {
                soldier.Show();
            }

            Console.WriteLine("Имя + звание:");
            var filteredSoldiers = soldiers.Select(soldier => new 
            {
                Name = soldier.Name,
                Rank = soldier.Rank
            });
            foreach (var soldier in filteredSoldiers) 
            {
                Console.WriteLine(soldier.Name + " - " + soldier.Rank);
            }
            
            Console.ReadKey();
        }
    }

    class Soldier 
    {
        public string Name { get; private set; }
        public string Armament { get; private set; }
        public string Rank { get; private set; }
        public int DutyTour { get; private set; }

        public Soldier(string name, string armament, string rank, int dutyTour) 
        {
            Name = name;
            Armament = armament;
            Rank = rank;
            DutyTour = dutyTour;
        }

        public void Show()
        {
            Console.WriteLine("имя: " + Name);
            Console.WriteLine("вооружение: " + Armament);
            Console.WriteLine("звание: " + Rank);
            Console.WriteLine("срок службы: " + DutyTour.ToString());
            Console.WriteLine();
        }
    }
}
