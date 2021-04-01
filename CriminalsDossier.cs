using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DossierList
{
    class Program
    {
        static void Main(string[] args)
        {                               
            string userInput;
            string parameterName, comparisonOperator;
            bool isAllParametersEntered = false;           
            DataBase dataBase = new DataBase();

            while(isAllParametersEntered == false)
            {
                Console.Clear();
                Console.WriteLine("База данных досье преступников");
                Console.WriteLine("Введите параметры преступника");
                Console.WriteLine("Доступные параметры: ФИО, рост, вес, национальность");
                Console.WriteLine("Добавить следующий параметр для фильтрации? 1- да, люб. др. значение - нет");
                userInput = Console.ReadLine();
                if (userInput == "1") 
                {
                    Console.WriteLine("Какой параметр добавить?");
                    parameterName = Console.ReadLine();
                    Console.WriteLine("По какому оператору сравнения вести поиск? ('=', '>', '<', '>=', '<=')");
                    comparisonOperator = Console.ReadLine();
                    dataBase.EnterData(parameterName, comparisonOperator);
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
                else 
                {
                    isAllParametersEntered = true;
                }
            }

            Console.Clear();
            Console.WriteLine("Результат:");
            dataBase.Show();
            Console.ReadKey();
        }     
    }

    class DataBase 
    {
        private List<Criminal> _criminals = new List<Criminal>();
        private List<Criminal> _filteredCriminals = new List<Criminal>();

        public DataBase() 
        {
            _criminals.Add(new Criminal("Добров Виктор Геннадьевич", 175, 82, "русский", true));
            _criminals.Add(new Criminal("Асадов Гульназ Рахимович", 183, 75, "татарин", false));
            _criminals.Add(new Criminal("Нагаев Мухамат Каримович", 181, 73, "узбек", false));
            _criminals.Add(new Criminal("Косов Степан Юрьевич", 178, 95, "русский", false));
            _criminals.Add(new Criminal("Листов Валентин Иавнович", 172, 62, "русский", false));
            _filteredCriminals = _criminals;
        }

        public void Show() 
        {
            foreach (Criminal criminal in _filteredCriminals) 
            {
                if (criminal.ArrestCondition != "под стражей") 
                {
                    criminal.Show();
                }              
            }        
        }

        public void EnterData(string name, string comparisonOperator)
        {
            int number;
            string userInput;
            Console.WriteLine(name + ":");
            userInput = Console.ReadLine();
            bool isNumber = Int32.TryParse(userInput, out number);
            switch (name) 
            { 
                case "ФИО":
                    FindFullName(userInput, comparisonOperator);
                    break;
                case "рост":
                    if (isNumber == true && number > 0) 
                    {
                        FindHeight(number, comparisonOperator);
                    }
                    else 
                    {
                        Console.WriteLine("Введено не число!");
                    }
                    break;
                case "вес":
                    if (isNumber == true && number > 0)
                    {
                        FindWeight(number, comparisonOperator);
                    }
                    else
                    {
                        Console.WriteLine("Введено не число!");
                    }                   
                    break;
                case "национальность":
                    FindNationality(userInput, comparisonOperator);
                    break;
                default:
                    Console.WriteLine("Такого параметра не существует");
                    break;
            }
        }

        private void FindFullName(string userInput, string comparisonOperator) 
        {
            if (comparisonOperator == "=") 
            {
                var filteredCriminals = from Criminal criminal in _filteredCriminals where criminal.FullName.Contains(userInput) select criminal;
                _filteredCriminals = filteredCriminals.ToList();
            }
            else 
            {
                Console.WriteLine("Такого оператора сравненения нет для данного параметра! (только =)");
            } 
        }

        private void FindHeight(int number, string comparisonOperator)
        {
            IEnumerable<Criminal> filteredCriminals = null;
            if (comparisonOperator == "=") 
            {
                filteredCriminals = from Criminal criminal in _filteredCriminals where criminal.Height == number select criminal;
                _filteredCriminals = filteredCriminals.ToList();
            }
            else if (comparisonOperator == ">")
            {
                filteredCriminals = from Criminal criminal in _filteredCriminals where criminal.Height > number select criminal;
                _filteredCriminals = filteredCriminals.ToList();
            }
            else if (comparisonOperator == ">=")
            {
                filteredCriminals = from Criminal criminal in _filteredCriminals where criminal.Height >= number select criminal;
                _filteredCriminals = filteredCriminals.ToList();
            }
            else if (comparisonOperator == "<")
            {
                filteredCriminals = from Criminal criminal in _filteredCriminals where criminal.Height < number select criminal;
                _filteredCriminals = filteredCriminals.ToList();
            }
            else if (comparisonOperator == "<=")
            {
                filteredCriminals = from Criminal criminal in _filteredCriminals where criminal.Height <= number select criminal;
                _filteredCriminals = filteredCriminals.ToList();
            }
            else
            {
                Console.WriteLine("Такого оператора сравненения не существует");
            }
           
        }

        private void FindWeight(int number, string comparisonOperator)
        {
            IEnumerable<Criminal> filteredCriminals = null;
            if (comparisonOperator == "=")
            {
                filteredCriminals = from Criminal criminal in _filteredCriminals where criminal.Weight == number select criminal;
                _filteredCriminals = filteredCriminals.ToList();
            }
            else if (comparisonOperator == ">")
            {
                filteredCriminals = from Criminal criminal in _filteredCriminals where criminal.Weight > number select criminal;
                _filteredCriminals = filteredCriminals.ToList();
            }
            else if (comparisonOperator == ">=")
            {
                filteredCriminals = from Criminal criminal in _filteredCriminals where criminal.Weight >= number select criminal;
                _filteredCriminals = filteredCriminals.ToList();
            }
            else if (comparisonOperator == "<")
            {
                filteredCriminals = from Criminal criminal in _filteredCriminals where criminal.Weight < number select criminal;
                _filteredCriminals = filteredCriminals.ToList();
            }
            else if (comparisonOperator == "<=")
            {
                filteredCriminals = from Criminal criminal in _filteredCriminals where criminal.Weight <= number select criminal;
                _filteredCriminals = filteredCriminals.ToList();
            }
            else 
            {
                Console.WriteLine("Такого оператора сравненения не существует");
            }
            
        }

        private void FindNationality(string userInput, string comparisonOperator)
        {
            if (comparisonOperator == "=")
            {
                var filteredCriminals = from Criminal criminal in _filteredCriminals where criminal.Nationality.Contains(userInput) select criminal;
                _filteredCriminals = filteredCriminals.ToList();
            }
            else
            {
                Console.WriteLine("Такого оператора сравненения нет для данного параметра! (только =)");
            } 
        }
    }

    class Criminal 
    {
        public string FullName { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }
        public string ArrestCondition { get; private set; }

        public Criminal(string fullName, int height, int weight, string nation, bool isArrested) 
        {
            FullName = fullName;
            Height = height;
            Weight = weight;
            Nationality = nation;
            if (isArrested == true) 
            {
                ArrestCondition = "под стражей";
            }
            else 
            {
                ArrestCondition = "в розыске";
            }
        }

        public void Show() 
        {
            Console.WriteLine("ФИО: " + FullName);
            Console.WriteLine("рост: " + Height.ToString());
            Console.WriteLine("вес: " + Weight.ToString());
            Console.WriteLine("национальность: " + Nationality);
            Console.WriteLine();
        }
    }
}
