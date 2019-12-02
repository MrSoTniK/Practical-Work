using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int chosenNumber;
            string exit;
        sign:
            Console.WriteLine("ЯЮниор.Массивы:");
            Console.WriteLine("1. Работа с конкретными строками/столбцами ");
            Console.WriteLine("2. Наибольший элемент ");
            Console.WriteLine("3. Динамический массив ");
            Console.WriteLine("4. Локальные максимумы "); 
            chosenNumber = Convert.ToInt32(Console.ReadLine());
            switch (chosenNumber)
            {
                case 1:
                    Console.WriteLine("Дан двумерный массив.Вычислить сумму второй строки и произведение первого столбца. Вывести исходную матрицу и результаты вычислений.");
                    WorkWithColumnsAndRows work = new WorkWithColumnsAndRows();
                    work.Solution();
                    break;
                case 2:
                    Console.WriteLine("Найти наибольший элемент матрицы A(10,10) и записать ноль в ту ячейку, где он находится. Вывести наибольший элемент, исходную и полученную матрицу.");
                    MaxElement max = new MaxElement();
                    max.Solution();
                    break;
                case 3:
                    Console.WriteLine("Пользователь вводит числа, и программа их запоминает. Как только пользователь введёт команду sum, программа выведет сумму"
                    +" всех веденных чисел. Если пользователь введет команду sort, программа отсортирует массив.Выход из программы должен происходить только в том"
                    +" случае, если пользователь введет команду exit.Программа должна работать на основе расширения массива."
                    +" Внимание, нельзя использовать List<T> и Array.Resize");
                    DynamicArray dynam = new DynamicArray();
                    dynam.Solution();
                    break;
                case 4:
                    Console.WriteLine("Дан массив целых чисел из 30 элементов.Найдите все локальные максимумы."
                    + "(Элемент является локальным максимумом, если он не имеет соседей, больших, чем он сам)" +
                    " Крайние элементы являются локальными максимумами если не имеют соседа большего, чем они сами.");
                    LocalMax loc = new LocalMax();
                    loc.Solution();
                    break;
            }
            Console.WriteLine("Выйти из программы или перейти к меню?1 - перейти к меню; выйти - любое другое значение.");
            exit = Console.ReadLine();
            if (exit == "1")
            {
                goto sign;
            }
            else 
            {
                Environment.Exit(0);
            }
        }
    }
}
