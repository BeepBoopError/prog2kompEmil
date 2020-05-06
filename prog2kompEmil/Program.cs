using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog2kompEmil
{
    class Program
    {
        public static Random random = new Random();

        private static int seconds = 0;
        public static int Seconds
        {
            get
            {
                return seconds;
            }
            private set
            {
                seconds = value;
            }
        }

        private static List<Game> games = new List<Game>();

        private static int resurrect = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to type fighter");

            Console.WriteLine("type the correct response to each enemy to defeat it");

            Console.ReadLine();

            bool playGame = true;

            while (playGame)
            {
                Console.Clear();
                games.Add(new Game());

                System.Timers.Timer aTimer = new System.Timers.Timer();
                aTimer.Elapsed += OnTimedEvent;
                aTimer.Interval = 1000;
                aTimer.Enabled = true;

                bool playingGame = true;
                while (playingGame)
                {
                    for (int i = 0; i < resurrect; i++)
                    {
                        games[games.Count - 1].Ressurect();
                    }
                    resurrect = 0;
                    if (!games[games.Count - 1].Round())
                    {
                        Console.WriteLine("You win! your score is " + games[games.Count - 1].Score);
                        aTimer.Enabled = false;
                        seconds = 0;
                        Console.ReadLine();
                        playingGame = false;
                    }
                    Console.Clear();
                }

                Console.WriteLine("These are your scores so far:");
                for (int i = 0; i < games.Count; i++)
                {
                    Console.WriteLine(games[i].Score);
                }

                
                
                
                Console.WriteLine("If you'd like to play again, type 'y', if you'd like to quit, type 'n'");
                string input = Console.ReadLine();
                if (input == "n")
                {
                    Console.WriteLine("See ya later!");
                    playGame = false;
                }
                else
                {
                    Console.WriteLine("Lets go again!");
                }
            }
        }

        private static void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            Seconds++;
            if (Seconds % 10 == 0) 
            {
                resurrect++;
            }
        }
    }
}
