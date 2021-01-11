using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitingWithUserInput
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            while (true) 
            {
                userInput = Console.ReadLine();
                if (userInput == "exit") 
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
