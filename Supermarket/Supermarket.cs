using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductList productList = new ProductList();
            Queue<Client> clients = new Queue<Client>();
            productList.MakeProductList();

            bool isExit = false;
            string userInput;

            Console.WriteLine("1 - Создать очередь");
            Console.WriteLine("2 - Обслужить очередь");
            Console.WriteLine("3 - Выход");

            while (isExit == false)
            {
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateQueue(clients, productList);
                        break;
                    case "2":
                        ServeQueue(clients);
                        break;
                    case "3":
                        isExit = true;
                        break;
                }
            }
            Environment.Exit(0);
        }

        static void CreateQueue(Queue<Client> clients, ProductList productList)
        {           
            Random randomNumber = new Random();
            int clientsNumber = randomNumber.Next(3, 10);

            for (int i = 0; i < clientsNumber; i++)
            {
                Client client = new Client();
                client.FillBasket(productList.Goods);
                clients.Enqueue(client);
            }

            Console.WriteLine("Очередь создана");
        }

        static void ServeQueue(Queue<Client> clients)
        {
            Client currentClient;
            int i = 0;
            int summary = 0;
            bool isSuccess;

            while (clients.Count() != 0)
            {
                isSuccess = false;
                while (isSuccess != true)
                {
                    currentClient = clients.Peek();
                    summary = ShowClient(currentClient, summary, i);
                    Console.WriteLine("Нажмите любую кнопку для обслуживания клиента");
                    Console.ReadKey();
                    isSuccess = ServeClient(currentClient, summary, clients);
                }
                i++;
            }
        }

        static int ShowClient(Client currentClient, int summary, int clientID)
        {
            Console.WriteLine("Клиент " + clientID.ToString() + ":");

            summary = 0;
            foreach (Product product in currentClient.Basket)
            {
                Console.WriteLine(product.Name + " - Цена: " + product.Price.ToString());
                summary += product.Price;
            }
            Console.WriteLine("Итоговая сумма: " + summary.ToString());

            return summary;
        }

        static bool ServeClient(Client currentClient, int summary, Queue<Client> clients)
        {
            bool isSuccess;

            if (currentClient.Money >= summary)
            {
                clients.Dequeue();
                isSuccess = true;
            }
            else
            {
                currentClient.RemoveFromBasket();
                isSuccess = false;
            }

            return isSuccess;
        }

    }

    class Client
    {
        public int Money { get; private set; }
        public List<Product> Basket { get; private set; }

        public Client()
        {
            Random randomNumber = new Random();
            Money = randomNumber.Next(0, 5001);
            Basket = new List<Product>();
        }

        public void FillBasket(List<Product> goods)
        {
            Random randomNumber = new Random();
            int goodsQuantity = goods.Count() - 1;
            int productsInBusketQuantity = randomNumber.Next(1, 5);
            int pickedNumber;

            for (int i = 1; i <= productsInBusketQuantity; i++)
            {
                pickedNumber = randomNumber.Next(0, goodsQuantity);
                Basket.Add(goods[pickedNumber]);
            }
        }

        public void RemoveFromBasket()
        {
            Random randomNumber = new Random();
            int productsInBusketQuantity = Basket.Count() - 1;
            int pickedNumber = randomNumber.Next(0, productsInBusketQuantity);

            Basket.Remove(Basket[pickedNumber]);
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

    struct ProductList
    {
        public List<Product> Goods { get; private set; }

        public void MakeProductList()
        {
            Goods = new List<Product>();
            Goods.Add(new Product("колбаса", 350));
            Goods.Add(new Product("хлеб", 20));
            Goods.Add(new Product("сыр", 400));
            Goods.Add(new Product("творог", 50));
            Goods.Add(new Product("вода", 35));
        }
    }
}
