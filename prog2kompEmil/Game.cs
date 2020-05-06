using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog2kompEmil
{
    class Game
    {
        /*
        Each game of type writers starts with the game creating a stack of enemies that are harder difficulty the lower in the stck they are. 
        Each time the player defeats an enemy it is removed from the stack, if the player manages to empty the stack they win. 
        However the dead enemies are put in to a queue, and the first enemy in the queue is returned to the top of the stack every 10 seconds. 
        The player has to keep defeating enemies in order to make it through the stack, faster than they can respawn. 
        */
        private Stack<Enemy> enemies = new Stack<Enemy>();

        private Queue<Enemy> deadEnemies = new Queue<Enemy>();

        private int difficulty = 10;

        private int score = 0;
        public int Score
        {
            get
            {
                return score;
            }
            private set
            {
                score = value;
            }
        }

        public Game()
        {
            for (int i = 0; i < difficulty; i++)
            {
                enemies.Push(new Enemy(difficulty - i + 1));
            }
        }

        public bool Round()
        {
            bool success = true;
            try
            {
                Console.WriteLine("Type " + enemies.Peek().Attack + " as fast as you can!");

                if (enemies.Peek().Attacking(Console.ReadLine()))
                {
                    deadEnemies.Enqueue(enemies.Pop());
                }
            }
            catch
            {
                success = false;
                Score = 1000 - Program.Seconds;
            }
            return success;
        }

        public void Ressurect()
        {
            try
            {
                enemies.Push(deadEnemies.Dequeue());
                //Console.WriteLine("An enemy has returned!");
            }
            catch 
            {

                
            }
        }
    }
}
