using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class DynamicArray
    {
        public void Solution() 
        {
            bool contin = true;          
            string userCommand = "";                      
            int sum = 0;
            int[] array = new int[0];
            int temp;

            Console.WriteLine("Список команд:");
            Console.WriteLine("sum - вывести сумму введенных элементов");
            Console.WriteLine("sort - вывести отсортированный массив");
            Console.WriteLine("exit - выйти из программы");
            Console.WriteLine("back - назад к меню");
          
            while (contin == true)
            {
                Console.WriteLine("Введите число или команду из списка выше");
                userCommand = Console.ReadLine();

                if (userCommand != "sum" && userCommand != "sort" && userCommand != "exit" && userCommand != "back")
                {                                                                
                            int[] tempArray = new int[array.Length + 1];
                            for (int i = 0; i < array.Length; i++)
                            {
                                tempArray[i] = array[i];
                            }
                            array = tempArray;
                            array[array.Length-1] = Convert.ToInt32(userCommand);                                                                                                            
                }

                if (userCommand == "sum") 
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        sum += array[i];
                    }
                    Console.WriteLine("Сумма элементов: "+sum);
                    sum = 0;
                }
                if (userCommand == "exit")
                {
                    Environment.Exit(0);
                }
                if (userCommand == "sort")
                {
                    for (int i = 0; i < array.Length-1; i++)
                    {
                        for (int j = i+1; j < array.Length; j++)
                        {
                            if (array[i] > array[j]) 
                            {
                                temp = array[i];
                                array[i] = array[j];
                                array[j] = temp;
                            }
                        }
                    }
                    Console.WriteLine("Отсортированный массив: ");
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        Console.Write(array[i] + "    ");
                    }
                    Console.WriteLine();
                }
                if (userCommand == "back")
                {
                    contin = false;    
                }              
                               
            }
        }
    }
}
