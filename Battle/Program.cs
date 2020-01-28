using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            Barbarian barbarian1 = new Barbarian(250, 300, 20, 1.2F, "Варвар");
            Barbarian barbarian2 = new Barbarian(250, 300, 20, 1.2F, "Варвар");
            Magician magician1 = new Magician(150, 150, 15, 1.1F, 100, "Маг");
            Magician magician2 = new Magician(150, 150, 15, 1.1F, 100, "Маг");
            Knight knight1 = new Knight(200, 200, 17, 1.3F, "Рыцарь");
            Knight knight2 = new Knight(200, 200, 17, 1.3F, "Рыцарь");
            DamageDealer damageDealer1 = new DamageDealer(100, 150, 35, 1, "Берсерк");
            DamageDealer damageDealer2 = new DamageDealer(100, 150, 35, 1, "Берсерк");
            Tank tank1 = new Tank(200, 200, 13, 1.8F, "Танк");
            Tank tank2 = new Tank(200, 200, 13, 1.8F, "Танк");        

            bool isPlaying = true;
            string userChoice;
            string warrior1Choice  = "";
            string warrior2Choice  = "";
            bool rightChoice1 = false;
            bool rightChoice2 = false;
            bool battleProcess = true;
            int currentVariantOfWarrior1 = 0;
            int currentVariantOfWarrior2 = 0;
            bool Warrior1isDefeated = false;
            bool Warrior2isDefeated = false;            

            while (isPlaying == true)
            {
                battleProcess = true;
                           
                Console.WriteLine("Меню:\n1 - Посмотреть описание бойцов\n2 - Выбрать бойцов\n3 - Начать бой");
                userChoice = Console.ReadLine();

                switch (userChoice) 
                { 
                    case "1":
                        barbarian1.ShowInfo();
                        magician1.ShowInfo();
                        knight1.ShowInfo();
                        damageDealer1.ShowInfo();
                        tank1.ShowInfo();
                        break;
                    case "2":
                        bool isReapitative1 = true;       
    
                        while(isReapitative1 == true)
                        {
                            Console.WriteLine("Выберите бойца 1:\n1 - Варвар\n2 - Маг\n3 - Рыцарь\n4 - Берсерк\n5 - Танк");
                            warrior1Choice = Console.ReadLine();

                            switch (warrior1Choice)
                            {
                                case "1":
                                    currentVariantOfWarrior1 = 1;
                                    rightChoice1 = true;
                                    isReapitative1 = false;
                                    break;
                                case "2":
                                    currentVariantOfWarrior1 = 2;
                                    rightChoice1 = true;
                                    isReapitative1 = false;
                                    break;
                                case "3":
                                    currentVariantOfWarrior1 = 3;
                                    rightChoice1 = true;
                                    isReapitative1 = false;
                                    break;
                                case "4":
                                    currentVariantOfWarrior1 = 4;
                                    rightChoice1 = true;
                                    isReapitative1 = false;
                                    break;
                                case "5":
                                    currentVariantOfWarrior1 = 5;
                                    rightChoice1 = true;
                                    isReapitative1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Неверный ввод");
                                    rightChoice1 = false;
                                    currentVariantOfWarrior1 = 0;
                                    isReapitative1 = true;
                                    break;                
                            }
                        }

                        bool isReapitative2 = true;

                        while (isReapitative2 == true)
                        {

                            Console.WriteLine("Выберите бойца 2:\n1 - Варвар\n2 - Маг\n3 - Рыцарь\n4 - Берсерк\n5 - Танк");
                            warrior2Choice = Console.ReadLine();

                            switch (warrior2Choice)
                            {
                                case "1":
                                    currentVariantOfWarrior2 = 1;
                                    rightChoice2 = true;
                                    isReapitative2 = false;
                                    break;
                                case "2":
                                    currentVariantOfWarrior2 = 2;
                                    rightChoice2 = true;
                                    isReapitative2 = false;
                                    break;
                                case "3":
                                    currentVariantOfWarrior2 = 3;
                                    rightChoice2 = true;
                                    isReapitative2 = false;
                                    break;
                                case "4":
                                    currentVariantOfWarrior2 = 4;
                                    rightChoice2 = true;
                                    isReapitative2 = false;
                                    break;
                                case "5":
                                    currentVariantOfWarrior2 = 5;
                                    rightChoice2 = true;
                                    isReapitative2 = false;
                                    break;
                                default:
                                    Console.WriteLine("Неверный ввод");
                                    rightChoice2 = false;
                                    currentVariantOfWarrior2 = 0;
                                    isReapitative2 = true;
                                    break;

                            }
                        }

                        break;
                    case "3":
                        if (rightChoice1 == true && rightChoice2 == true) 
                        {
                            Console.WriteLine("Да начнется битва!");
                            while (battleProcess == true) 
                            {
                                float warrior1Damage = 0;
                                float warrior2Damage = 0;

                                switch(currentVariantOfWarrior1)
                                {
                                    case 1:
                                        warrior1Damage = barbarian1.GetDamage();                                      
                                        break;
                                    case 2:
                                        warrior1Damage = magician1.GetDamage();
                                        break;
                                    case 3:
                                        warrior1Damage = knight1.GetDamage();
                                        break;
                                    case 4:
                                        warrior1Damage = damageDealer1.GetDamage();
                                        break;
                                    case 5:
                                        warrior1Damage = tank1.GetDamage();
                                        break;
                                }
                                switch(currentVariantOfWarrior2)
                                {
                                    case 1:
                                        warrior2Damage = barbarian2.GetDamage();
                                        break;
                                    case 2:
                                        warrior2Damage = magician2.GetDamage();
                                        break;
                                    case 3:
                                        warrior2Damage = knight2.GetDamage();
                                        break;
                                    case 4:
                                        warrior2Damage = damageDealer2.GetDamage();
                                        break;
                                    case 5:
                                        warrior2Damage = tank2.GetDamage();
                                        break;
                                }
                                

                                switch (currentVariantOfWarrior1)
                                {
                                    case 1:
                                        barbarian1.BattleInfo();
                                        barbarian1.TakeDamage(warrior2Damage);
                                        barbarian1.StaminaReduce();
                                        barbarian1.CriticalDamageChance();
                                        barbarian1.Rage();
                                        Warrior1isDefeated = barbarian1.Defeat();
                                        break;
                                    case 2:
                                        magician1.BattleInfo();
                                        magician1.TakeDamage(warrior2Damage);
                                        magician1.StaminaReduce();
                                        magician1.HealWounds();
                                        Warrior1isDefeated = magician1.Defeat();
                                        break;
                                    case 3:
                                        knight1.BattleInfo();
                                        knight1.TakeDamage(warrior2Damage);
                                        knight1.StaminaReduce();
                                        knight1.Pray();
                                        Warrior1isDefeated = knight1.Defeat();
                                        break;
                                    case 4:
                                        damageDealer1.BattleInfo();
                                        damageDealer1.TakeDamage(warrior2Damage);
                                        damageDealer1.StaminaReduce();
                                        damageDealer1.BloodThirst();
                                        Warrior1isDefeated = damageDealer1.Defeat();
                                        break;
                                    case 5:
                                        tank1.BattleInfo();
                                        tank1.TakeDamage(warrior1Damage);
                                        tank1.StaminaReduce();
                                        tank1.ProtectionCall();
                                        Warrior1isDefeated = tank1.Defeat();
                                        break;
                                }
                                switch (currentVariantOfWarrior2)
                                {
                                    case 1:
                                        barbarian2.BattleInfo();
                                        barbarian2.TakeDamage(warrior1Damage);
                                        barbarian2.StaminaReduce();
                                        barbarian2.CriticalDamageChance();
                                        barbarian2.Rage();
                                        Warrior2isDefeated = barbarian2.Defeat();
                                        break;
                                    case 2:
                                        magician2.BattleInfo();
                                        magician2.TakeDamage(warrior1Damage);
                                        magician2.StaminaReduce();
                                        magician2.HealWounds();
                                        Warrior2isDefeated = magician2.Defeat();
                                        break;
                                    case 3:
                                        knight2.BattleInfo();
                                        knight2.TakeDamage(warrior2Damage);
                                        knight2.StaminaReduce();
                                        knight2.Pray();
                                        Warrior2isDefeated = knight2.Defeat();
                                        break;
                                    case 4:
                                        damageDealer2.BattleInfo();
                                        damageDealer2.TakeDamage(warrior2Damage);
                                        damageDealer2.StaminaReduce();
                                        damageDealer2.BloodThirst();
                                        Warrior2isDefeated = damageDealer2.Defeat();
                                        break;
                                    case 5:
                                        tank2.BattleInfo();
                                        tank2.TakeDamage(warrior1Damage);
                                        tank2.StaminaReduce();
                                        tank2.ProtectionCall();
                                        Warrior2isDefeated = tank2.Defeat();
                                        break;
                                }

                                if (Warrior1isDefeated == true || Warrior2isDefeated == true)
                                {
                                    battleProcess = false;

                                    if ( !(Warrior1isDefeated == true && Warrior2isDefeated == true) )
                                    {
                                        if (Warrior1isDefeated == true) 
                                        {
                                            Console.WriteLine("Боец 2 победил.");
                                        }
                                        if (Warrior2isDefeated == true)
                                        {
                                            Console.WriteLine("Боец 1 победил.");
                                        }
                                    }
                                    else 
                                    {
                                        Console.WriteLine("Ничья.");
                                    }
                                    
                                }

                            }

                        }
                        else
                        {
                            Console.WriteLine("Бойцы не выбраны.");
                        }                       
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                    
                }
                
            }
        }
    }

    class Warrior 
    {
        protected float _hp;
        protected float _stamina;
        protected float _damage;
        protected float _armor;
        protected string _className;

        public Warrior(float lifes = 0, float endurance = 0, float loss = 0, float protection = 0, string name = "") 
        {
            _hp = lifes;
            _stamina = endurance;
            _damage = loss;
            _armor = protection;
            _className = name;
        }

        public float GetDamage() 
        {
            return _damage;
        }

        public void TakeDamage(float damage)
        {
            _hp -= damage / _armor;
        }

        public void StaminaReduce() 
        {
            float minStamina = _stamina / 5;
            bool isHappened = false;

            _stamina -= minStamina;

            if (isHappened == true)
            {
                _stamina += minStamina;
                isHappened = false;
                _damage *= 2;
            }

            if (_stamina < 0) 
            {
                _stamina = 0;
            }

            if (_stamina == 0) 
            {
                _damage /= 2;
                isHappened = true;
            }   
         
        }

        public virtual void ShowInfo() 
        {
            Console.WriteLine("Класс:" + _className + "\nЖизни: " + _hp + "\nВыносливость: " + _stamina + "\nУрон: " + _damage + "\nБроня: "+ _armor);
            Console.WriteLine();
        }

        public virtual void BattleInfo() 
        {
            Console.WriteLine("Класс:" + _className + "\nЖизни: " + _hp + "\nВыносливость: " + _stamina + "\nУрон: " + _damage);
            Console.WriteLine();
        }

        public bool Defeat() 
        {
            bool isDead = false;

            if(_hp <= 0)
            {
                _hp = 0;
                isDead = true;
            }

            return isDead;
        }

    }

    class Barbarian : Warrior
    {

        private float criticalDamage;

        Random random = new Random();

        public Barbarian(float lifes, float endurance, float loss, float protection, string name) : base(lifes, endurance, loss, protection, name) { }

        public void CriticalDamageChance() 
        {
            int value = random.Next(1, 5);

            switch (value) 
            { 
                case 1:
                    criticalDamage = 1;
                    break;
                case 2:
                    criticalDamage = 1;
                    break;
                case 3:
                    criticalDamage = 1;
                    break;
                case 4:
                    criticalDamage = 1.5F;
                    break;
            }

            _damage *= criticalDamage;
        }

        public void Rage() 
        { 
            float minHP = _hp/10;
            if (_hp <= minHP)
            {
                _damage += _damage * 30 / 100;
            }
        }

    }

    class Magician : Warrior 
    {
        
        private float mana;

        public Magician(float lifes, float endurance, float loss, float protection, float magicPower, string name) : base(lifes, endurance, loss, protection, name) 
        {
            mana = magicPower;
        }

        public void HealWounds() 
        { 
            float minHP = _hp/5;

            if (mana >= 20 && _hp <= minHP) 
            {
                mana -= 20;
                _hp += _hp/4;
            }
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Класс:" + _className + "\nЖизни: " + _hp + "\nВыносливость: " + _stamina + "\nУрон: " + _damage + "\nБроня: " + _armor + "\nМана: " + mana);
            Console.WriteLine();
        }

         public override void BattleInfo() 
        {
            Console.WriteLine("Класс:" + _className + "\nЖизни: " + _hp + "\nВыносливость: " + _stamina + "\nМана: "+ mana + "\nУрон: " + _damage);
            Console.WriteLine();
        }

    }

    class Knight : Warrior
    {
        public Knight(float lifes, float endurance, float loss, float protection, string name) : base(lifes, endurance, loss, protection, name) { }

        public void Pray() 
        {
            float minStamina = _stamina / 5;

            if (_stamina <= minStamina)
            {
                _stamina += _stamina/2;               
            }
        }
    }

    class DamageDealer : Warrior
    {
        public DamageDealer(float lifes, float endurance, float loss, float protection, string name) : base(lifes, endurance, loss, protection, name) { }

        public void BloodThirst() 
        {
            float minHP = _hp / 2;

            if (_hp > minHP)
            {
                _hp -= minHP;
                _damage *= 2;
            }
        }
    }

    class Tank : Warrior
    {
        public Tank(float lifes, float endurance, float loss, float protection, string name) : base(lifes, endurance, loss, protection, name) { }

        public void ProtectionCall() 
        {
            float minStamina = _stamina / 4;

            if (_stamina >= minStamina)
            {
                _stamina -= minStamina;
                _armor *= 1.2F;
            }
        }
    }
}
