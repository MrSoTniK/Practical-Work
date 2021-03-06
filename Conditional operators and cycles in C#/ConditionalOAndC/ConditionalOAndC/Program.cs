﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOAndC
{
    class Program
    {
        static void Main(string[] args)
        {
            int chosenNumber;
            sign:
            Console.WriteLine("ЯЮниор.Условные операторы и циклы:");
            Console.WriteLine("1. Конвертер валют ");
            Console.WriteLine("2. Последовательность ");
            Console.WriteLine("3. Программа под паролем ");
            Console.WriteLine("4. Консольное меню ");
            Console.WriteLine("5. Вывод имени ");
            Console.WriteLine("6. Битва с боссом ");
            Console.WriteLine("Выберите задание из списка выше (нужно ввести цифру задания)");
            chosenNumber = Convert.ToInt32(Console.ReadLine());
            switch (chosenNumber) 
            { 
                case 1:
                    Console.WriteLine("Написать конвертер валют (3 валюты).\nУ пользователя есть баланс в каждой из представленных валют. " 
                    + "Он может попросить сконвертировать часть баланса в одной валюты в другую. Тогда у него с баланса одной валюты снимет "
                    + "X и зачислится на баланс другой Y. Курс конвертации должен быть просто прописан в программе.");
                    Converter conv = new Converter();
                    conv.Solution();
                    goto sign;
                case 2:
                    Console.WriteLine("Нужно написать программу (использую циклы, обязательно пояснить выбор вашего цикла), "+
                    "чтобы она выводила следующую последовательность 7 14 21 28 35 42 49 56 63 70 77 84 91 98");
                    Sequence seq = new Sequence();
                    seq.Solution();
                    goto sign;
                case 3:
                    Console.WriteLine("Создайте переменную типа string в которой хранится пароль для доступа к тайному сообщению."+
                    " Пользователь вводит пароль, далее проверьте пароль на правильность, и если пароль неверный, то попросите его "+
                    "ввести пароль ещё раз. Если пароль подошёл, выведите секретное сообщение.\nЕсли пользователь неверно ввел пароль 3 раза, программа завершается.");
                    Password pass = new Password();
                    pass.Solution();
                    goto sign;
                case 4:
                    Console.WriteLine("При помощи всего, что вы изучили, создать приложение, которое может обрабатывать команды."+
                    " Т.е. вы создаете меню, ожидаете ввода нужной команды, после чего выполняете действие, которое присвоено этой команде.");
                    ConsolMenu menu = new ConsolMenu();
                    menu.Solution();
                    goto sign;
                case 5:
                    Console.WriteLine("Вывести имя в прямоугольник из символа, которые введет сам пользователь.\n"+
                    "Вы запрашиваете имя, после запрашиваете символ, а после отрисовываете в консоль его имя в прямоугольнике из его символов.");
                    NameBringOut name = new NameBringOut();
                    name.Solution();
                    goto sign;
                case 6:
                    Console.WriteLine("Легенда: Вы – теневой маг(можете быть вообще хоть кем) и у вас в арсенале есть несколько заклинаний,"+
                    " которые вы можете использовать против Босса. Вы должны уничтожить босса и только после этого будет вам покой.\n"+
                    "Формально: перед вами босс, у которого есть определенное кол-во жизней и определенный ответный урон. у вас есть 4 заклинания"+
                    " для нанесения урона боссу. Программа завершается только после смерти босса или смерти пользователя.");
                    BattleWithBoss boss = new BattleWithBoss();
                    boss.Solution();
                    goto sign;
            }
        }
    }
}
