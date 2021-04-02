using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StewCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Stew> stews = new List<Stew>
            {
                new Stew("101 день", 2020, 3),
                new Stew("Вкуснятина", 2008, 5),
                new Stew("Добрый день", 2021, 3),
                new Stew("Мясгорторг", 2019, 1),
                new Stew("Каждодневка", 2017, 2),
                new Stew("Выручайка", 2021, 3),
                new Stew("Бобылевская", 2021, 2),
                new Stew("Говяжая радость", 2020, 1),
                new Stew("Съедобкинская", 2019, 1),
                new Stew("Райская", 2020, 3),
            };

            Console.WriteLine("Тушенка:");
            foreach (Stew stew in stews) 
            {
                stew.Show();
            }

            Console.WriteLine();
            Console.WriteLine("Просрочка:");
            int currentYear = DateTime.Today.Year;
            var filteredStews = stews.Where(stew => stew.ManufactureYear + stew.ShelfLife < currentYear);
            foreach (Stew stew in filteredStews)
            {
                stew.Show();
            }
            Console.ReadKey();
        }
    }

    class Stew 
    {
        public string Name { get; private set; }
        public int ManufactureYear { get; private set; }
        public int ShelfLife { get; private set; }

        public Stew(string name, int manfactureYear, int shelfLife) 
        {
            Name = name;
            ManufactureYear = manfactureYear;
            ShelfLife = shelfLife;
        }

        public void Show()
        {
            Console.WriteLine("название: " + Name + ", год производства: " + ManufactureYear.ToString() + ", срок годности: " + ShelfLife.ToString());
        }
    }
}
