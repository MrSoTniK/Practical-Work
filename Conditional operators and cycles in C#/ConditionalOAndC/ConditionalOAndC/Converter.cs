using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOAndC
{
    class Converter
    {
        public string exit;
        public void Solution() 
        {
            float rubles;
            float dollars;
            float euro;
            int courseVar;
            float currentAmount;
            float convertedDToR = 0, convertedDToE = 0;
            float convertedRToD = 0, convertedRToE = 0;
            float convertedEToR = 0, convertedEToD = 0;           
            bool contin = true;

            Console.WriteLine("Добро пожаловать в обменник валют.\n"+"Каков ваш баланс рублей?");
            rubles = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Каков ваш баланс долларов?");
            dollars = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Каков ваш баланс евро?");
            euro = Convert.ToSingle(Console.ReadLine());
            while (contin == true)
            {
                Console.WriteLine("Какую валюту вы хотите обменять и на что?\n 1 - рубли на доллары, 2 - рубли на евро, 3 - доллары на рубли, 4 - доллары на евро, " +
                "5 - евро на доллары, 6 - евро на рубли");
                courseVar = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("В каком количестве хотите обменять?");
                currentAmount = Convert.ToSingle(Console.ReadLine());
                switch (courseVar)
                {
                    case 1:
                        if (currentAmount <= rubles)
                        {
                           convertedRToD = currentAmount / 63.68f;
                           dollars += convertedRToD;
                           rubles -= currentAmount;
                        }
                        else 
                        {
                            Console.WriteLine("Ошибка. У вас нет столько рублей");
                        }
                        break;
                    case 2:
                        if (currentAmount <= rubles)
                        {
                            convertedRToE = currentAmount / 70.44f;
                            euro += convertedRToE;
                            rubles -= currentAmount;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка. У вас нет столько рублей");
                        }
                        break;
                    case 3:
                        if (currentAmount <= dollars)
                        {
                            convertedDToR = currentAmount * 63.68f;
                            rubles += convertedDToR;
                            dollars -= currentAmount;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка. У вас нет столько долларов");
                        }
                        break;
                    case 4:
                        if (currentAmount <= dollars)
                        {
                            convertedDToE = currentAmount / 1.11f;
                            euro += convertedDToE;
                            dollars -= currentAmount;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка. У вас нет столько долларов");
                        }
                        break;
                    case 5:
                        if (currentAmount <= euro)
                        {
                            convertedEToD = currentAmount * 1.11f;
                            dollars += convertedEToD;
                            euro -= currentAmount;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка. У вас нет столько евро");
                        }
                        break;
                    case 6:
                        if (currentAmount <= euro)
                        {
                            convertedEToR = currentAmount * 70.44f;
                            rubles += convertedEToR;
                            euro -= currentAmount;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка. У вас нет столько евро");
                        }
                        break;
                    default:
                        Console.WriteLine("Ошибка.Вы ввели недопустимое значение");
                        break;
                }                
                Console.WriteLine("Ваш баланс на данный момент составляет:" + rubles + " рублей, " + dollars + " долларов," + euro + " евро");
                Console.WriteLine("Продолжить обмен валюты? 1 - нет (выход), любое другое значение - да");
                exit = Console.ReadLine();
                if (exit == "1") 
                {
                    contin = false;
                }
            }           
        }
    }
}
