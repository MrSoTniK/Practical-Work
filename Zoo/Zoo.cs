using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class Program
    {
        static void Main(string[] args)
        {          
            Zoo zoo = new Zoo();
            bool isExit = false;

            while (isExit == false) 
            {
                isExit = zoo.ChooseAviary();
            }

            Environment.Exit(0);
        }
    }

    class Zoo 
    {
        private Dictionary<int, Aviary> _aviaries;
        private Random _randomNumber;

        public Zoo() 
        {
            _randomNumber = new Random();
            _aviaries = new Dictionary<int, Aviary>();
            _aviaries.Add(1, new Aviary("вольер 1", "лев", "роар", _randomNumber));
            _aviaries.Add(2, new Aviary("вольер 2", "слон", "труууу", _randomNumber));
            _aviaries.Add(3, new Aviary("вольер 3", "жираф", "звуки ниже 20 Гц", _randomNumber));
            _aviaries.Add(4, new Aviary("вольер 4", "леопард", "роар", _randomNumber));
            _aviaries.Add(5, new Aviary("вольер 5", "шимпанзе", "аур-аур", _randomNumber));           
        }

        public bool ChooseAviary() 
        {
            Console.Clear();
            Console.WriteLine("Зоопарк:");
            Console.WriteLine("Выберите вольер:");
            Console.WriteLine("вольер 1 - 1");
            Console.WriteLine("вольер 2 - 2");
            Console.WriteLine("вольер 3 - 3");
            Console.WriteLine("вольер 4 - 4");
            Console.WriteLine("вольер 5 - 5");
            Console.WriteLine("выход - exit");
            bool isExit = false;

            string userInput = Console.ReadLine();
            int value;
            bool isValue = Int32.TryParse(userInput, out value);

            Console.Clear();
            if (userInput != "exit") 
            {
                if (_aviaries.ContainsKey(value) == true) 
                {
                    _aviaries[value].Show();
                }
            }
            else 
            {
                isExit = true;
            }

            if (isExit == false)
            {
                Console.WriteLine("Нажмите любую кнопку, чтобы вернуться...");
                Console.ReadKey();
            }                  

            return isExit;
        }
    }

    class Aviary 
    {
        private string _name;
        private string _animal;
        private string _sound;
        private int _maleQuantity;
        private int _femaleQuantity;

        public Aviary(string name, string animal, string sound, Random randomNumber) 
        {           
            _name = name;
            _animal = animal;
            _sound = sound;
            DefineGender(randomNumber);
        }

        public void Show() 
        {
            Console.WriteLine(_name + ":");
            Console.WriteLine("животное: "+_animal);
            Console.WriteLine("звук: " + _sound);
            Console.WriteLine("мужских особей: " + _maleQuantity.ToString());
            Console.WriteLine("женских особей: " + _femaleQuantity.ToString());
        }

        private void DefineGender(Random randomNumber) 
        {          
            _maleQuantity = randomNumber.Next(1, 6);
            _femaleQuantity = randomNumber.Next(1, 6);
        }
    }   
}
