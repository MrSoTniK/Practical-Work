using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalOAndC
{
    class BattleWithBoss
    {
        public string exit;
        public void Solution()
        {
           
            bool contin = true;

            while (contin == true)
            {
                Random rand = new Random();
                float bossHealth = rand.Next(100,301);
                float bossMana = rand.Next(49, 201);
                float bossArmor = rand.Next(10, 21);
                float bossMagicResist = rand.Next(9, 21);
                float bossDamage = rand.Next(19, 41);

                float playerHealth = rand.Next(100, 201);
                float playerStaticHP = playerHealth;
                float playerMana = rand.Next(99, 201);
                float playerStaticMana = playerMana;
                float playerArmor = rand.Next(10, 81);
                float playerManaResist = rand.Next(10, 81);
                float playerDamage = rand.Next(50, 70);
                float playerSpell1 = rand.Next(50, 100);
                float playerSpell2 = rand.Next(15, 50);
                float playerSpell3 = rand.Next(50, 100);
                float playerSpell4 = rand.Next(200, 300);
                float chance;
                string userCommand;
                int bossLogic;
                bool playerLogic = true;
                bool barrier = false;

                Console.WriteLine("Вы - теневой маг. Сейчас вам предстоит битва с боссом.");
                Console.WriteLine("Ваши характеристики:");
                Console.WriteLine("Жизни: " + playerHealth);
                Console.WriteLine("Мана: " + playerMana);
                Console.WriteLine("Броня: " + playerArmor);
                Console.WriteLine("Сопротивление магии: " + playerManaResist);
                Console.WriteLine("Урон с ближней атаки: (команда \"Атака\" ) " + playerDamage);
                Console.WriteLine("Урон заклинания Ашкарантай: " + playerSpell1+". Расход маны: 60");
                Console.WriteLine("Восстановление здоровья заклинанием Ушнелус: " + playerSpell2 + ". Расход маны: 40");
                Console.WriteLine("Урон заклинания Камудазе: " + playerSpell3 + ". Расход маны: 100");
                Console.WriteLine("Урон заклинания Саженелус: " + playerSpell4 + ". Расход маны: 70");
                Console.WriteLine("Доступные команды: Атака; Ашкарантай; Ушнелус; Камудазе; Саженелус; Пропуск.");
                Console.WriteLine("Характеристики босса:");
                Console.WriteLine("Жизни: " + bossHealth);
                Console.WriteLine("Мана: " + bossMana);
                Console.WriteLine("Броня: " + bossArmor);
                Console.WriteLine("Сопротивление магии: " + bossMagicResist);
                Console.WriteLine("Урон с ближней атаки: " + bossDamage);
                Console.WriteLine("Начинается битва с боссом, приготовтесь.");
                while (playerHealth > 0 && bossHealth>0)
                {
                    Console.WriteLine("Ваш ход");
                    while (playerLogic == true)
                    {
                        playerLogic = false;                       
                        userCommand = Console.ReadLine();
                        if (userCommand == "Атака")
                        {
                            Console.WriteLine("Вы наносите удар посохом.\nУрон: " + (playerDamage * bossArmor / 100));                            
                            bossHealth -= playerDamage * bossArmor / 100;
                            Console.WriteLine("Жизни босса: " + bossHealth);
                        }
                        if (userCommand == "Ашкарантай")
                        {
                            if (playerMana >= 60)
                            {
                                Console.WriteLine("Вы выпускаете луч теневой энергии.\nУрон: " + (playerSpell1 * bossMagicResist / 100));
                                playerMana -= 60;
                                Console.WriteLine("Маны осталось: " + playerMana);                               
                                bossHealth -= playerSpell1 * bossMagicResist / 100;
                                Console.WriteLine("Жизни босса: " + bossHealth);
                            }
                            else
                            {
                                Console.WriteLine("У вас недостаточно маны");
                                playerLogic = true;
                            }
                        }
                        if (userCommand == "Ушнелус")
                        {
                            if (playerMana >= 40)
                            {
                                playerHealth += playerSpell2;
                                if (playerHealth > playerStaticHP)
                                {
                                    playerHealth = playerStaticHP;
                                }
                                Console.WriteLine("Исцеляющая аура тьмы окутывает вас.\nВаши жизни: " + playerHealth);
                                playerMana -= 40;
                                Console.WriteLine("Маны осталось: " + playerMana);
                            }
                            else
                            {
                                Console.WriteLine("У вас недостаточно маны");
                                playerLogic = true;
                            }
                        }
                        if (userCommand == "Камудазе")
                        {
                            if (playerMana >= 100)
                            {
                                Console.WriteLine("Вы создаете защитный барьер.\nБарьер сможет поглотить урон в количестве: " + playerSpell3);
                                playerMana -= 100;
                                Console.WriteLine("Маны осталось: " + playerMana);
                                barrier = true;
                            }
                            else
                            {
                                Console.WriteLine("У вас недостаточно маны");
                                playerLogic = true;
                            }
                        }
                        if (userCommand == "Саженелус")
                        {
                            if (playerMana >= 70)
                            {
                                chance = rand.Next(-1, 2);
                                Console.WriteLine("Вы вызваете к царству теней, чтобы они поглотили противника.Ответят ли тени на ваш зов?(Шанс срабаывания 50 на 50) \nУрон: " + (chance * playerSpell4 * bossMagicResist / 100));
                                playerMana -= 70;
                                Console.WriteLine("Маны осталось: " + playerMana);                                
                                bossHealth -= chance * playerSpell4 * bossMagicResist / 100;
                                Console.WriteLine("Жизни босса: " + bossHealth);
                            }
                            else
                            {
                                Console.WriteLine("У вас недостаточно маны");
                                playerLogic = true;
                            }
                        }
                        if (userCommand == "Пропуск")
                        {
                            Console.WriteLine("Вы решаете пропустить ход, чтобы восстановить силы");                          
                            playerHealth += 30;
                            if (playerHealth>playerStaticHP) 
                            {
                                playerHealth = playerStaticHP;
                            }
                            playerMana += 50;
                            if (playerMana > playerStaticMana)
                            {
                                playerMana = playerStaticMana;
                            }
                            Console.WriteLine("Ваши жизни" + playerHealth);
                            Console.WriteLine("Ваша мана" + playerMana);
                        }
                    }
                    Console.WriteLine("Ход противника");
                    bossLogic = rand.Next(1, 3);
                    switch(bossLogic)
                    {
                        case 1:
                            Console.WriteLine("Противник использует свирепый удар");
                            if (barrier != true)
                            {
                                playerHealth -= bossDamage * playerArmor / 100;
                            }
                            else 
                            {
                                Console.WriteLine("Сработал защитнавй барьер!");
                                barrier = false;
                                if (playerSpell3 >= bossDamage)
                                {
                                    Console.WriteLine("Весь урон был поглощен барьером.");
                                }
                                else
                                {
                                    playerHealth -= (bossDamage - playerSpell3) * playerArmor / 100;
                                }
                            }
                            Console.WriteLine("Ваши жизни: " + playerHealth);
                            break;
                        case 2:
                            Console.WriteLine("Противник высасывает из вас жизненную энергию");
                            playerHealth -= 50;
                            bossHealth += 50;
                            Console.WriteLine("Ваши жизни: " + playerHealth);
                            Console.WriteLine("Жизни босса: " + bossHealth);
                            break;                                                  
                    }
                    playerLogic = true;

                }
                if (playerHealth <= 0) 
                {
                    Console.WriteLine("Увы, но вы проиграли. Повезет в следующий раз.");
                }
                if (bossHealth <= 0)
                {
                    Console.WriteLine("Поздравляем!Вы победили!");
                }
               
                Console.WriteLine("Выйти или начать заново? 1 - ввыйти, любое др. значение - заново ");
                exit = Console.ReadLine();
                if (exit == "1")
                {
                    contin = false;
                }

            }
        }
    }
}
