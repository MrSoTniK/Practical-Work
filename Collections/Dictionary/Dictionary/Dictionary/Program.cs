using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("геймдизайн", "процесс создания формы и содержания игрового процесса (геймплея) разрабатываемой игры.");
            dictionary.Add("программист", "специалист, занимающийся программированием, то есть созданием компьютерных программ.");
            dictionary.Add("3д-художник", "создаёт трехмерные объекты и текстуры для компьютерных и мобильных игр.");
            dictionary.Add("лвл-дизайнер","создает игровые уровни, местность локации в формате 3д-моделей.");
            string userInput = "";
            bool isExist = false;

            while (true) 
            {
                isExist = false;
                Console.WriteLine("Введите слово");
                userInput = Console.ReadLine().ToLower();


                foreach (KeyValuePair<string, string> keyValue in dictionary)
                {
                    if (keyValue.Key == userInput)
                    {
                        Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
                        isExist = true;
                    }
                    
                }
                if (isExist == false)
                {
                    Console.WriteLine("такого слова нет в словаре, попробуйте снова");
                }
            }
        }
    }
}
