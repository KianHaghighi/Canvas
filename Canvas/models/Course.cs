using System.Collections.Generic;
namespace Canvas.models;

public class Course
{
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<string> Roster { get; set; }
    public List<string> Assignments { get; set; }
    public List<string> Modules { get; set; }
 
    public Course()
    {
        Roster = new List<string>();
        Assignments = new List<string>();
        Modules = new List<string>();
    }
}