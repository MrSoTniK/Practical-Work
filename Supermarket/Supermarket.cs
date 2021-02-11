using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Supermarket supermarket = new Supermarket();
            supermarket.AddGoods();
            bool isExit = false;;
            string userInput;            

            while(isExit !=true)
            {
                Console.WriteLine("1 - создать очередь");
                Console.WriteLine("2 - обслужить очередь");
                Console.WriteLine("3 - выход");

                userInput = Console.ReadLine();
                switch (userInput) 
                {
                    case "1":
                        supermarket.MakeQueue();
                        break;
                    case "2":
                        supermarket.ServeQueue();
                        break;
                    case "3":
                        isExit = true;
                        break;
                }
                Console.Clear();
            }
            Environment.Exit(0);           
        }
    }

    class Supermarket 
    {
        private Queue<Client> _clients;
        private Dictionary<int, Product> _goods;

        public Supermarket() 
        {
            _clients = new Queue<Client>();
            _goods = new Dictionary<int, Product>();
        }

        public void AddGoods() 
        {
            _goods.Add(0, new Product("Туалетная бумага", 75));
            _goods.Add(1, new Product("Колбаса", 350));
            _goods.Add(2, new Product("Селедка", 500));
            _goods.Add(3, new Product("Сыр", 450));
            _goods.Add(4, new Product("Хлеб", 35));
            _goods.Add(5, new Product("Печенье", 50));
            _goods.Add(6, new Product("Вода", 30));
            _goods.Add(7, new Product("Газировка", 32));
            _goods.Add(8, new Product("Шоколадка", 25));
            _goods.Add(9, new Product("Спички", 15));            
        }

        public void MakeQueue() 
        {
            Random randomNumber = new Random();
            int clientsQuantity = randomNumber.Next(1, 10);
            int money;

            for (int i = 1; i <= clientsQuantity; i++) 
            { 
                money = randomNumber.Next(0, 5000);
                _clients.Enqueue(new Client(money, _goods));                
            }
            Console.WriteLine("Очередь создана.");
            Console.ReadKey();
        }

        public void ServeQueue() 
        {
            bool isSuccess;
            int i = 0;

            while(_clients.Count != 0) 
            {
                isSuccess = false;
                while (isSuccess != true)
                {
                    Console.WriteLine("Клиент "+i.ToString());
                    _clients.Peek().ShowClient();
                    isSuccess = _clients.Peek().StartPaymentAttempt();
                }
                _clients.Dequeue();
                i++;
                Console.ReadKey();
                Console.WriteLine();
            }          
        }

    }

    class Client 
    {
        private int _money;
        private List<Product> _basket;
        private int _amountToPay;

        public Client(int money, Dictionary<int, Product> goods) 
        {
            _money = money;
            _basket = new List<Product>();
            FillBasket(goods);
        }

        public void FillBasket(Dictionary<int, Product> goods) 
        {
            Random randomNumber = new Random();
            int purchaseQuantity = randomNumber.Next(1, 10);
            int prodactID;
            _amountToPay = 0;

            for (int i = 1; i <= purchaseQuantity; i++) 
            {
                prodactID = randomNumber.Next(0, 10);
                _basket.Add(goods[prodactID]);
                _amountToPay += goods[prodactID].Price;
            }
        }

        public bool StartPaymentAttempt() 
        { 
            Random randomNumber = new Random();
            bool isSuccess = false;
            int productID;

            if (_money >= _amountToPay)
            {
                isSuccess = true;
            }
            else
            {
                productID = randomNumber.Next(0, _basket.Count);
                _amountToPay -= _basket[productID].Price;
                _basket.RemoveAt(productID);
            }
                                                  
            return isSuccess;
        }

        public void ShowClient() 
        {
            Console.WriteLine("Деньги: " + _money.ToString());
            Console.WriteLine("Корзина:");
            foreach (Product product in _basket) 
            {
                Console.WriteLine(product.Name + " - " + product.Price);
            }
            Console.WriteLine("К оплате: " + _amountToPay.ToString());
        }

    }

    class Product 
    {
        public string Name { get; private set; }
        public int Price {get; private set;}

        public Product(string name, int price) 
        {
            Name = name;
            Price = price;
        }
    }
}
