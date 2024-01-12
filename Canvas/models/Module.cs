using System.Collections.Generic;
namespace Canvas.models;

public class Module
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<string> Content { get; set; }

    public Module()
    {
        Content = new List<string>();
    }
}