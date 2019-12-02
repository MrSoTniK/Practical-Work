using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class WorkWithColumnsAndRows
    {       
        public void Solution()
        {
           bool contin = true;
           string exit;

           while (contin == true)
           {
              Random rand = new Random();
              int[,] array = new int[rand.Next(2, 5), rand.Next(1, 5)];
              int rowSum = 0;
              int columnMultiplication = 1;
              

           
              for (int i = 0; i < array.GetLength(0); i++)
              {
                  for (int j = 0; j < array.GetLength(1); j++) 
                  {
                      array[i, j] = rand.Next(1, 11);
                      Console.Write(array[i,j]+"    ");
                      if(i == 1)
                      {
                          rowSum += array[i, j];
                      }
                      if(j == 0)
                      {
                          columnMultiplication *= array[i, j];
                      }
                  }
                  Console.WriteLine();
              }
              Console.WriteLine("Сумма элементов второй строки: " + rowSum);
              Console.WriteLine("Произведение элементов первого столбца: " + columnMultiplication);
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
