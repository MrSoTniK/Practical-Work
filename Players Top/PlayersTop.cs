using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopPlayers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>
            {
                new Player("Sven", 62, 82),
                new Player("Gorilka", 71, 89),
                new Player("Horka", 56, 85),
                new Player("Shurka",90, 49),
                new Player("Gogo", 62, 52),
                new Player("Holabaga", 92, 95),
                new Player("Loloshka", 74, 23),
                new Player("Urka", 82, 62),
                new Player("Rostochek", 39, 52),
                new Player("Sverep", 72, 92)
            };

            Console.WriteLine("Игроки:");
            foreach(Player player in players)
            {
                player.Show();
            }
            Console.WriteLine();

            Console.WriteLine("Топ-3 игроков по уровню:");
            var filteredPlayersLvl = players.OrderByDescending(player => player.Level).Take(3);
            foreach (Player player in filteredPlayersLvl)
            {
                player.Show();
            }

            Console.WriteLine();
            Console.WriteLine("Топ-3 игроков по силе:");
            var filteredPlayersPower = players.OrderByDescending(player => player.Power).Take(3);
            foreach (Player player in filteredPlayersPower)
            {
                player.Show();
            }

            Console.ReadKey();
        }
    }

    class Player 
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        public Player(string name, int level, int power) 
        {
            Name = name;
            Level = level;
            Power = power;
        }

        public void Show() 
        {
            Console.WriteLine("Имя: "+ Name + ", уровень: " + Level.ToString() + ", сила: " + Power.ToString());
        }
    }
}
