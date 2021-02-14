using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerTrainsConfigurator_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            string userInput;
            Station station = new Station();           

            while (isExit == false)
            {
                station.ShowCurrentTrain();                                 
                Console.WriteLine("1 - Создать новый поезд");               
                Console.WriteLine("2 - Показать поезда");
                Console.WriteLine("3 - выход");

                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        station.CreateTrain();
                        break;
                    case "2":
                        station.ShowTrains();
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
   
    class Station 
    {       
        private int _passengersQuantity;
        private List<Train> _trains;
        private List<Carriage> _stationCarriages;

        public Station() 
        {
            _trains = new List<Train>();
            _stationCarriages = new List<Carriage>();
            AddStationCarriages();
        }

        private void AddStationCarriages() 
        {
            _stationCarriages.Add(new Carriage("большой", 80));
            _stationCarriages.Add(new Carriage("средний", 40));
            _stationCarriages.Add(new Carriage("малый", 20));
        }      

        public void CreateTrain() 
        {
            Console.WriteLine("Введите направление.");
            string direction = Console.ReadLine();

            Random randomNumber = new Random();
            _passengersQuantity = randomNumber.Next(1, 2501);
            Console.WriteLine("Количество пассажиров: " + _passengersQuantity.ToString());

            Train train = new Train(direction, _passengersQuantity);
            train.AssignCarriages(_stationCarriages);
            _trains.Add(train);
            Console.WriteLine("Поезд создан.");

            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }

        public void ShowTrains() 
        {
            foreach (Train train in _trains) 
            {
                train.ShowTrain();
                Console.WriteLine();
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }

        public void ShowCurrentTrain() 
        {
            if (_trains.Count != 0) 
            {
                int lastIndex = _trains.Count - 1;
                _trains[lastIndex].ShowTrain();
            }            
        }
    }

    class Train 
    {
        private string _direction;
        private Dictionary<Carriage, int> _carriages;
        private int _passengersQuantity;

        public Train(string direction, int passengersQuantity) 
        {
            _direction = direction;
            _carriages = new Dictionary<Carriage, int>();
            _passengersQuantity = passengersQuantity;
        }

        public void AssignCarriages(List<Carriage> stationCarriages) 
        {
            int restPassengers = 0,
                currentPassengersQuantity = _passengersQuantity,
                carriagesQuantity = 0;

            foreach (Carriage carriage in stationCarriages)
            {
                carriagesQuantity = carriage.CalculateQuantity(currentPassengersQuantity, carriage.Spaciousness, out restPassengers);
                currentPassengersQuantity = restPassengers;

                if (carriagesQuantity != 0) 
                {
                    _carriages.Add(carriage, carriagesQuantity);
                }                
            }

            if (restPassengers != 0) 
            {                
                int lastIndex = _carriages.Count - 1;
                int minSpaciousnessIndex = stationCarriages.Count - 1;                
                Carriage carriage = stationCarriages[minSpaciousnessIndex];

                bool isContain = _carriages.Keys.Contains<Carriage>(stationCarriages[minSpaciousnessIndex]);
                if (isContain == true) 
                {
                    _carriages[carriage] += 1;
                }
                else 
                {
                    _carriages.Add(carriage, 1);
                }
            }
        }

        public void ShowTrain() 
        {
            Console.WriteLine("направление: " + _direction);
            Console.WriteLine("пассажиров: " + _passengersQuantity.ToString());

            foreach (KeyValuePair<Carriage, int> carriage in _carriages) 
            {
                carriage.Key.ShowCarriage();
                Console.WriteLine("количество: " + carriage.Value.ToString());
                Console.WriteLine();
            }
        }
    }

    class Carriage 
    {
        private string _name;
        public int Spaciousness { get; private set; }
       
        public Carriage(string name, int spaciousness, int quantity = 0) 
        {
            _name = name;
            Spaciousness = spaciousness;
        }

        public int CalculateQuantity(int currentPassengersQuantity, int spaciousness, out int restPassengers) 
        {
            restPassengers = currentPassengersQuantity;
            int  carriagesQuantity = 0,
                passengesInCarriages;

            if (restPassengers > 0)
            {
                if (restPassengers > spaciousness)
                {
                    carriagesQuantity = restPassengers / spaciousness;
                    passengesInCarriages = carriagesQuantity * spaciousness;
                    restPassengers -= passengesInCarriages;
                }
                else 
                {
                    if (restPassengers == spaciousness)
                    {
                        carriagesQuantity = 1;
                        restPassengers = 0;
                    }
                    if (restPassengers < spaciousness)
                    {
                        if (spaciousness / restPassengers < 2)
                        {
                            carriagesQuantity = 1;
                            restPassengers = 0;
                        }
                        else
                        {
                            carriagesQuantity = 0;
                        }
                    }
                }                                
            }

            return carriagesQuantity;
        }
      
        public void ShowCarriage() 
        {
            Console.WriteLine("тип: " + _name);
            Console.WriteLine("вместительность: " + Spaciousness.ToString());                     
        }
    }
}
