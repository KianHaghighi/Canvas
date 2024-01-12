using System.Collections.Generic;
namespace Canvas.models;

public class Person
{
    public string? Name { get; set; }
    public string? Classification { get; set; }
    public List<double> Grades { get; set; }

    public Person(string name, string classification)
    {
        Name = name;
        Classification = classification;
        Grades = new List<double>();
    }
}