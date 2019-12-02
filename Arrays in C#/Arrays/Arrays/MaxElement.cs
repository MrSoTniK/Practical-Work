using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class MaxElement
    {
        public void Solution() 
        {
            bool contin = true;
            string exit;

            while (contin == true)
            {
                Random rand = new Random();
                int[,] array = new int[10, 10];
                int max = int.MinValue;

                Console.WriteLine("Исходная матрица:");
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = rand.Next(10, 100);
                        Console.Write(array[i, j] + "    ");
                        if (max < array[i, j])
                        {
                            max = array[i, j];
                        }
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Полученная матрица:");
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (array[i, j] == max)
                        {
                            array[i, j] = 0;
                        }
                        if (array[i, j] != 0)
                        {
                            Console.Write(array[i, j] + "    ");
                        }
                        else 
                        {
                            Console.Write(array[i, j] + "     ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Наибольший элемент: " + max);
                Console.WriteLine("Назад или начать заново? 1 - назад, любое др. значение - заново ");
                exit = Console.ReadLine();
                if (exit == "1")
                {
                    contin = false;
                }
            }
        }
    }
}
