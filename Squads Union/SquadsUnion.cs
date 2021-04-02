using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadsUnion
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> firstSquad = new List<Soldier>
            {
                new Soldier("Байхудинов Мурат Аскарович", "автомат", "рядовой", 15),
                new Soldier("Агишев Айрат Муслимович", "автомат", "рядовой", 16),
                new Soldier("Гаврилов Петр Иванович", "винтовка", "рядовой", 13),
                new Soldier("Бочкин Филипп Романович", "автомат", "рядовой", 13),
                new Soldier("Белолистов Василий Александрович", "винтовка", "младший сержант", 22),             
            };

            List<Soldier> secondSquad = new List<Soldier>
            {
                new Soldier("Громов Андрей Сергеевич", "пистолет", "старшина", 25),
                new Soldier("Ротченко Сергей Леонидович", "пистолет", "прапорщик", 30),
                new Soldier("Плеханов Виктор Геннадьевич", "пистолет", "младший лейтенант", 40),
                new Soldier("Алеев Абдулла Беркутович", "пистолет", "лейтенант", 40),
                new Soldier("Нектаров Виктор Сергеевич", "пистолет", "старший лейтенант", 40),
            };

            Console.WriteLine("Первый отряд:");
            foreach (Soldier soldier in firstSquad)
            {
                soldier.Show();
            }
            Console.WriteLine("Второй отряд:");
            foreach (Soldier soldier in secondSquad)
            {
                soldier.Show();
            }

            Console.WriteLine("Объединенный отряд:");
            var filteredSoldiers = firstSquad.Where(soldier => soldier.Name.StartsWith("Б")).Union(secondSquad).OrderBy(soldier => soldier.Name);
            foreach (var soldier in filteredSoldiers)
            {
                soldier.Show();
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
