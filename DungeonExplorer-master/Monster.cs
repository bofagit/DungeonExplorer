// This file contains the Monster class, which is used to represent a monster in the game.
using System;
using System.Security.Cryptography.X509Certificates;

namespace DungeonExplorer
{
    public class Monster : Creature
    {
        public double Damage { get; private set; }
        public int Difficulty { get; private set; }


        public Monster(string name, double health, double damage, int difficulty) : base(name, (int)health)
        {
            // Initialize the monster's properties
            this.Health = health;
            this.Damage = damage;
            this.Difficulty = difficulty;
        }

        public virtual void takeDamage(double damage)
        {
            // Reduce the monster's health by the given amount of damage
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }


    }

    public class Goblin : Monster
    {
        public new double Damage { get; private set; }
        public new int Difficulty { get; private set; }
        public Goblin(string name, double health, double damage, int difficulty) : base(name, health, damage, difficulty)
        {
            // Initialize the goblin's properties
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Difficulty = difficulty;
        }
        public override void takeDamage(double damage)
        {
            // Reduce the goblin's health by the given amount of damage
            Console.WriteLine("The goblin took " + damage + " damage!");
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }

    }

    public class Troll : Monster
    {
        public new double Damage { get; private set; }
        public new int Difficulty { get; private set; }
        public Troll(string name, double health, double damage, int difficulty) : base(name, health, damage, difficulty)
        {
            // Initialize the troll's properties
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Difficulty = difficulty;
        }
        public override void takeDamage(double damage)
        {
            // Reduce the goblin's health by the given amount of damage
            Console.WriteLine("The Troll took " + damage + " damage!");
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }
    }
}