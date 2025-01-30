using System;
using System.Collections.Generic;

public class Location
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Dictionary<string, string> Interactions { get; set; }

    public Location(string name, string description)
    {
        Name = name;
        Description = description;
        Interactions = new Dictionary<string, string>();
    }

    public void AddInteraction(string action, string result)
    {
        Interactions.Add(action, result);
    }
}
