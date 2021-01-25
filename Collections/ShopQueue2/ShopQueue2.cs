using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopQueue
{   
    class Program
    {
        static void Main(string[] args)
        {
            Random randomNumber = new Random();
            Queue<int> clients = new Queue<int>();
            int accountSum = 0;
            int clientsQuantity = randomNumber.Next(5, 11), j = 0;
            for (int i = 1; i <= clientsQuantity; i++)
            {
                clients.Enqueue(randomNumber.Next(99, 10000));
            }
            foreach (int man in clients)
            {
                j++;
                Console.WriteLine("клиент " + j.ToString() + ": покупка на сумму " + man.ToString());                
            }
            j = 0;
            while (clients.Count != 0)
            {
                j++;
                Console.WriteLine("Сейчас обслуживается клиент: "+ j.ToString());                               
                Console.WriteLine("Сумма на счету: " + accountSum.ToString());
                Console.ReadKey();
                accountSum += clients.Dequeue();
                Console.Clear();                
            }
            Console.WriteLine("Итого на счету: " + accountSum.ToString());
            Console.ReadKey();

        }
    }
}
