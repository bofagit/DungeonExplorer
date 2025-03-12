// This file contains the Monster class, which is used to represent a monster in the game.
namespace DungeonExplorer
{
    public class Monster
    {
        public double health { get; private set; }
        public double damage { get; private set; }
        public int difficulty { get; private set; }

        public Monster(double health, double damage, int difficulty)
        {
            // Initialize the monster with the given health, damage, and difficulty

            this.health = health;
            this.damage = damage;
            this.difficulty = difficulty;
        }

        public void takeDamage(double damage)
        {
            // Reduce the monster's health by the given amount of damage

            health -= damage;
        }


    }
}