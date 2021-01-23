using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DossierDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,string> dossiers = new Dictionary<string,string>();
            bool isExit = false;
            string userInput;
            

            while (isExit == false) 
            {
                Console.WriteLine("1 - добавить досье");
                Console.WriteLine("2 - вывести все досье");
                Console.WriteLine("3 - удалить досье");
                Console.WriteLine("4 - поиск по фамилии");
                Console.WriteLine("5 - выход");
                userInput = Console.ReadLine();
                switch (userInput) 
                { 
                    case "1":
                        Console.WriteLine("Введите ФИО, а затем должность");
                        dossiers.Add(Console.ReadLine(), Console.ReadLine());
                        break;
                    case "2":
                        foreach (KeyValuePair<string, string> keyValue in dossiers)
                        {
                            Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
                        }
                        break;
                    case "3":
                        Console.WriteLine("Введите ФИО записи, которую хотите удалить.");
                        userInput = Console.ReadLine();
                        if (dossiers.ContainsKey(userInput) == true)
                        {
                            dossiers.Remove(userInput);
                        }
                        else 
                        {
                            Console.WriteLine("Нет записи с таким ФИО");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Введите ФИО записи, которую хотите найти.");
                        userInput = Console.ReadLine();
                        if (dossiers.ContainsKey(userInput) == true)
                        {
                            foreach (KeyValuePair<string, string> keyValue in dossiers)
                            {
                                if (keyValue.Key == userInput) 
                                {
                                    Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
                                    break;
                                }                               
                            }
                        }
                        else 
                        {
                            Console.WriteLine("Нет записи с таким ФИО");
                        }
                        break;
                    case "5":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Нет такой опции.");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();
                Console.Clear();
            }
            Environment.Exit(0);
        }
    }
}
