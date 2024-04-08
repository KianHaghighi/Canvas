using System.Collections.Generic;
namespace Library.Canvas.Models;

public class Person
{
    public string? Name { get; set; }
    public string? Classification { get; set; }
    public List<double> Grades { get; set; }

    public int Id
    {
        get; private set;
    }

    public override string ToString()
    {
        string? gradesString;
        if (Grades != null)
        {
            gradesString = string.Join(", ", Grades);
        }
        else
        {
            gradesString = "No grades available";
        }
        return $"Name: {Name}, Classification: {Classification}, Grades: {gradesString}";
    }
    public Person(string name, string classification, List<double> grades = null)
    {
        Name = name;
        Classification = classification;
        Grades = grades;
    }

}
public enum PersonClassification
{
    Freshman, Sophomore, Junior, Senior
}