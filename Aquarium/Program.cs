using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            Aquarium aqua = new Aquarium("map");
            Shoal shoal = new Shoal();
            int iteration = 0;
            bool isExit = false;

            Console.WindowHeight = 60;
            Console.WindowWidth = 120;
           
            while (isPlaying == true)
            {
                while (iteration != 0) 
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.SetCursorPosition(0, 0);
                    aqua.Draw();
                    aqua.Map = shoal.Move(aqua.Map);
                    Console.SetCursorPosition(60,0);
                    Console.WriteLine("Список рыб:");
                    shoal.ShowList();
                    shoal.Iteration();
                    aqua.Map = shoal.Death(aqua.Map);
                    iteration--;
                    
                }
                while (isExit == false)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 25);                  
                    Console.WriteLine("Меню:\n1 - Добавить рыбу\n2 - Убрать рыбу\n3 - Положить рыбу в аквариум\n4 - Перейти к симуляции");
                    string userInput = Console.ReadLine();
                    switch (userInput) 
                    { 
                        case "1":
                            aqua.Map = shoal.Add(aqua.Map);
                            break;
                        case "2":
                            aqua.Map = shoal.Delete(aqua.Map);
                            break;
                        case "3":
                            aqua.Map = shoal.TakeFromStorage(aqua.Map);
                            break;
                        case "4":
                            isExit = true;
                            break;
                        default:
                            Console.WriteLine("Неверный ввод");
                            break;
                    }                   
                }
                Console.Clear();
                Console.SetCursorPosition(0, 25);  
                Console.WriteLine("Каково количество итераций?");
                iteration = Convert.ToInt32(Console.ReadLine());
                isExit = false;
                
          
            }
        }
    }

    class Aquarium
    {
        private string[] file; 
        public char[,] Map; 

        public Aquarium(string mapName)
        {           
            file = File.ReadAllLines("maps/" + mapName + ".txt");
            Map = new char[file.Length, file[0].Length];
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Map[i, j] = file[i][j];
                }
            }
        }

        public void Draw() 
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Console.Write(Map[i, j]);
                }
                Console.WriteLine();
            }          
        }
    }

    class Fish 
    {
        public int HP{get; private set;}
        public char Symbol { get; private set; }        
        public Random Random = new Random();
        public char InStorage{ get; private set; }  

        public Fish(char sign, int lifes = 100, char storage = '-') 
        {
            Symbol = sign;
            HP = lifes;
            InStorage = storage;
        }
       
        public void Iteration() 
        {
            HP--;
        }

        public char[,] Move(char[,] map) 
        {
            Random rand = new Random();
            int variant;
            int x = 0;
            int y = 0;
            int dx = 0;
            int dy = 0;
           
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == Symbol) 
                    {                        
                        x = i;                       
                        y = j;
                        map[x, y] = ' ';         
                    }
                }
            }

            variant = rand.Next(1,5);
            switch (variant)
            {
                case 1:
                    dx = 0;
                    dy = 1;
                    break;
                case 2:
                    dx = 1;
                    dy = 0;
                    break;
                case 3:
                    dx = -1;
                    dy = 0;
                    break;
                case 4:
                    dx = 0;
                    dy = -1;
                    break;
            }
            if (map[x + dx, y + dy] != '-' && map[x + dx, y + dy] != '#' && map[x + dx, y + dy] != Symbol)
            {
                map[x + dx, y + dy] = Symbol;
            }
            else 
            {
                switch (dx) 
                { 
                    case 0:
                        break;
                    case 1:
                        dx = -1;
                        break;
                    case -1:
                        dx = 1;
                        break;
                }

                switch (dy)
                {
                    case 0:
                        break;
                    case 1:
                        dy = -1;
                        break;
                    case -1:
                        dy = 1;
                        break;
                }
                map[x + dx, y + dy] = Symbol;
            }
           
                return map;
        }

        public char[,] Add(char[,] map) 
        {
            int xPos = Random.Next(3, 17);
            int yPos = Random.Next(2, 51);

            map[xPos, yPos] = Symbol;

            return map;
        }

        public char[,] Delete(char[,] map, bool isDead)
        {
            bool isFinish = false;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                if (isFinish != true)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (map[i, j] == Symbol)
                        {
                            map[i, j] = ' ';
                            isFinish = true;                      
                        }
                    }   
                }
                else 
                {
                    break;
                }            
            }
                     
            if (isDead == false)
            {
                InStorage = '+';
            }
            return map;
        }

        public void ReleaseFromStorage() 
        {
            InStorage = '-';
        }

    }

    class Shoal
    {
        private Fish[] fishes = new Fish[0];
      

        public void ShowList()
        {          
            for (int i = 0; i < fishes.Length; i++) 
            {
                Console.SetCursorPosition(60, i+1);
                Console.WriteLine(i + ") Рыба: '" + fishes[i].Symbol + "'  Жизни: " + fishes[i].HP + "  Состояние: " + fishes[i].InStorage);
            }           
        }

        public char[,] Add(char[,] map)
        {
            Console.WriteLine("Добавить рыб? Нажмите Y, если да. Нет - люб. другое значение");
            string userChoice = Console.ReadLine();

            if (userChoice == "Y")
            {
                Console.WriteLine("Сколько рыб добавить?");
                int amount = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < amount; i++)
                {
                    Fish[] temp = new Fish[fishes.Length + 1];
                    for (int j = 0; j < fishes.Length; j++)
                    {
                        temp[j] = fishes[j];
                    }

                    string answer;

                    Console.WriteLine("HP по умолчанию? Нажмите Y, если да. Нет - люб. другое значение");
                    answer = Console.ReadLine();
                    if (answer == "Y")
                    {
                        Console.WriteLine("Введите тип рыбы (символ)");
                        temp[fishes.Length] = new Fish(Convert.ToChar(Console.ReadLine()));
                    }
                    else
                    {
                        Console.WriteLine("Введите тип рыбы (символ), затем - количество жизней");
                        temp[fishes.Length] = new Fish(Convert.ToChar(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                    }
                    fishes = temp;
                    map = fishes[fishes.Length-1].Add(map);
                }
            }
            
            return map;

        }

        public char[,] Delete(char[,] map)
        {
            Console.WriteLine("Достать рыбу из аквариума? Нажмите Y, если да. Нет - люб. другое значение");
            string userChoice = Console.ReadLine();

            if (userChoice == "Y")
            {
                Console.WriteLine("Убить рыбу или оставить на хранение? Нажмите Y, если убить рыбу. Нет - оставить на хранение (люб. др. значение)");
                string answer = Console.ReadLine();
                if(answer == "Y")
                {
                    Fish[] temp = new Fish[fishes.Length - 1];               
                    bool isHappened = false;
                    int value;

                    Console.WriteLine("Номер рыбы в списке: ");
                    value = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < fishes.Length; i++)
                    {
                        if (i != value && isHappened == false) 
                        {
                            temp[i] = fishes[i];
                        }
                        if (i == value) 
                        {
                            map = fishes[i].Delete(map, true);
                            isHappened = true;
                        }
                        if (isHappened == true && i != temp.Length) 
                        {
                            temp[i] = fishes[(i + 1)];
                        }
                    }
                    fishes = temp;
                }
                else
                {
                    int value;

                    Console.WriteLine("Номер рыбы в списке: ");
                    value = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < fishes.Length; i++)
                    {
                        if (i == value)
                        {
                            map = fishes[i].Delete(map, false);
                        }
                    }
                }
            }
            

            return map;
        }

        public char[,] TakeFromStorage(char[,] map)
        {
            int userChoice;

            Console.WriteLine("Номер рыбы из списка, которую необходимо положить в аквариум:");
            userChoice = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < fishes.Length; i++)
            {
                if (userChoice == i)
                {
                    if (fishes[i].InStorage == '+') 
                    {
                        map = fishes[i].Add(map);
                        fishes[i].ReleaseFromStorage();
                    }
                    else 
                    {
                        Console.WriteLine("Данная рыба уже в аквариуме");
                    }
                }
            }
            return map;
        }

        public char[,] Death(char[,] map)
        {          
            for (int i = 0; i < fishes.Length; i++)
            {
                if (fishes[i].HP == 0)
                {
                    Fish[] temp = new Fish[fishes.Length - 1];     
                    int value = i;
                    bool isHappened = false;

                    for (int j = 0; j < fishes.Length; j++)
                    {
                        if (j != value && isHappened == false)
                        {
                            temp[j] = fishes[j];
                        }
                        if (j == value)
                        {
                            map = fishes[i].Delete(map, true);
                            isHappened = true;
                        }
                        if (isHappened == true && j != temp.Length )
                        {
                            temp[j] = fishes[(j + 1)];
                        }
                    }
                    fishes = temp;
                    i = 0;
                }
            }
            return map;
        }

        public char[,] Move(char[,] map)
        {
            for (int i = 0; i < fishes.Length; i++) 
            {
                map = fishes[i].Move(map);           
            }
                return map;
        }

        public void Iteration() 
        {
            for (int i = 0; i < fishes.Length; i++)
            {
                fishes[i].Iteration();
            }
        }

    }

}
