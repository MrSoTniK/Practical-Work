using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            Battlefield battlefield = new Battlefield();
            
            battlefield.SimulateBattle();
            Console.ReadLine();
        }
    }

    class Battlefield
    {
        private Platoon _troop1;
        private Platoon _troop2;

        public Battlefield() 
        {
            _troop1 = new Platoon();
            _troop2 = new Platoon();
        }      

        public void SimulateBattle() 
        {                      
            int step = 0;
            double DamageOfPlatoon1, DamageOfPlatoon2;

            while (_troop1.Soldiers.Count != 0 && _troop2.Soldiers.Count != 0) 
            {
                Console.Clear();
                Console.WriteLine("Ход :" + step.ToString());
                Console.WriteLine("---------------------------------------------");

                DamageOfPlatoon1 = _troop1.GetDamage();
                Console.WriteLine("---------------------------------------------");
                DamageOfPlatoon2 = _troop2.GetDamage();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine();

                Console.WriteLine("[][][][][][][][][][][][][][][][][][][][][][][]");
                _troop1.TakeDamage(DamageOfPlatoon2);
                _troop2.TakeDamage(DamageOfPlatoon1);

                _troop1.RemoveDead();
                _troop2.RemoveDead();
             
                step++;

                Console.WriteLine("Введите любую клавишу для продолжения...");
                Console.ReadKey();
            }

            if (_troop1.Soldiers.Count == 0 && _troop2.Soldiers.Count == 0) 
            {
                Console.WriteLine("Ничья");
            }
            else 
            {
                if (_troop1.Soldiers.Count == 0)
                {
                    Console.WriteLine("Победила страна " + _troop2.Country);
                }
                if (_troop2.Soldiers.Count == 0)
                {
                    Console.WriteLine("Победила страна " + _troop1.Country);
                }
            }          
        }           
    }
  
    class Platoon 
    {  
        private Random _randomNumber;
        public string Country { get; private set; }
        public List<Soldier> Soldiers { get; private set; }  

        public Platoon() 
        {
            Soldiers = new List<Soldier>();
            _randomNumber = new Random();
            int soldiersQuantity = _randomNumber.Next(10, 31);
            double health, damage, armor;

            for (int i = 1; i <= soldiersQuantity; i++) 
            {
                health = _randomNumber.Next(25, 101);
                damage = _randomNumber.Next(100, 201);
                armor = _randomNumber.Next(25, 51);
                Soldiers.Add(new Soldier(health, damage, armor));
            }
           
            Console.WriteLine("Введите название страны");
            Country = Console.ReadLine();
        }              

        public void TakeDamage(double pickedDamage)
        {
            int soldiersQuantity = Soldiers.Count;
            int numberPicked;
            double reducedDamage;

            numberPicked = _randomNumber.Next(0, soldiersQuantity);
            reducedDamage =  Soldiers[numberPicked].TakeDamage(pickedDamage);
            int index = numberPicked;
            Console.Write("Солдат " + index.ToString() + " из страны " + Country + " получает " + reducedDamage.ToString() + " урона, ");

            double blockedDamage = pickedDamage - reducedDamage;
            Console.WriteLine("заблокировано " + blockedDamage.ToString()+ " урона");
        }
      
        public void RemoveDead() 
        {                    
            for (int i = 0; i < Soldiers.Count; i++) 
            {
                Soldiers[i].CheckState();
                if (Soldiers[i].IsAlive == false)
                {
                    Soldiers.RemoveAt(i);
                    break;
                }
            }                                    
        }

        public double GetDamage()
        {
            int index;
            double outputDamage;

            Show();
            Console.WriteLine("---------------------------------------------");
            index = PickSoldierDamage();
            outputDamage = Soldiers[index].Damage;
            Console.WriteLine("Солдат " + index.ToString() + " наносит " + outputDamage.ToString() + " урона");

            return outputDamage;
        }

        private void Show()
        {
            int soldierIndex = 0;

            Console.WriteLine(Country + ":");
            foreach (Soldier soldier in Soldiers)
            {
                Console.Write("[" + soldierIndex.ToString() + "]");
                Console.Write(" HP:" + soldier.Health.ToString());
                Console.Write(" D:" + soldier.Damage.ToString());
                Console.Write(" A:" + soldier.Armor.ToString());
                Console.WriteLine(" S:" + soldier.IsAlive.ToString());
                soldierIndex++;
            }
        }

        private int PickSoldierDamage() 
        {                   
            int numberPicked;                      

            Random randomNumber = new Random();
            numberPicked = randomNumber.Next(0, Soldiers.Count);           
            int index = numberPicked;          

            return index;
        }         
    }

    class Soldier 
    {
        public double Health { get; private set; }
        public double Damage { get; private set; }
        public double Armor { get; private set; }
        public bool IsAlive { get; private set; }

        public Soldier(double health, double damage, double armor, bool isAlive = true) 
        {
            Health = health;
            Damage = damage;
            Armor = armor;
            IsAlive = isAlive;
        }        

        public void CheckState()
        {
            if (Health <= 0) 
            {
                Health = 0;
                IsAlive = false;
            }
        }

        public double TakeDamage(double damage)
        {
            double damageReduced = damage / Armor * 10;
            damageReduced = Math.Round(damageReduced);
            Health -= damageReduced;

            return damageReduced;
        }
    }   
}
