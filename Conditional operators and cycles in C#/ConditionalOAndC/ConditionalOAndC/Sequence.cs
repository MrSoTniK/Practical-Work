using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOAndC
{
    class Sequence
    {
        public string exit;
        public void Solution()
        {

            int i;          
            int enteredVal;
            bool contin = true;

            while (contin == true)
            {
                Console.WriteLine("Введите максимальную границу последовательности (целое число):");
                enteredVal = Convert.ToInt32(Console.ReadLine());
                for (i = 0; i <= enteredVal; i += 7)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("Ввыйти или начать заново? 1 - ввыйти, любое др. значение - заново ");
                exit = Console.ReadLine();
                if (exit == "1")
                {
                    contin = false;
                }
            }
        }
    }
}
