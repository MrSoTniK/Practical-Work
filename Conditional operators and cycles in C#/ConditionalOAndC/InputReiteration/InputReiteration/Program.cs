using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputReiteration
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int reiterationNumber = 0, reiterationStep = 0;
            bool isNumber = false;

            Console.WriteLine("Введите сообщение");
            userInput = Console.ReadLine();
            Console.WriteLine("Введите количество повторений");
            while(isNumber == false)
            {
                isNumber = Int32.TryParse(Console.ReadLine(), out reiterationNumber);
                if(isNumber == false)
                {
                    Console.WriteLine("Введено не число. Попробуйте снова.");
                }               
            }

            while (reiterationStep != reiterationNumber) 
            {
                Console.WriteLine(userInput);
                reiterationStep++;
            }
            Console.ReadLine();
        }
    }
}
