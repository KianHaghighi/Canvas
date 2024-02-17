using System.Collections.Generic;
namespace Canvas.models;

public class Course
{
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<string> Roster { get; set; }
    public List<Assignment> Assignments { get; set; }
    public List<string> Modules { get; set; }
    public override string ToString()
{
    string rosterString = string.Join(", ", Roster);
    string assignmentsString = string.Join(", ", Assignments.Select(a => a.ToString()));
    string modulesString = string.Join(", ", Modules);
    return $"Course Code: {Code}, Name: {Name}, Description: {Description}, Roster: {rosterString}, Assignments: {assignmentsString}, Modules: {modulesString}";
}
 
    public Course()
    {
        Roster = new List<string>();
        Assignments = new List<Assignment>();
        Modules = new List<string>();
    }
    public Course(string code, string name, string description) : this()
    {
        Code = code;
        Name = name;
        Description = description;
    }
}