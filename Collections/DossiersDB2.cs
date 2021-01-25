using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DossierDB
{
    class Program
    {
        static void DossierAdd(Dictionary<string,string> dictionary) 
        {
            Console.WriteLine("Введите ФИО, а затем должность");
            dictionary.Add(Console.ReadLine(), Console.ReadLine());          
        }

        static void DossierShow(Dictionary<string, string> dictionary) 
        {
            foreach (KeyValuePair<string, string> keyValue in dictionary)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
        }

        static void DossierDelete(string inputValue, Dictionary<string, string> dictionary) 
        {
            Console.WriteLine("Введите ФИО записи, которую хотите удалить.");
            inputValue = Console.ReadLine();
            bool isExist = dictionary.Remove(inputValue);
            if (isExist == false)
            {
                Console.WriteLine("Нет записи с таким ФИО");
            }          
        }

        static void DossierShow(string inputValue, Dictionary<string, string> dictionary) 
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
                        DossierAdd(dossiers);
                        break;
                    case "2":
                        DossierShow(dossiers);
                        break;
                    case "3":
                        DossierDelete(userInput, dossiers);
                        break;
                    case "4":
                        DossierShow(userInput, dossiers);
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
