using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOAndC
{
    class Password
    {
        public string exit;
        public void Solution()
        {
            string password = "J45U";
            int attempt;
            string supposedPassword;
            bool contin = true;

            while (contin == true)
            {
                attempt = 3;
                Console.WriteLine("Попробуйте взломать терминал, чтобы получить доступ к сообщению");
                while (attempt != 0)
                {                    
                    Console.WriteLine("Введите пароль:");
                    supposedPassword = Console.ReadLine();
                    if (supposedPassword == password)
                    {
                        Console.WriteLine("Пароль введен верно. Открывается джоступ к сообщению...");
                        Console.WriteLine("Сообщение: Мир принадлежит котикам!");
                        break;
                    }
                    else
                    {
                        attempt--;
                        Console.WriteLine("Пароль введен неверно. У вас осталось попыток: " + attempt);
                    }
                }
                if (attempt == 0)
                {
                    Console.WriteLine("Неудача. Терминал заблокирован. Попробуете в следующий раз.");
                }
                Console.WriteLine("Ввыйти или начать заново? 1 - ввыйти, любое др. значение - заново ");
                exit = Console.ReadLine();
                if (exit == "1")
                {
                    contin = false;
                }
            }

        }
    }
}
