using System;
using System.Collections.Generic;

public class Player
{
    public string Name { get; }
    public List<string> Inventory { get; private set; }
    public bool HasPotion { get; set; }
    public bool HasKey { get; set; }
    public bool GaveFoodToLady { get; set; }
    public bool IsCursed { get; set; }

    public Player(string name)
    {
        Name = name;
        Inventory = new List<string>();
        HasPotion = false;
        HasKey = false;
        GaveFoodToLady = false;
        IsCursed = false;
    }

    public void AddToInventory(string item)
    {
        if (!Inventory.Contains(item))
        {
            Inventory.Add(item); 
            Console.WriteLine($"{item} has been added to your inventory.");
        }
        else
        {
            Console.WriteLine($"{item} is already in your inventory.");
        }
    }
    public void ShowInventory()
    {
        Console.WriteLine("Your inventory:");
        if (Inventory.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
        }
        else
        {
            foreach (var item in Inventory)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }

    public void UseItem(string item)
    {
        if (Inventory.Contains(item))
        {
            Console.WriteLine($"You used {item}.");
            Inventory.Remove(item); 
        }
        else
        {
            Console.WriteLine($"You do not have {item} in your inventory.");
        }
    }
}
