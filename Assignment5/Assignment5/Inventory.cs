using System;
using System.Collections.Generic;
using System.Text;


namespace Assignment5
{
    public class Inventory
    {
        // The dictionary items consist of the item and the quantity
        private Dictionary<Item, int> items;

        public int AvailableSlots
        {
            get
            {
                return availableSlots;
            }
        }

        public int MaxSlots
        {
            get
            {
                return maxSlots;
            }
        }

        // The available slots to add item, once it's 0, you cannot add any more items.
        private int availableSlots;

        // The max available slots which is set only in the constructor.
        private int maxSlots;

        public Inventory(int slots)
        {
            maxSlots = slots;
            availableSlots = maxSlots;
            items = new Dictionary<Item, int>(); // Initialize the dictionary
        }

        public void Reset()
        {
            items.Clear();
            availableSlots = maxSlots;
        }

        public bool TakeItem(string name, out Item found)
        {
            foreach (var item in items)
            {
                if (item.Key.Name == name)
                {
                    found = item.Key;
                    if (item.Value > 1)
                    {
                        items[item.Key]--;
                    }
                    else
                    {
                        items.Remove(item.Key);
                    }
                    availableSlots++;
                    return true;
                }
            }
            found = null;
            return false;
        }

        public bool AddItem(Item item)
        {
            if (availableSlots > 0)
            {
                if (items.ContainsKey(item))
                {
                    items[item]++;
                }
                else
                {
                    items[item] = 1;
                    availableSlots--;
                }
                return true;
            }
            return false; // inventory is full
        }

        public List<Item> ListAllItems()
        {
            List<Item> allItems = new List<Item>();
            foreach (var kvp in items)
            {
                for (int i = 0; i < kvp.Value; i++)
                {
                    allItems.Add(kvp.Key);
                }
            }
            return allItems;
        }
    }
}