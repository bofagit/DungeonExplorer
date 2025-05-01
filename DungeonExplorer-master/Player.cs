using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public abstract class Creature
    {
        public string Name { get; set; }

        public double Health = 100;

        public Creature(string name, int health)
        {
            this.Name = name;
            this.Health = health;
        }
        public virtual void takeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }
    }
    public class Player : Creature
    {
        public Player(string name, int health) : base(name, health)
        {
            this.Name = name;
            this.Health = health;
        }

        public int Steps { get; private set; }
        public double Score { get; private set; }

        private List<string> Inventory = new List<string>();

        public override void takeDamage(int damage)
        {
            Console.WriteLine("You got hit. You lost {0} health!", damage);
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }
        public bool RunAway(Random rnd, bool infight)
        {
            if (rnd.Next(1, 10) == 1 || rnd.Next(1, 10) == 2)
            {
                Console.WriteLine("You failed to run away!");
                if (this.inventoryContents().Contains("Shield"))
                {
                    this.takeDamage(5);
                    Console.WriteLine("You have " + this.Health + " health left.");
                    return infight = true;
                }
                else
                {
                    Console.WriteLine("You lost 10 health!");
                    this.takeDamage(10);
                    Console.WriteLine("You have " + this.Health + " health left.");
                    return infight = true;
                }
            }
            else
            {
                Console.WriteLine("You run away from the monster.");
                this.removeScore(100);
                infight = false;
                return infight = false;
            }
        }
        public void UseItem()
        {
            Console.WriteLine("Which item would you like to use?");
            string item = Console.ReadLine();
            if (this.inventoryContents().Contains(item))
            {
                if (item == "Potion")
                {
                    Console.WriteLine("You used a potion and gained 20 health!");
                    this.potionEffect();
                    Console.WriteLine("You now have " + this.Health + " health.");
                }
                else
                {
                    Console.WriteLine("You cannot use that item.");
                }
            }
            else
            {
                Console.WriteLine("You do not have that item.");
            }
        }   
        public void attack(Monster monster, Player player, Random rnd, bool playing, bool infight)
        {
            //code to attack the monster
            //this is where the player will attack the monster
            //and the monster will take damage
            //and the player will take damage
            //and the player will gain score
            while (infight)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Run");
                Console.WriteLine("3. Use item");
                Console.WriteLine("Goblin health: {0}", monster.Health);
                Console.WriteLine("Your health: {0}", this.Health);
                string fightinput = Console.ReadLine();
                //begins the fight with the monster
                switch (fightinput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("You attack the Goblin!");
                        if (rnd.Next(1, 10) == 1 || rnd.Next(1, 10) == 2)
                        {
                            //random chance you can miss
                            Console.WriteLine("You missed!");
                            rnd.Next(1, 5);
                            if (this.inventoryContents().Contains("Shield"))
                            {
                                //if the player has a shield they take less damage
                                //if the player has a sword they deal more damage
                                //if the player loses all health they die
                                this.takeDamage(5);
                                if (this.Health <= 0)
                                {
                                    Console.WriteLine("You died!");
                                    playing = false;
                                }
                                Console.WriteLine("You have " + this.Health + " health left.");
                            }
                            else
                            {
                                this.takeDamage(10);
                                if (this.Health <= 0)
                                {
                                    Console.WriteLine("You died!");
                                    playing = false;
                                }
                                Console.WriteLine("You have " + this.Health + " health left.");
                            }
                        }
                        else
                        //the fight ends when the monster is killed
                        {
                            Console.WriteLine("You hit the Goblin!");
                            if (this.inventoryContents().Contains("Sword"))
                            {
                                monster.takeDamage(20);
                                if (monster.Health <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You killed the Goblin!");
                                    this.addScore(500);
                                    infight = false;
                                }
                            }
                            else
                            {
                                monster.takeDamage(10);
                                if (monster.Health <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You killed the Goblin!");
                                    this.addScore(100);
                                    infight = false;
                                }
                            }
                        }
                        break;
                    case "2":
                        Console.Clear();
                        //random chance you can run away
                        infight = this.RunAway(rnd, infight);
                        
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input.");
                        break;
                    case "3":
                        Console.Clear();
                        if (this.inventoryContents() == "")
                        {
                            Console.WriteLine("You have no items in your inventory, try taking more steps in the dungeon.");
                        }
                        else
                        {
                            Console.WriteLine("You have a " + this.inventoryContents() + " in your inventory.");
                            //code to use item
                            Console.WriteLine("Would you like to use an item?");
                            Console.WriteLine("1. Yes");
                            Console.WriteLine("2. No");
                            string useitem = Console.ReadLine();
                            if (useitem == "1")
                            {
                                this.UseItem();
                            }
                        }
                        break;

                }

            }
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