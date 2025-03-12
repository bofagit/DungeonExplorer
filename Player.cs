using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public double Health { get; private set; }
        public int steps { get; private set; }
        public double score { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            this.Name = name;
            this.Health = health;
        }
        public void addScore(int points)
        {
            score += points;
        }
        public void removeScore(int points)
        {
            score -= points;
        }
        public void pickupItem(string item)
        {
            if (item != null)
            {
                inventory.Add(item);
            }
        }
        public void potionEffect()
        {
            Health += 10;
        }   

        public void takeDamage(int damage)
        {
            Health -= damage;
        }
        public void move()
        {
            steps++;
        }  
        public string inventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}