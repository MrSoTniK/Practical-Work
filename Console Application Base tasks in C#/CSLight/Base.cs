using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("ЯЮниор. Основы программирования.");
            Console.WriteLine("Задания:");
            Console.WriteLine("1. Картинки");
            Console.WriteLine("2. Поликлиника");
            Console.WriteLine("3. Магазин");
            Console.WriteLine("4. Работа со строками");
            mark:
            Console.WriteLine("Выберите задание, введя его номер по списку выше");
            int key_val = Convert.ToInt32(Console.ReadLine());
            if(key_val == 1)
            {
                Console.WriteLine("На экране в специальной зоне выводятся картинки, по 3 в ряд. Всего у пользователя в альбоме 52 картинки."+
                "Код должен вывести, сколько полностью заполненных рядов можно будет вывести, и сколько картинок будет сверх меры."+
                "В качестве решения ожидается объявленные переменные с необходимыми значениями и вывод необходимых данных основываясь на значениях переменных.");
                Task2 T2 = new Task2();
                T2.Solution();
                if (T2.next == "0") goto mark;
            }
            if (key_val == 2)
            {
                Console.WriteLine("Вы заходите в поликлинику и видите огромную очередь из старушек, вам нужно рассчитать время ожидания в очереди.");
                Task3 T3 = new Task3();
                T3.Solution();
                if (T3.next == "0") goto mark;
            }
            if (key_val == 3)
            {
                Console.WriteLine("Вы приходите в магазин и хотите купить за своё золото кристаллы. В вашем кошельке есть какое-то количество золота,"+ 
                "продавец спрашивает у вас, сколько кристаллов вы хотите купить? После сделки у вас остаётся какое-то количество золото и появляется"+ 
                "какое-то количество кристаллов.");
                Task4 T4 = new Task4();
                T4.Solution();
                if (T4.next == "0") goto mark;
            }
            if (key_val == 4)
            {
                Console.WriteLine("Вы задаете вопросы пользователю, по типу <<Как вас зовут?>>, <<Какой ваш знак зодиака?>>"+
                "и тд, после чего по данным, которые он ввел формируете небольшой текст о пользователе.");
                Task5 T5 = new Task5();
                T5.Solution();
                if (T5.next == "0") goto mark;
            }
        }
    }

}
