using System;
using System.Media;
using System.Security;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        public bool infight = false;
        public bool playing = true;
        public int attack = 0;
        public bool itempickedUp = false;
        public bool itempickedUp2 = false;
        public bool itempickedUp3 = false;
        public Random rnd = new Random();


        public int monsterhealthsetting(int difficulty)
        {
            //sets the health of the monster based on the difficulty
            switch (difficulty)
            {
                case 1:
                    return 50;
                case 2:
                    return 100;
                case 3:
                    return 150;
                default:
                    return 0;
            }
        }
        public int monsterdamagesetting(int difficulty)
        {
            //sets the damage of the monster based on the difficulty
            switch (difficulty)
            {
                case 1:
                    return 5;
                case 2:
                    return 10;
                case 3:
                    return 15;
                default:
                    return 0;
            }
        }

        public void LookAround()
        {
            Console.Clear();
            if (player.Steps >= 5 && player.Steps <= 15)
            {
                Console.WriteLine("You see an assortment of items scattered around the room, something shiny cathing your eye");
            }
            else if (player.Steps >= 16 && player.Steps <= 25)
            {
                Console.WriteLine("You hear stumbling noises around you. Books are scattered around the room");
            }
            else if (player.Steps >= 26 && player.Steps <= 35)
            {
                Console.WriteLine("You see a large mirror in the room, you can see your reflection in it");
            }
            else if (player.Steps >= 36 && player.Steps <= 49)
            {
                Console.WriteLine("You see a large chest in the room, it seems to be locked");
            }
            else if (player.Steps == 50)
            {
                Console.WriteLine("You see a large door in front of you, it seems to be unlocked and light is shining through");
            }
            else
            {
                Console.WriteLine("You see nothing of interest in the room");
            }
        }

        public void RemoveItems()
        {
            if (player.inventoryContents().Contains("Sword"))
            {
                currentRoom.removeItem("Sword");
            }
            else if (player.inventoryContents().Contains("Shield"))
            {
                currentRoom.removeItem("Shield");
            }
            else if (player.inventoryContents().Contains("Potion"))
            {
                currentRoom.removeItem("Potion");
            }
        }
        public void WalkForwards()
        {
            Console.Clear();
            Console.WriteLine("You walk forwards.");
            player.move();
            if (player.Steps >= 5 && player.Steps <= 15)
            {
                if (player.Steps == 5)
                {
                    Console.WriteLine("You have now entered a new room");
                    player.addScore(100);
                }
                currentRoom = new Room("You are in a brightly lit room, with chandelliers and dining tables, food set out in an elegant fashion\n");
                //removes all items from room that the player has already picked up
                RemoveItems();
            }
            else if (player.Steps >= 16 && player.Steps <= 25)
            {
                if (player.Steps == 15)
                {
                    Console.WriteLine("You have now entered a new room");
                    player.addScore(100);
                }
                currentRoom = new Room("You are in a room with a large fireplace, a grand piano and a large bookshelf\n");
                RemoveItems();
            }
            else if (player.Steps >= 26 && player.Steps <= 35)
            {
                if (player.Steps == 26)
                {
                    Console.WriteLine("You have now entered a new room");
                    player.addScore(100);
                }
                currentRoom = new Room("You are in a room with a large bed, a wardrobe and a large mirror\n");
                RemoveItems();
            }
            else if (player.Steps >= 36 && player.Steps <= 49)
            {
                if (player.Steps == 36)
                {
                    Console.WriteLine("You have now entered a new room");
                    player.addScore(100);
                }
                currentRoom = new Room("You are in a room with a large table, a large chair and a large chest\n");
                RemoveItems();
            }
            else if (player.Steps == 50)
            {
                currentRoom = new Room("You are in a room with a large door. It seems to be unlocked and light is shining through.\n");
                player.addScore(100);
                RemoveItems();
                Console.WriteLine(currentRoom.getDescription());
                Console.WriteLine("1. Open the door");
                int answer = 0;
                try
                {
                    answer = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input.");
                }

                while (playing == true && answer == 1)
                {
                    if (answer == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("You open the door and walk through it.");
                        Console.WriteLine("You have reached the end of the dungeon!");
                        player.addScore(1000);
                        Console.WriteLine("Your score is: " + player.Score);
                        playing = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
            }
            attack = rnd.Next(1, 10);
            if (attack == 1)
            {
                int difficulty = rnd.Next(1, 4);
                Monster monster = new Monster(monsterhealthsetting(difficulty), monsterdamagesetting(difficulty), difficulty);
                infight = true;
                Console.WriteLine("A monster appears in front of you!");
                while (infight)
                {
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Attack");
                    Console.WriteLine("2. Run");
                    Console.WriteLine("3. Use item");
                    Console.WriteLine("Monster health: {0}", monster.Health);
                    Console.WriteLine("Your health: {0}", player.Health);
                    string fightinput = Console.ReadLine();
                    //begins the fight with the monster
                    switch (fightinput)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("You attack the monster!");
                            if (rnd.Next(1, 10) == 1 || rnd.Next(1, 10) == 2)
                            {
                                //random chance you can miss
                                Console.WriteLine("You missed!");
                                rnd.Next(1, 5);
                                if (player.inventoryContents().Contains("Shield"))
                                {
                                    //if the player has a shield they take less damage
                                    //if the player has a sword they deal more damage
                                    //if the player loses all health they die
                                    Console.WriteLine("You lost 5 health!");
                                    player.takeDamage(5);
                                    if (player.Health <= 0)
                                    {
                                        Console.WriteLine("You died!");
                                        playing = false;
                                    }
                                    Console.WriteLine("You have " + player.Health + " health left.");
                                }
                                else
                                {
                                    Console.WriteLine("You lost 10 health!");
                                    player.takeDamage(10);
                                    if (player.Health <= 0)
                                    {
                                        Console.WriteLine("You died!");
                                        playing = false;
                                    }
                                    Console.WriteLine("You have " + player.Health + " health left.");
                                }
                            }
                            else
                            //the fight ends when the monster is killed
                            {
                                Console.WriteLine("You hit the monster!");
                                if (player.inventoryContents().Contains("Sword"))
                                {
                                    monster.takeDamage(20);
                                    if (monster.Health <= 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You killed the monster!");
                                        player.addScore(500);
                                        infight = false;
                                    }
                                }
                                else
                                {
                                    monster.takeDamage(10);
                                    if (monster.Health <= 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("You killed the monster!");
                                        player.addScore(100);
                                        infight = false;
                                    }
                                }
                            }
                            break;
                        case "2":
                            Console.Clear();
                            //random chance you can run away
                            if (rnd.Next(1, 10) == 1 || rnd.Next(1, 10) == 2)
                            {
                                Console.WriteLine("You failed to run away!");
                                if (player.inventoryContents().Contains("Shield"))
                                {
                                    Console.WriteLine("You lost 5 health!");
                                    player.takeDamage(5);
                                    Console.WriteLine("You have " + player.Health + " health left.");
                                }
                                else
                                {
                                    Console.WriteLine("You lost 10 health!");
                                    player.takeDamage(10);
                                    Console.WriteLine("You have " + player.Health + " health left.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("You run away from the monster.");
                                player.removeScore(100);
                                infight = false;
                            }
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid input.");
                            break;
                        case "3":
                            Console.Clear();
                            if (player.inventoryContents() == "")
                            {
                                Console.WriteLine("You have no items in your inventory, try taking more steps in the dungeon.");
                            }
                            else
                            {
                                Console.WriteLine("You have a " + player.inventoryContents() + " in your inventory.");
                                //code to use item
                                Console.WriteLine("Would you like to use an item?");
                                Console.WriteLine("1. Yes");
                                Console.WriteLine("2. No");
                                string useitem = Console.ReadLine();
                                if (useitem == "1")
                                {
                                    Console.WriteLine("Which item would you like to use?");
                                    string item = Console.ReadLine();
                                    if (player.inventoryContents().Contains(item))
                                    {
                                        if (item == "Potion")
                                        {
                                            Console.WriteLine("You used a potion and gained 20 health!");
                                            player.potionEffect();
                                            Console.WriteLine("You now have " + player.Health + " health.");
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
                            }
                            break;
                    }
                }
            }
        }


        //method to pick up items in the dungeon
        public void PickUpItem()
        {
            Console.Clear();
            if (player.Steps >= 5 && player.Steps <= 15 && itempickedUp == false)
            {
                //adds a random item to the players inventory that hasnt already been picked up before
                string item = currentRoom.getrandomItem();
                Console.WriteLine("You picked up a " + item + "!");
                player.pickupItem(item);
                currentRoom.removeItem(item);
                itempickedUp = true;
            }
            else if (player.Steps >= 16 && player.Steps <= 25 && itempickedUp2 == false)
            {
                string item = currentRoom.getrandomItem();
                Console.WriteLine("You picked up a " + item + "!");
                player.pickupItem(item);
                currentRoom.removeItem(item);
                itempickedUp2 = true;
            }
            else if (player.Steps >= 26 && player.Steps <= 35)
            {
                string item = currentRoom.getrandomItem();
                Console.WriteLine("You picked up a " + item + "!");
                player.pickupItem(item);
                currentRoom.removeItem(item);
                itempickedUp3 = true;
            }
            else
            {
                Console.WriteLine("There are no items you can see, try taking more steps in the dungeon.");
            }
        }
        public void CheckInventory()
        {
            if (player.inventoryContents() == "")
            {
                Console.WriteLine("You have no items in your inventory, try taking more steps in the dungeon.");
            }
            else
            {
                Console.WriteLine("You have a " + player.inventoryContents() + " in your inventory.");
                //code to use item
                Console.WriteLine("Would you like to use an item?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                string useitem = Console.ReadLine();
                if (useitem == "1")
                {
                    //allows the user to use an item within their inventory
                    Console.WriteLine("Which item would you like to use?");
                    string item = Console.ReadLine();
                    if (player.inventoryContents().Contains(item))
                    {
                        if (item == "Potion")
                        {
                            Console.WriteLine("You used a potion and gained 20 health!");
                            player.potionEffect();
                            Console.WriteLine("You now have " + player.Health + " health.");
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
            }
        }
        public void EndGame()
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing!");
            playing = false;
        }

        public Game()
        {
            // Initialize the game with one room and one player
            Console.WriteLine("Welcome to the Dungeon Explorer!");
            Console.WriteLine("What is your name?");
            string playername = Console.ReadLine();
            player = new Player(playername, 100);
            currentRoom = new Room("You find yourself in a dark room, cold and afraid.\n");
        }
        public void Start()
        {
            //declare instance variables
            Random rnd = new Random();
            while (playing)
            {
                //display the initial menu
                Console.WriteLine(currentRoom.getDescription());
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Look around");
                Console.WriteLine("2. Walk Forwards");
                Console.WriteLine("3. Pick up item");
                Console.WriteLine("4. Check inventory");
                Console.WriteLine("5. Check Status");
                Console.WriteLine("6. Exit game");
                Console.WriteLine("You have taken: {0} steps", player.Steps);
                //await user input
                string input = Console.ReadLine();
                try
                {
                    //switch case for choice
                    switch (input)
                    {
                        //this case checks the players progress through the dungeon and displays different messages based on the amount of steps taken
                        case "1":
                            LookAround();
                            break;
                        //this case allows the player to move through the dungeon and spawns monsters at random intervals
                        case "2":
                            WalkForwards();
                            break;
                        case "3":
                            //code to pick up item
                            PickUpItem();
                            break;
                        case "4":
                            CheckInventory();
                            break;
                        //displays the players current status
                        case "5":
                            player.Status();
                            break;
                        case "6":
                            //ends the game
                            EndGame();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid input.");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input.");
                }

            }
        }
    }
}