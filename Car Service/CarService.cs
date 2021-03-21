using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            string userInput;

            while (isExit == false) 
            {
                Carservice carservice = new Carservice();
                bool isNewGame = false;

                while (isNewGame == false)
                {
                    Console.WriteLine("Автосервис");
                    Console.WriteLine("Купить детали перед началом нового обслуживания? 1 - да, люб. др. значение - нет");
                    userInput = Console.ReadLine();
                    Console.Clear();
                    if (userInput == "1") 
                    {
                        carservice.BuyMenu();
                    }
                    Console.Clear();
                    carservice.CreateQueue();
                    isNewGame = carservice.StartService();
                }

                Console.WriteLine("Начать новую игру? 1 - Да, люб. др. значение - нет");
                userInput = Console.ReadLine();
                if (userInput != "1") 
                {
                    isExit = true;
                }
                Console.Clear();
            }           
        }
    }

    class Carservice
    {
        private int _money;
        private Storage _storage;
        private int _priceForWork;
        private Queue<Car> _clients;
        private Random _randomNumber;

        public Carservice() 
        {
            _randomNumber = new Random();
            _storage = new Storage();
            _clients = new Queue<Car>();
            _money = 5000;
            _priceForWork = 1000;
        }

        public void CreateQueue() 
        {
            int index; 
            int quantity = _storage.CountDetails();;            

            for (int i = 0; i <= 10; i++)
            {                
                index = _randomNumber.Next(0, quantity);
                _clients.Enqueue(new Car(index));
            }       
        }

        public void BuyMenu() 
        {
            string userDetail, userInput;
            bool isExist, isExit = false;
            int  index;

            while (isExit == false) 
            {
                ShowMenu();
                Console.WriteLine("Меню покупки:");
                Console.WriteLine("Введите название детали для покупки");
                userDetail = Console.ReadLine();
                isExist = _storage.CheckDetail(userDetail, out index);

                if (isExist == true)
                {
                    BuyDetail(index);
                }
                else
                {
                    Console.WriteLine("Такой детали не существует.");
                }

                Console.WriteLine("Продолжить покупки? 1 - да, люб. др. значение - нет");
                userInput = Console.ReadLine();
                if (userInput != "1")
                {
                    isExit = true;
                }
            }           
        }      

        public bool StartService() 
        {
            bool isExist, isBankrupt = false;            
            string userInput;
            int index, clientNumber = 0;;

            while (_clients.Count != 0 && isBankrupt != true) 
            {
                ShowMenu();
                Console.WriteLine("Клиент номер : " + clientNumber.ToString());
                _clients.Peek().Show();

                Console.WriteLine("Введите название детали для починки: ");
                userInput = Console.ReadLine();
                isExist = _storage.CheckDetail(userInput, out index);

                if (isExist == true) 
                {
                    isBankrupt = RepairCar(index, userInput);
                    _clients.Dequeue();
                }
                else 
                {                    
                    isBankrupt = PayPenalty();
                    _clients.Dequeue();                
                }
                clientNumber++;
                Console.Clear();
            }

            return isBankrupt;
        }

        private void BuyDetail(int index) 
        {
            string userNumber;
            bool isSuccess;
            int  price, quantity;

            Console.WriteLine("Введите количество деталей");
            userNumber = Console.ReadLine();
            isSuccess = Int32.TryParse(userNumber, out quantity);
            if (isSuccess == true && quantity > 0)
            {
                price = _storage.GetDetailPrice(index) * quantity;
                if (_money >= price)
                {
                    _storage.AddDetail(index, quantity);
                    _money -= price;
                    Console.WriteLine("Покупка успешно совершена!");
                }
                else
                {
                    Console.WriteLine("У вас недостаточно денег для покупки!");
                }
            }
            else
            {
                Console.WriteLine("Введено неверное значение!");
            }
        }

        private void ShowMenu() 
        {
            Console.WriteLine("Автосервис");
            Console.WriteLine("Склад:");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("деталь");
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.SetCursorPosition(30, Console.CursorTop);
            Console.Write("цена, руб.");
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.SetCursorPosition(50, Console.CursorTop);
            Console.WriteLine("количество, шт.");
            _storage.Show();
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("Баланс: " + _money.ToString() + " руб.");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine();
        }

        private bool RepairCar(int index, string userInput) 
        {
            bool isBankrupt = false;
            bool isRepaired = _clients.Peek().CheckDetail(userInput);

            if (isRepaired == true)
            {
                _storage.RemoveDetail(index);
                _money += _storage.GetDetailPrice(index) + _priceForWork;               
                Console.WriteLine("Ремонт завершен.");
                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                Console.ReadKey();
            }
            else
            {               
               isBankrupt = PayPenalty();
            }

            return isBankrupt;
        }

        private bool PayPenalty() 
        {
            bool isbankrupt = false;

            Console.WriteLine("Вы не справились! Вам штраф!");
            if (_money >= 1000)
            {
                _money -= 1000;
                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                Console.ReadKey(); 
            }
            else
            {
                isbankrupt = true;
                Console.WriteLine("Вы - банкрот! Игра окончена.");
                Console.WriteLine("Нажмите любую кнопку для продолжения...");
                Console.ReadKey();               
            }          
          
            return isbankrupt;
        }
    }

    class Storage
    {
        private List<StorageDetail> _details;
        
        public Storage() 
        {
            _details = new List<StorageDetail>();
            CreateStorage();
        }

        public void Show() 
        {
            foreach (StorageDetail detail in _details) 
            {
                detail.Show();                   
            }
        }
           
        public void AddDetail(int index, int quantity) 
        {
            _details[index].Add(quantity);
        }

        public void RemoveDetail(int index) 
        {
            _details[index].Remove();
        }

        public int CountDetails() 
        {
            return _details.Count;
        }

        private void CreateStorage() 
        {
            _details.Add(new StorageDetail("карбюратор", 4500));
            _details.Add(new StorageDetail("свеча зажигания", 450));
            _details.Add(new StorageDetail("фильтр воздушный", 650));
            _details.Add(new StorageDetail("фильтр масляной", 670));
            _details.Add(new StorageDetail("карданный вал", 800));
            _details.Add(new StorageDetail("приводной вал", 800));
            _details.Add(new StorageDetail("датчик давления", 1000));
            _details.Add(new StorageDetail("термостат", 900));
            _details.Add(new StorageDetail("амортизатор", 1200));
            _details.Add(new StorageDetail("стартер", 3500));
        }

        public int GetDetailPrice(int index)
        {
            int price;
            price = _details[index].GetPrice();
            return price;
        }

        public bool CheckDetail(string userInput, out int index)
        {
            bool isExist = false, isNull = true;
            index = 0;

            foreach (StorageDetail detail in _details)
            {
                isExist = detail.Check(userInput);
                if (isExist == true)
                {
                    isNull = detail.CheckQuantity();
                    break;
                }
                index++;
            }

            if (isNull == true)
            {
                if (isExist == false)
                {
                    Console.WriteLine("Такой детали не существует.");
                }
                else
                {
                    Console.WriteLine("Такой детали сейчас нет на складе (количество равно нулю).");
                    isExist = false;
                }
            }

            return isExist;
        }
    }

    class Car 
    {
        private Detail _breakage;
        private List<Detail> _carDetails;       

        public Car(int index) 
        {           
            _carDetails = new List<Detail>();
            DetermineDetails();
            CreateBreakage(index);
        }

        public void Show() 
        {
            Console.Write("Поломка: ");
            _breakage.Show();
            Console.WriteLine();
        }

        public bool CheckDetail(string userInput) 
        {
            bool isRepaired = false;

            isRepaired = _breakage.Check(userInput.ToLower());

            return isRepaired;
        }

        private void DetermineDetails() 
        {
            _carDetails.Add(new Detail("карбюратор", 4500));
            _carDetails.Add(new Detail("свеча зажигания", 450));
            _carDetails.Add(new Detail("фильтр воздушный", 650));
            _carDetails.Add(new Detail("фильтр масляной", 670));
            _carDetails.Add(new Detail("карданный вал", 800));
            _carDetails.Add(new Detail("приводной вал", 800));
            _carDetails.Add(new Detail("датчик давления", 1000));
            _carDetails.Add(new Detail("термостат", 900));
            _carDetails.Add(new Detail("амортизатор", 1200));
            _carDetails.Add(new Detail("стартер", 3500));
        }

        private void CreateBreakage(int index) 
        {           
            _breakage = _carDetails[index];
        }
    }   

    class Detail 
    {       
        protected string Name;
        protected int Price;              

        public Detail(string name, int price) 
        {           
            Name = name;
            Price = price;                 
        }       

        public bool Check(string detailName)
        {
            bool isExist = false;

            if (Name == detailName.ToLower()) 
            {
                isExist = true;
            }

            return isExist;
        }

        public int GetPrice() 
        {
            return Price;
        }

        public virtual void Show()
        {
            Console.Write(Name);
        }
    }

    class StorageDetail : Detail
    {
        private int _quantity;       

        public StorageDetail(string name, int price) : base(name, price)
        {           
             _quantity = 1;           
        }

        public void Add(int quantity) 
        {
            _quantity += quantity;
        }

        public void Remove() 
        {
            _quantity--;
        }

        public bool CheckQuantity()
        {
            bool isNull = false;

            if (_quantity == 0) 
            {
                isNull = true;
            }

            return isNull;
        }

        public override void Show() 
        {
            Console.Write(Name);
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.SetCursorPosition(30, Console.CursorTop);
            Console.Write(Price.ToString());            
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.SetCursorPosition(50, Console.CursorTop);
            Console.WriteLine( _quantity.ToString());
        }
    }   
}
