using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    class Task5
    {
        public string next;
        public void Solution()
        {
            string name;
            int age;
            string sign;
            string work;

            Console.WriteLine("Как вас зовут?");
            name = Console.ReadLine();
            Console.WriteLine("Сколько вам лет?");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Какой у вас знак зодиака?");
            sign = Console.ReadLine();
            Console.WriteLine("Какова ваша профессия?");
            work = Console.ReadLine();
            Console.WriteLine("Вас зовут - " + name + " . " + "Ваш возраст - " + Convert.ToString(age) + " . " + "Ваша профессия - " + work + " . ");
            Console.WriteLine("Назад к выбору задания - 0");
            next = Console.ReadLine();

        }
    }
}
