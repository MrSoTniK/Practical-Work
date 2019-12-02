using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class LocalMax
    {
        public void Solution()
        {
            bool contin = true;
            string exit;           

            while (contin == true)
            {
                int[] array = new int[30];
                int[] localMaxes = new int[0];
                Random rand = new Random();              

                Console.WriteLine("Исходный массив:");
                for (int i = 0; i < array.Length; i++) 
                {
                    array[i] = rand.Next(0, 100);
                    Console.Write(array[i]+"  ");
                }
                Console.WriteLine();

                for (int i = 0; i < array.Length; i++)
                {
                    if (i != 0 && i != array.Length - 1) 
                    {
                        if (array[i] > array[i - 1] && array[i] > array[i + 1]) 
                        {                           
                                int[] tempArray = new int[localMaxes.Length + 1];
                                for (int j = 0; j < localMaxes.Length; j++)
                                {
                                    tempArray[j] = localMaxes[j];
                                }
                                localMaxes = tempArray;
                                localMaxes[localMaxes.Length - 1] = array[i];                 
                        }                     
                    }
                    else if (i == 0)
                    {
                        if (array[i] > array[i+1])
                        {                           
                                int[] tempArray = new int[localMaxes.Length + 1];
                                for (int j = 0; j < localMaxes.Length; j++)
                                {
                                    tempArray[j] = localMaxes[j];
                                }
                                localMaxes = tempArray;
                                localMaxes[localMaxes.Length - 1] = array[i];                     
                        }
                    }
                    else if (i == array.Length - 1)
                    {
                        if (array[i] > array[i - 1])
                        {                            
                                int[] tempArray = new int[localMaxes.Length + 1];
                                for (int j = 0; j < localMaxes.Length; j++)
                                {
                                    tempArray[j] = localMaxes[j];
                                }
                                localMaxes = tempArray;
                                localMaxes[localMaxes.Length - 1] = array[i];    
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Локальные максимумы:");
                for (int i = 0; i < localMaxes.Length; i++)
                {
                    Console.Write(localMaxes[i] + "  ");
                }
                Console.WriteLine();
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
