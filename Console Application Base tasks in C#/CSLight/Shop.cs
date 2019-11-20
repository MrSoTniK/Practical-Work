using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    class Task4
    {
        public string next;
        public void Solution()
        {
            int gold;           
            int shop_crystals = 500;
            int buyed_crystals;
            int rest_gold;
            int rest_crystals;
            bool crystals_amount;

            Console.WriteLine("Добро пожаловать в магазин кристаллов. 1 кристалл = 10 единиц золота");
            Console.WriteLine("Всего в магазине доступно кристаллов в количестве:" + shop_crystals);
            Console.WriteLine("Сколько у вас единиц золота?");
            gold = Convert.ToInt32(Console.ReadLine());
            crystals_amount = gold / 10 < shop_crystals;
            buyed_crystals = Convert.ToInt32(crystals_amount) * gold / 10 + (shop_crystals * (1 - Convert.ToInt32(crystals_amount)));
            Console.WriteLine("На " + gold + " золота можно купить " + buyed_crystals+" кристалл(-ов)");
            rest_gold = gold - buyed_crystals*10;
            Console.WriteLine("При этом у вас останется золота: " + rest_gold);
            rest_crystals = shop_crystals - buyed_crystals;
            Console.WriteLine("А в магазине останется " + rest_crystals);
            Console.WriteLine("Назад к выбору задания - 0");
            next = Console.ReadLine();
        }
    }
}
