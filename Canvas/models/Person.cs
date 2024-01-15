using System.Collections.Generic;
namespace Canvas.models;

public class Person
{
    public string? Name { get; set; }
    public string? Classification { get; set; }
    public List<double> Grades { get; set; }

    public override string ToString()
    {
    string gradesString = string.Join(", ", Grades);
    return $"Name: {Name}, Classification: {Classification}, Grades: {gradesString}";
    }
    public Person(string name, string classification, List<double> grades)
    {
        Name = name;
        Classification = classification;
        Grades = grades;
    }
}