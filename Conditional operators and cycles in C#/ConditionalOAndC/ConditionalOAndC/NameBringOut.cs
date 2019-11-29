using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOAndC
{
    class NameBringOut
    {
        public string exit;
        public void Solution()
        {
            string name;
            char symbol;
            bool contin = true;
            int length;
            int i;           

            while (contin == true)
            {
                Console.WriteLine("Введите имя");
                name = Console.ReadLine();
                Console.WriteLine("Введите символ");
                symbol = Convert.ToChar(Console.ReadLine());
                length = name.Length;
                for (i = 1; i <= length+2; i++) 
                {
                    Console.Write(symbol);
                }
                Console.WriteLine("\n"+symbol + name + symbol);
                for (i = 1; i <= length + 2; i++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine("\nВвыйти или начать заново? 1 - ввыйти, любое др. значение - заново ");
                exit = Console.ReadLine();
                if (exit == "1")
                {
                    contin = false;
                }

            }

        }
    }
}
