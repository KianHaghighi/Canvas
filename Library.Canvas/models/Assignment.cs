using System;
namespace Library.Canvas.Models;

public class Assignment
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int TotalAvailablePoints { get; set; }
    public DateTime DueDate { get; set; }
    public List<ContentItem> Submissions { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}";
    }
    public Assignment(string name, string description, int totalAvailablePoints, DateTime dueDate)
    {
        Name = name;
        Description = description;
        TotalAvailablePoints = totalAvailablePoints;
        DueDate = dueDate;
        Submissions = new List<ContentItem>();
    }
}