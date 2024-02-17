using System;
using System.Collections.Generic;
using System.Linq;
using Canvas.models;
using Canvas.Helpers;


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
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());


            switch (choice)
            {
                case 1:
                    Console.Write("Enter course code: ");
                    string? code = Console.ReadLine();
                    Console.Write("Enter course name: ");
                    string? name = Console.ReadLine();
                    Console.Write("Enter course description: ");
                    string? description = Console.ReadLine();
                    if (code != null && name != null && description != null)
                    {
                        Course course = new Course(code, name, description);
                        courses.Add(course);
                    }
                    else
                    {
                        Console.WriteLine("Course code, name, or description is null.");
                    }
                    break;
                case 2:
                    Console.Write("Enter student name: ");
                    string? studentName = Console.ReadLine();
                    Console.Write("Enter student classification: ");
                    string? studentClassification = Console.ReadLine();
                    Console.Write("Enter student grades (comma-separated): ");
                    string? gradesInput = Console.ReadLine();
                    List<double>? grades = gradesInput?.Split(',').Select(double.Parse).ToList();
                    if (studentName != null && studentClassification != null && grades != null)
                    {
                        Person? student = new Person(studentName, studentClassification, grades);
                        students.Add(student);
                    }
                    else
                    {
                        Console.WriteLine("Student name, classification, or grades are null.");
                    }
                    break;
                case 3:
                    Console.Write("Enter course code: ");
                    string? courseCode = Console.ReadLine();
                    Console.Write("Enter student name: ");
                    string? studentName2 = Console.ReadLine();
                    Course? course2 = courses.Find(c => c.Code == courseCode);
                    Person? student2 = students.Find(s => s.Name == studentName2);
                    if (course2 != null && student2 != null && student2.Name != null)
                    {
                        course2.Roster.Add(student2.Name);
                    }
                    else
                    {
                        Console.WriteLine("Course or student not found.");
                    }
                    break;
                case 4:
                    Console.Write("Enter course code: ");
                    string? courseCode2 = Console.ReadLine();
                    Console.Write("Enter student name: ");
                    string? studentName3 = Console.ReadLine();
                    Course? course3 = courses.Find(c => c.Code == courseCode2);
                    Person? student3 = students.Find(s => s.Name == studentName3);
                    if (course3 != null && student3 != null && student3.Name != null){
                        course3.Roster.Remove(student3.Name);
                    }
                    else
                    {
                        Console.WriteLine("Course or student not found.");
                    }
                    break;
                case 5:
                    CourseHelper.ListAllCourses(courses);
                    break;


                case 6:
                    Console.Write("Enter course code: ");
                    string? courseCode3 = Console.ReadLine();
                    Course? course4 = CourseHelper.FindCourseByCode(courses, courseCode3);
                    Console.WriteLine(course4);
                    break;
                case 7:
                    PersonHelper.ListAllPersons(students);
                    break;
                case 8:
                    Console.Write("Enter student name: ");
                    string? studentName4 = Console.ReadLine();
                    Person? student4 = PersonHelper.FindPersonByName(students, studentName4);
                    if(student4 != null){
                        Console.WriteLine(student4);
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;
                case 9:
                    Console.Write("Enter student name: ");
                    string? studentName5 = Console.ReadLine();
                    foreach (Course course5 in courses)
                    {
                        if (studentName5 != null && course5.Roster.Contains(studentName5))
                        {
                            Console.WriteLine($"Student {studentName5} is in course {course5.Code}");
                        }
                    }
                    break;
                case 10:
                    Console.Write("Enter course code: ");
                    string? courseCode5 = Console.ReadLine();
                    Console.Write("Enter course name: ");
                    string? name2 = Console.ReadLine();
                    Console.Write("Enter course description: ");
                    string? description2 = Console.ReadLine();
                    if (name2 != null && description2 != null && courseCode5 != null)
                    {
                        CourseHelper.UpdateCourseDetails(courses, courseCode5, name2, description2);
                    }
                    else
                    {
                        Console.WriteLine("Course name, description or code is null.");
                    }
                    break;
                case 11:
                    Console.Write("Enter student name: ");
                    string? studentName6 = Console.ReadLine();
                    Console.Write("Enter student classification: ");
                    string? classification2 = Console.ReadLine();
                    Console.Write("Enter student grades (comma-separated): ");
                    string? gradesUpdate = Console.ReadLine();
                    List<Double>? gradesUpdated = gradesUpdate?.Split(',').Select(Double.Parse).ToList();
                    if (classification2 != null && studentName6 != null && gradesUpdated != null)
                    {
                        PersonHelper.UpdateStudentDetails(students, studentName6, classification2, gradesUpdated);
                    }
                    else
                    {
                        Console.WriteLine("Student name, classification or grades are null.");
                    }
                    break;
                case 12:
                    Console.Write("Enter course code: ");
                    string? courseCode6 = Console.ReadLine();
                    Course? course7 = courses.Find(c => c.Code == courseCode6);
                    Console.Write("Enter assignment name: ");
                    string? name3 = Console.ReadLine();
                    Console.Write("Enter assignment description: ");
                    string? description3 = Console.ReadLine();
                    Console.Write("Enter assignment total available points: ");
                    int totalAvailablePoints = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter assignment due date: ");
                    DateTime dueDate = Convert.ToDateTime(Console.ReadLine());
                    if (name3 == null || description3 == null)
                    {
                        Console.WriteLine("Assignment name or description is null.");
                        break;
                    }
                    else if (course7 == null)
                    {
                        Console.WriteLine("Course not found.");
                        break;
                    }
                    Assignment assignment = new Assignment(name3, description3, totalAvailablePoints, dueDate);
                    course7.Assignments.Add(assignment);
                    break;
             } } while (choice != 0);
        }
}

