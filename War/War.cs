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
        private Platoon _platoon1;
        private Platoon _platoon2;

        public Battlefield() 
        {
            _platoon1 = new Platoon();
            _platoon2 = new Platoon();
        }      

        public void SimulateBattle() 
        {           
            bool platoon1IsDeafeated = false, platoon2IsDeafeated = false;
            int step = 0;
            double platoon1Damage, platoon2Damage;

            while (platoon1IsDeafeated != true && platoon2IsDeafeated != true) 
            {
                Console.Clear();
                Console.WriteLine("Ход :" + step.ToString());
                Console.WriteLine("---------------------------------------------");

                platoon1Damage = _platoon1.ParticipateInBattle();
                Console.WriteLine("---------------------------------------------");
                platoon2Damage = _platoon2.ParticipateInBattle();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine();

                Console.WriteLine("[][][][][][][][][][][][][][][][][][][][][][][]");
                _platoon1.TakeDamage(platoon2Damage);
                _platoon2.TakeDamage(platoon1Damage);

                _platoon1.CheckLoss();
                _platoon2.CheckLoss();

                platoon1IsDeafeated = _platoon1.IsDefeated;
                platoon2IsDeafeated = _platoon2.IsDefeated;

                step++;

                Console.WriteLine("Введите любую клавишу для продолжения...");
                Console.ReadKey();
            }

            if (platoon1IsDeafeated == true) 
            {
                Console.WriteLine("Победила страна " + _platoon2.Country);
            }
            if (platoon2IsDeafeated == true)
            {
                Console.WriteLine("Победила страна " + _platoon1.Country);
            }
        }           
    }
  
    class Platoon 
    {
        public string Country { get; private set; }
        private List<Soldier> _platoon;
        public bool IsDefeated { get; private set; }

        public Platoon() 
        {
            _platoon = new List<Soldier>();
            Random randomNumber = new Random();
            int soldiersQuantity = randomNumber.Next(10, 31);
            double health, damage, armor;

            for (int i = 1; i <= soldiersQuantity; i++) 
            {
                health = randomNumber.Next(25, 101);
                damage = randomNumber.Next(100, 201);
                armor = randomNumber.Next(25, 51);
                _platoon.Add(new Soldier(health, damage, armor));
            }
            IsDefeated = false;
            Console.WriteLine("Введите название страны");
            Country = Console.ReadLine();
        }

        public double ParticipateInBattle() 
        {
            int index;
            double outputDamage;

            Show();
            Console.WriteLine("---------------------------------------------");
            index = PickSoldierDamage();
            outputDamage = _platoon[index].Damage;
            Console.WriteLine("Солдат " + index.ToString()  + " наносит " + outputDamage.ToString()+ " урона");

            return outputDamage;
        }

        public void CheckLoss() 
        {
            CheckState();
            RemoveDead();
        }

        public void TakeDamage(double pickedDamage)
        {
            int soldiersQuantity = _platoon.Count;
            int numberPicked;
            double reducedDamage;
            Random randomNumber = new Random();

            numberPicked = randomNumber.Next(0, soldiersQuantity);
            reducedDamage =  _platoon[numberPicked].TakeDamage(pickedDamage);
            int index = numberPicked;
            Console.Write("Солдат " + index.ToString() + " из страны " + Country + " получает " + reducedDamage.ToString() + " урона, ");

            double blockedDamage = pickedDamage - reducedDamage;
            Console.WriteLine("заблокировано " + blockedDamage.ToString()+ " урона");
        }

        private void CheckState() 
        {
            bool isAlive = false;                      

            foreach (Soldier soldier in _platoon) 
            {
                soldier.CheckState();
                if (soldier.IsAlive == true) 
                {
                    isAlive = true;                  
                }               
            }

            if (isAlive == false) 
            {
                IsDefeated = true;
            }                         
        }

        private void RemoveDead() 
        {          
            int index = 0, indexForRemove = 0;
            bool isDeadExist = false;

            foreach (Soldier soldier in _platoon)
            {
                soldier.CheckState();
                if (soldier.IsAlive == false)
                {
                    indexForRemove = index;
                    isDeadExist = true;
                }               
                index++;
            }
            
            if (isDeadExist == true)
            {
                _platoon.RemoveAt(indexForRemove);
            }                      
        }

        private int PickSoldierDamage() 
        {                   
            int numberPicked;                      

            Random randomNumber = new Random();
            numberPicked = randomNumber.Next(0, _platoon.Count);           
            int index = numberPicked;          

            return index;
        }
      

        private void Show()
        {
            int soldierIndex = 0;

            Console.WriteLine(Country + ":");
            foreach (Soldier soldier in _platoon)
            {
                Console.Write("["+soldierIndex.ToString()+"]");
                Console.Write(" HP:" + soldier.Health.ToString());
                Console.Write(" D:" + soldier.Damage.ToString());
                Console.Write(" A:" + soldier.Armor.ToString());
                Console.WriteLine(" S:" + soldier.IsAlive.ToString());
                soldierIndex++;
            }
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

        public double TakeDamage(double damage) 
        {
            double damageReduced = damage/ Armor * 10;
            damageReduced = Math.Round(damageReduced);
            Health -= damageReduced;

            return damageReduced;
        }

        public void CheckState()
        {
            if (Health <= 0) 
            {
                Health = 0;
                IsAlive = false;
            }
        }
    }   
}
