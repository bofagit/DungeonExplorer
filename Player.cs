using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public double Health { get; private set; }
        public int Steps { get; private set; }
        public double Score { get; private set; }
        private List<string> Inventory = new List<string>();

        public Player(string name, int health) 
        {
            this.Name = name;
            this.Health = health;
        }
        public void addScore(int points)
        {
            Score += points;
        }
        public void removeScore(int points)
        {
            Score -= points;
        }
        public void pickupItem(string item)
        {
            if (item != null)
            {
                Inventory.Add(item);
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
            Steps++;
        }  
        public string inventoryContents()
        {
            return string.Join(", ", Inventory);
        }
        public void Status()
        {
            Console.Clear();
            System.Console.WriteLine("Name: " + Name);
            System.Console.WriteLine("Health: " + Health);
            System.Console.WriteLine("Score: " + Score);
            System.Console.WriteLine("Steps: " + Steps);
        }
    }
}