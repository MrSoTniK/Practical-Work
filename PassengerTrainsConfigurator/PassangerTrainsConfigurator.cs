using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PassengerTrainsConfigurator
{
    class Train
    {
        private string _direction;
        private int _passengersQuantity;        
        private List<Carriage> _carriages;

        public Train() 
        {
            _carriages = new List<Carriage>(); 
        }
            
        public void CreateDirection() 
        {
            Console.WriteLine("Введите название направления");
            _direction = Console.ReadLine();
        }

        public void SellTickets() 
        {
            Random random = new Random();
            _passengersQuantity = random.Next(99, 1000);
            Console.WriteLine("Количество пассажиров на поезд: " + _passengersQuantity.ToString());
        }

        public void AssignCarriages(List<Carriage> carriages) 
        {
            for (int i = 0; i < carriages.Count; i++) 
            {                
                Carriage carriage = carriages[i];
                _carriages.Add(carriage);
            }
                
            int restPassengers = _passengersQuantity, 
                carriagesQuantity = 0, 
                passengesInCarriages;

            foreach (Carriage carriage in _carriages) 
            {
                carriagesQuantity = 0;

                if (restPassengers > 0) 
                {
                    if (restPassengers > carriage.Spaciousness) 
                    {
                        carriagesQuantity = restPassengers / carriage.Spaciousness;
                        passengesInCarriages = carriagesQuantity * carriage.Spaciousness;
                        restPassengers -= passengesInCarriages;
                    }
                    else 
                    {
                        carriagesQuantity = 1;
                        restPassengers = 0;
                    }                   
                }

                carriage.Quantity = carriagesQuantity;
                Console.WriteLine(carriage.Name + ": Количество - " + carriage.Quantity.ToString());
            }
        }

        public void SendTrain(List<Train> trains, Train train) 
        {
            trains.Add(train);          
        }

        public void ShowTrain() 
        {
            Console.Write("Направление: " + _direction.ToString() + "; пассажиров: " + _passengersQuantity.ToString() + "; вагоны:");
            foreach (Carriage carriage in _carriages) 
            {
                if (carriage.Quantity != 0)
                {
                    Console.Write(" " + carriage.Name + ": количество - " + carriage.Quantity.ToString() + ", вместительность - " + carriage.Spaciousness.ToString());
                }               
            }
        }
    }

    class Carriage
    {
        public string Name;
        public int Quantity;
        public int Spaciousness{ get; private set;}

        public Carriage(string name, int spaciousness, int quantity = 0) 
        {
            Name = name;
            Quantity = quantity;
            Spaciousness = spaciousness;
        }

        public void ChangeSpaciousness() 
        {
            bool isNumber;
            string userInput;
            int spaciousness;

            userInput = Console.ReadLine();
            isNumber = Int32.TryParse(userInput, out spaciousness);
            if (isNumber == true && spaciousness >= 0)
            {
                Spaciousness = spaciousness;
            }
            else 
            {
                Console.WriteLine("Ошибка.Введено неверное значение!");
            }
        }

        public void ShowCarriage() 
        {           
            Console.WriteLine("имя: " + Name + " Вместительность: " + Spaciousness);
        }

        public void ChangeSpaciounessFromValue(int value) 
        {          
            Spaciousness = value;
        }
    }

    class BigCarriage : Carriage 
    {
        public BigCarriage() : base("Большой", 40, 0) { }
    }

    class AverageCarriage : Carriage
    {
        public AverageCarriage() : base("Средний", 20, 0) { }
    }

    class SmallCarriage : Carriage
    {
        public SmallCarriage() : base("Малый", 10, 0) { }
    }

    class Program
    {
        static void ShowTrains(List<Train> trains) 
        {
            foreach (Train train in trains) 
            {
                train.ShowTrain();
            }
        }

        static void CreateNewTrain(List<Train> trains, List<Carriage> carriages) 
        {
            string userInput;
            Train train = new Train();

            Console.WriteLine("Создание направления:");
            train.CreateDirection();

            Console.WriteLine("Введите любую клавишу для начала продажи билетов.");
            Console.ReadKey();
            train.SellTickets();

            Console.WriteLine("Прикрепление вагонов к поезду:");
            train.AssignCarriages(carriages);

            Console.WriteLine("Отправить поезд? 1 -да, люб. др. значение - нет");
            userInput = Console.ReadLine();
            if (userInput == "1")
            {
                train.SendTrain(trains, train);
            }           
        }

        static void ChangeCarriages(List<Carriage> carriages) 
        {            
            for(int i = 0; i< carriages.Count;i++)
            {
                Console.WriteLine("Введите вместительность для вагона: "+carriages[i].Name);
                carriages[i].ChangeSpaciousness();               
            }          
        }

        static void SortCarriagesArray(List<Carriage> carriages) 
        {
       
            int spaciouness, quantity;
            string name;

            for (int i = 0; i < carriages.Count - 1; i++)
            {
                for (int j = i + 1; i < carriages.Count; j++)
                {
                    if (carriages[i].Spaciousness < carriages[j].Spaciousness)
                    {
                        spaciouness = carriages[i].Spaciousness;
                        name = carriages[i].Name;
                        quantity = carriages[i].Quantity;

                        carriages[i].ChangeSpaciounessFromValue(carriages[j].Spaciousness);
                        carriages[i].Name = carriages[j].Name;
                        carriages[i].Quantity = carriages[j].Quantity;

                        carriages[j].ChangeSpaciounessFromValue(spaciouness);
                        carriages[j].Name = name;
                        carriages[j].Quantity = quantity;
                    }
                }
            }
           //   Предыдущий метод сортировки:

           //   int maxValue = Int32.MinValue;
           //   int maxValueIndex = 0;
           //   List<Carriage> sortingCollection = new List<Carriage>();

           //   while(carriages.Count != 0)
           //   {
           //        for (int i = 0; i < carriages.Count; i++)
           //       {
           //            if (carriages[i].Spaciousness > maxValue)
           //           {
           //               maxValue = carriages[i].Spaciousness;
           //               maxValueIndex = i;
           //           }
           //       }
           //       sortingCollection.Add(carriages[maxValueIndex]);
           //       carriages.Remove(carriages[maxValueIndex]);
           //    }
           //    carriages = sortingCollection;
        }

        static void ShowCarriages(List<Carriage> carriages) 
        {
            Console.WriteLine("типы вагонов:");
            foreach (Carriage carriage in carriages)
            {
                carriage.ShowCarriage();
            }
        }

        static void Main(string[] args)
        {
            Carriage bigCarriage = new BigCarriage();
            Carriage averageCarriage = new AverageCarriage();
            Carriage smallCarriage = new SmallCarriage();
            List<Train> trains = new List<Train>();
            List<Carriage> carriages = new List<Carriage>(3) { bigCarriage, averageCarriage, smallCarriage };     
            
            bool isExit = false;
            string userInput;

            while (isExit == false)
            {
                ShowTrains(trains);
                Console.SetCursorPosition(0,10);
                ShowCarriages(carriages);
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("1 - Создать новый поезд");
                Console.WriteLine("2 - Изменить вместительность вагонов");
                Console.WriteLine("3 - выход из программы");

                userInput = Console.ReadLine();
                switch (userInput) 
                { 
                    case "1":
                        CreateNewTrain(trains, carriages); 
                        break;
                    case "2":
                        ChangeCarriages(carriages);
                        SortCarriagesArray(carriages);                        
                        break;
                    case "3":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Ошибка.Введено неверное значение");
                        break;
                }
                Console.Clear();
            }

            Environment.Exit(0);
        }
    }
}

