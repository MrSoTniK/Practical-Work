﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            string userInput;
            int userNumber, sum = 0;
            bool isExit = false, isNumber;
            while (isExit == false) 
            {
                userInput = Console.ReadLine();
                isNumber = Int32.TryParse(userInput, out userNumber);
                if (Int32.TryParse(userInput, out userNumber) == true) 
                {
                    sum += userNumber;
                }
                else if(userInput == "sum")
                {
                    Console.WriteLine("Сумма: "+sum.ToString());
                }
                else if (userInput == "exit") 
                {
                    isExit = true;
                }
                else 
                {
                    Console.WriteLine("Введено не число.");
                }
            }
            Environment.Exit(0);

        }
    }
}
