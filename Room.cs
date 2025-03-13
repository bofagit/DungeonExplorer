using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private string[] items;


        public Room(string description)
        {
            this.description = description;
            this.items = new string[] { "Sword", "Shield", "Potion" };
        }

        public string getDescription()
        {
            return description;
        }
        
        public void removeItem(string item)
        {
            //code to remove items the player has already picked up in previous rooms
            List<string> itemsList = items.ToList();
            itemsList.Remove(item);
            items = itemsList.ToArray();
        }


        public string getrandomItem()
        {
            Random rnd = new Random();
            int index = rnd.Next(items.Length);
            return items[index];
        }   
    }
}