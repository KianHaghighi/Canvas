using System.Collections.Generic;
namespace Canvas.models;

public class ContentItem
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Path { get; set; }
    public ContentItem(string name, string description, string path)
    {
        Name = name;
        Description = description;
        Path = path;
    }
}