using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    class Task2
    {
        public string next;
        public void Solution()
        {
            int GenAmount = 52;
            int row = 3;
            Console.WriteLine("Всего картинок: " + GenAmount);
            Console.WriteLine("Всего рядов: " + row);
            int AllPic = GenAmount / row;
            int balance = GenAmount - AllPic*row;
            Console.WriteLine("Кол-во заполненных рядов " + AllPic);
            Console.WriteLine("Остаток: " + balance);
            Console.WriteLine("Назад к выбору задания - 0");
            next =Console.ReadLine();           
         }

    }
}
