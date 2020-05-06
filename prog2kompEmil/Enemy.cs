using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog2kompEmil
{
    class Enemy
    {
        private int difficulty;

        private string attack;
        public string Attack
        {
            get
            {
                return attack;
            }
            private set
            {
                attack = value;
            }
        }

        private static string letters = "abcdefghijklmnopqrstuvwxyz";

        public Enemy(int dificultyInput)
        {
            difficulty = dificultyInput;

            Attack = "";
            for (int i = 0; i < difficulty; i++)
            {
                Attack += letters[Program.random.Next(0, letters.Length)];
            }
        }

        public bool Attacking(string input)
        {
            bool success = false;

            if (input.ToLower() == Attack)
            {
                Console.WriteLine("Enemy defeated");
                success = true;
            }
            else
            {
                Console.WriteLine("Try again");
            }
            return success;
        }
    }
}
