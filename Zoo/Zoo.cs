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
        private Aviary _aviary1;
        private Aviary _aviary2;
        private Aviary _aviary3;
        private Aviary _aviary4;
        private Aviary _aviary5;

        public Zoo() 
        {
            _aviary1 = new Aviary("вольер 1", "лев", "роар");
            _aviary2 = new Aviary("вольер 2", "слон", "труууу");
            _aviary3 = new Aviary("вольер 3", "жираф", "звуки ниже 20 Гц");
            _aviary4 = new Aviary("вольер 4", "леопард", "роар");
            _aviary5 = new Aviary("вольер 5", "шимпанзе", "аур-аур");           
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
            Console.Clear();
            switch (userInput) 
            { 
                case "1":
                    _aviary1.Show();
                    break;
                case "2":
                    _aviary2.Show();
                    break;
                case "3":
                    _aviary3.Show();
                    break;
                case "4":
                    _aviary4.Show();
                    break;
                case "5":
                    _aviary5.Show();
                    break;
                case "exit":
                    isExit = true;                   
                    break;
                default:
                    Console.WriteLine("Ошибка. Такого Вольера не существует.");
                    break;
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

        public Aviary(string name, string animal, string sound) 
        {
            _name = name;
            _animal = animal;
            _sound = sound;
            DefineGender();
        }

        public void Show() 
        {
            Console.WriteLine(_name + ":");
            Console.WriteLine("животное: "+_animal);
            Console.WriteLine("звук: " + _sound);
            Console.WriteLine("мужских особей: " + _maleQuantity.ToString());
            Console.WriteLine("женских особей: " + _femaleQuantity.ToString());
        }

        private void DefineGender() 
        {
            Random randomNumber = new Random();
            _maleQuantity = randomNumber.Next(1, 6);
            _femaleQuantity = randomNumber.Next(1, 6);
        }
    }   
}
