using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amnesty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Prisoner> prisoners = new List<Prisoner> 
            { 
                new Prisoner("Клювастов Регин Сюнотович","воровство"),
                new Prisoner("Бусотов Саман Крогович", "антиправительственное"),
                new Prisoner("Турулай Шарак Баракович", "антиправительственное"),
                new Prisoner("Бяковий Бяка Бякович", "убийство"),
                new Prisoner("Клюква Нестор Клюрович", "воровство"),
                new Prisoner("Синигач Синия Симоровна", "антиправительственное"),
            };

            Console.WriteLine("Список заключенных:");
            Console.WriteLine("До амнистии:");
            foreach (Prisoner prisoner in prisoners)
            {
                prisoner.Show();
            }
            Console.WriteLine("После амнистии:");
            var filteredPrisoners = prisoners.Where(prisoner => prisoner.Crime != "антиправительственное");
            foreach (Prisoner prisoner in filteredPrisoners)
            {
                prisoner.Show();
            }
            Console.ReadKey();
        }
    }

    class Prisoner 
    {
        public string FullName { get; private set; }
        public string Crime { get; private set; }

        public Prisoner(string fullName, string crime)
        {
            FullName = fullName;
            Crime = crime;
        }

        public void Show() 
        {
            Console.WriteLine("ФИО: " + FullName + ";  преступление: " + Crime);
        }
    }
}
