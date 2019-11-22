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
            int crystals;
            bool crystalsAmount;

            Console.WriteLine("Добро пожаловать в магазин кристаллов. 1 кристалл = 10 единиц золота.");           
            Console.WriteLine("Сколько у вас золота?");
            gold = Convert.ToInt32(Console.ReadLine());              
            Console.WriteLine("За "+gold+" золота "+"Вы можете купить "+(gold/10)+" кристаллов");
            Console.WriteLine("Сколько кристаллов вы хотите купить?");
            crystals = Convert.ToInt32(Console.ReadLine());
            crystalsAmount = crystals <= gold / 10;
            Console.WriteLine("У вас " + (crystals * Convert.ToInt32(crystalsAmount)) + " кристаллов и " 
            + (gold - crystals * 10 * Convert.ToInt32(crystalsAmount)) + " золота");
            next = Console.ReadLine();
        }
    }
}
