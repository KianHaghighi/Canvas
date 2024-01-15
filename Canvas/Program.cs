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
        int choice;
        do
        {
            Console.WriteLine("1. Create a course");
            Console.WriteLine("2. Create a student");
            Console.WriteLine("3. Add a student to a course");
            Console.WriteLine("4. Remove a student from a course");
            Console.WriteLine("5. List all courses");
            Console.WriteLine("6. Search for courses");
            Console.WriteLine("7. List all students");
            Console.WriteLine("8. Search for a student");
            Console.WriteLine("9. List all courses a student is taking");
            Console.WriteLine("10. Update a course’s information");
            Console.WriteLine("11. Update a student’s information");
            Console.WriteLine("12. Create an assignment for a course");
            Console.WriteLine("13. Show course information");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter course code: ");
                    string code = Console.ReadLine();
                    Console.Write("Enter course name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter course description: ");
                    string description = Console.ReadLine();
                    Course course = new Course(code, name, description);
                    courses.Add(course);
                    break;
                case 2:
                    Console.Write("Enter student name: ");
                    string studentName = Console.ReadLine();
                    Console.Write("Enter student classification: ");
                    string studentClassification = Console.ReadLine();
                    Person student = new Person(studentName, studentClassification);
                    students.Add(student);
                    break;
                case 3:
                    Console.Write("Enter course code: ");
                    string courseCode = Console.ReadLine();
                    Console.Write("Enter student name: ");
                    string studentName2 = Console.ReadLine();
                    Course course2 = courses.Find(c => c.Code == courseCode);
                    Person student2 = students.Find(s => s.Name == studentName2);
                    course2.Roster.Add(student2.Name);
                    break;
                case 4:
                    Console.Write("Enter course code: ");
                    string courseCode2 = Console.ReadLine();
                    Console.Write("Enter student name: ");
                    string studentName3 = Console.ReadLine();
                    Course course3 = courses.Find(c => c.Code == courseCode2);
                    Person student3 = students.Find(s => s.Name == studentName3);
                    course3.Roster.Remove(student3.Name);
                    break;
                case 5:
                    foreach (Course c in courses)
                    {
                        Console.WriteLine(c.Name);
                    }
                    break;
                case 6:
                    Console.Write("Enter course code: ");
                    string courseCode3 = Console.ReadLine();
                    Course course4 = courses.Find(c => c.Code == courseCode3);
                    Console.WriteLine(course4);
                    break;
                case 7:
                    foreach (Person s in students)
                    {
                        Console.WriteLine(s.Name);
                    }
                    break;
                case 8:
                    Console.Write("Enter student name: ");
                    string studentName4 = Console.ReadLine();
                    Person student4 = students.Find(s => s.Name == studentName4);
                    Console.WriteLine(student4);
                    break;
                case 9:
                    Console.Write("Enter student name: ");
                    string studentName5 = Console.ReadLine();
                    foreach (Course course5 in courses)
                    {
                        if (course5.Roster.Contains(studentName5))
                        {
                            Console.WriteLine($"Student {studentName5} is in course {course5.Code}");
                        }
                    }
                    break;
                case 10:
                    Console.Write("Enter course code: ");
                    string courseCode5 = Console.ReadLine();
                    Course course6 = courses.Find(c => c.Code == courseCode5);
                    Console.Write("Enter course name: ");
                    string name2 = Console.ReadLine();
                    Console.Write("Enter course description: ");
                    string description2 = Console.ReadLine();
                    course6.Name = name2;
                    course6.Description = description2;
                    break;
                case 11:
                    Console.Write("Enter student name: ");
                    string studentName6 = Console.ReadLine();
                    Person student6 = students.Find(s => s.Name == studentName6);
                    Console.Write("Enter student classification: ");
                    string classification2 = Console.ReadLine();
                    student6.Classification = classification2;
                    break;
                case 12:
                    Console.Write("Enter course code: ");
                    string courseCode6 = Console.ReadLine();
                    Course course7 = courses.Find(c => c.Code == courseCode6);
                    Console.Write("Enter assignment name: ");
                    string name3 = Console.ReadLine();
                    Console.Write("Enter assignment description: ");
                    string description3 = Console.ReadLine();
                    Console.Write("Enter assignment total available points: ");
                    int totalAvailablePoints = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter assignment due date: ");
                    DateTime dueDate = Convert.ToDateTime(Console.ReadLine());
                    Assignment assignment = new Assignment(name3, description3, totalAvailablePoints, dueDate);
                    course7.Assignments.Add(assignment);
                    break;
                case 13:
                    Console.Write("Enter course code: ");
                    string courseCode7 = Console.ReadLine();
                    Course course8 = courses.Find(c => c.Code == courseCode7);
                    Console.WriteLine(course8);
                    break;
             } } while (choice != 0);
        }
}