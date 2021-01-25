using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DossierDB
{
    class Program
    {
        static void AddDossier(Dictionary<string,string> dictionary) 
        {            
            string nameData, position;

            Console.WriteLine("Введите ФИО");
            nameData = Console.ReadLine();
            Console.WriteLine("Введите должность");
            position = Console.ReadLine();
            dictionary.Add(nameData, position);          
        }

        static void ShowDossier(Dictionary<string, string> dictionary) 
        {
            foreach (KeyValuePair<string, string> keyValue in dictionary)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
        }

        static void DeleteDossier(string inputValue, Dictionary<string, string> dictionary) 
        {
            Console.WriteLine("Введите ФИО записи, которую хотите удалить.");
            inputValue = Console.ReadLine();
            bool isExist = dictionary.Remove(inputValue);
            if (isExist == false)
            {
                Console.WriteLine("Нет записи с таким ФИО");
            }          
        }

        static void SearchDossier(string inputValue, Dictionary<string, string> dictionary) 
        {
            Console.WriteLine("Введите ФИО записи, которую хотите найти.");
            inputValue = Console.ReadLine();
            if (dictionary.ContainsKey(inputValue) == true)
            {
                Console.WriteLine(inputValue + " - " + dictionary[inputValue]);                                                  
            }
            else
            {
                Console.WriteLine("Нет записи с таким ФИО");
            }
        }

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
                        AddDossier(dossiers);
                        break;
                    case "2":
                        ShowDossier(dossiers);
                        break;
                    case "3":
                        DeleteDossier(userInput, dossiers);
                        break;
                    case "4":
                        SearchDossier(userInput, dossiers);
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
