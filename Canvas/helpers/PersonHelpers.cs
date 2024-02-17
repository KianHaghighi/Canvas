using System;
using System.Collections.Generic;
using Canvas.models;


namespace Canvas.Helpers
{
    public class PersonHelper
    {
        public static void ListAllPersons(List<Person> persons)
        {
            foreach (Person p in persons)
            {
                Console.WriteLine(p.Name);
                Console.WriteLine(p.Classification);
            }
        }
        public static Person? FindPersonByName(List<Person> persons, string? personName)
        {
            return persons.Find(p => p.Name == personName);
        }
        public static void UpdateStudentDetails(List<Person> students, string studentName, string newClassification, List<double> newGrades)
        {
            Person? student = students.Find(s => s.Name == studentName);
            if (student != null)
            {
                student.Classification = newClassification;
                student.Grades = newGrades;
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
