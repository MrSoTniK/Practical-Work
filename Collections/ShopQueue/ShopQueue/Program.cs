using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopQueue
{
    public class Client 
    {
        public string client;
        public int clientID;
        public int purchaseSum;

        public Client(string person, int ID, int sum) 
        {
            client = person;
            clientID = ID;
            purchaseSum = sum;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Random randomNumber = new Random();            
            Queue<Client> clients = new Queue<Client>();
            int accountSum = 0;
            int clientsQuantity = randomNumber.Next(5, 11);
            for (int i = 1; i <= clientsQuantity; i++)
            {
                clients.Enqueue(new Client("клиент", i, randomNumber.Next(99, 10000)));
            }
            while (clients.Count != 0)
            {
                foreach (Client man in clients)
                {
                    Console.WriteLine(man.client + " - " + man.clientID.ToString() + ": покупка на сумму " + man.purchaseSum.ToString());                   
                }
                Console.WriteLine("Сейчас обслуживается: " + clients.Peek().client + " " + clients.Peek().clientID.ToString());
                accountSum += clients.Dequeue().purchaseSum;
                Console.WriteLine("Сумма на счету: " + accountSum.ToString());
                Console.ReadKey();
                Console.Clear();                             
            }
            Console.WriteLine("Итого на счету: " + accountSum.ToString());
            Console.ReadKey();

        }
    }
}
