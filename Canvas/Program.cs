using System;
using System.Collections.Generic;
using System.Linq;
using Canvas.models;

class Program
{
    static List<Course> courses = new List<Course>();
    static List<Person> students = new List<Person>();

    static void Main(string[] args)
    {
        // Create a course and add it to a list of courses
        var course = new Course { Code = "CS101", Name = "Computer Science 101" };
        courses.Add(course);

        // Create a student and add it to a list of students
        var student = new Person("John Doe", "Freshman");
        students.Add(student);

        // Add a student from the list of students to a specific course
        course.Roster.Add(student.Name);

        // Remove a student from a course’s roster
        course.Roster.Remove(student.Name);

        // List all courses
        foreach (var c in courses)
        {
            Console.WriteLine($"Code: {c.Code}, Name: {c.Name}");
        }

        // Search for courses by name or description
        var searchResult = courses.Where(c => c.Name.Contains("Computer Science") || c.Description.Contains("Computer Science"));

        // List all students
        foreach (var s in students)
        {
            Console.WriteLine($"Name: {s.Name}, Classification: {s.Classification}");
        }

        // Search for a student by name
        var studentSearchResult = students.Where(s => s.Name.Contains("John Doe"));

        // List all courses a student is taking
        var studentCourses = courses.Where(c => c.Roster.Contains(student.Name));

        // Update a course’s information
        course.Name = "Updated Course Name";

        // Update a student’s information
        student.Name = "Updated Student Name";

        // Create an assignment and add it to the list of assignments for a course
        var assignment = new Assignment("Assignment 1", "First assignment", 100, DateTime.Now.AddDays(7));
        course.Assignments.Add(assignment.Name);

        // When selected from a list or search results, a course should show all its information.
        // Only the course code and name should show in the lists.
        Console.WriteLine($"Selected Course: Code: {course.Code}, Name: {course.Name}, Description: {course.Description}");
    }
}