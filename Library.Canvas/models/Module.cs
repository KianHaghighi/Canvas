using System.Collections.Generic;
namespace Library.Canvas.Models;

public class Module
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<ContentItem> Items { get; set; }

    public Module()
    {
        Items = new List<ContentItem>();
    }
    public Module(string? name = "", string? description = "")
    {
        Name = name;
        Description = description;
        Items = new List<ContentItem>();
    }
}