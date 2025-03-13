// This file contains the Monster class, which is used to represent a monster in the game.
namespace DungeonExplorer
{
    public class Monster
    {
        public double Health { get; private set; }
        public double Damage { get; private set; }
        public int Difficulty { get; private set; }

        public Monster(double health, double damage, int difficulty)
        {
            // Initialize the monster with the given health, damage, and difficulty

            this.Health = health;
            this.Damage = damage;
            this.Difficulty = difficulty;
        }

        public void takeDamage(double damage)
        {
            // Reduce the monster's health by the given amount of damage
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }


    }
}