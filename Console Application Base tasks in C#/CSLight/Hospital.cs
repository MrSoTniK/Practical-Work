using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight
{
    class Task3
    {
        public string next;
        public void Solution() 
        {
            int quant;
            int time_v = 10;
            bool need_hours;
            int all_time;
            int hours;
            int min;

            Console.WriteLine("Введите количество людей в очереди ");
            quant = Convert.ToInt32(Console.ReadLine());          
            Console.WriteLine("Фиксированное время приема одного человека: " + time_v+" мин");
            all_time = quant * time_v;
            need_hours = all_time >= 60;
            hours = all_time / 60 * Convert.ToInt32(need_hours);
            min = all_time - hours * 60;
            Console.WriteLine("Время, которое нужно отстоять в очереди: "+hours+" ч "+min+" мин ");
            Console.WriteLine("Назад к выбору задания - 0");
            next = Console.ReadLine(); 
        }
    }
}
