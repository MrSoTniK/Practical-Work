using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOAndC
{
    class ConsolMenu
    {
        public string exit;
        public void Solution()
        {
            string userCommand;
            string FontColor;
            string WindowColor;
            bool contin = true;

            while (contin == true)
            {
                Console.WriteLine("Список команд:");
                Console.WriteLine("SetFontColor - команда смены цвета текста: blue - синий; red - красный; yellow - желтый; white - белый.");
                Console.WriteLine("SetWindowColor - команда смены цвета окна консоли:  blue - синий; red - красный; yellow - желтый; white - белый.");
                Console.WriteLine("WindowHeight - команда изменение высоты окна.");
                Console.WriteLine("WindowWidth - команда изменение ширины окна.");
                userCommand = Console.ReadLine();
                switch (userCommand)
                {
                    case "SetFontColor":
                        FontColor = Console.ReadLine();
                        switch (FontColor)
                        {
                            case "blue":
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case "red":
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case "yellow":
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case "white":
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }

                        break;
                    case "SetWindowColor":
                        WindowColor = Console.ReadLine();
                        switch (WindowColor)
                        {
                            case "blue":
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Clear();
                                break;
                            case "red":
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Clear();
                                break;
                            case "yellow":
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Clear();
                                break;
                            case "white":
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Clear();
                                break;
                        }
                        break;
                    case "WindowHeight":
                        Console.WindowHeight = Convert.ToInt32(Console.ReadLine());
                        break;
                    case "WindowWidth":
                        Console.WindowWidth = Convert.ToInt32(Console.ReadLine());
                        break;
                }

                Console.WriteLine("Продолжить ввод команд? 1 - нет (выход), любое другое значение - да");
                exit = Console.ReadLine();
                if (exit == "1")
                {
                    contin = false;
                }
            }


        }
    }
}
