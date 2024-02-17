// CourseHelper.cs
using System;
using System.Collections.Generic;
using Canvas.models;


namespace Canvas.Helpers{
public static class CourseHelper
{
    public static void ListAllCourses(List<Course> courses)
    {
        foreach (Course c in courses)
        {
            Console.WriteLine(c.Code);
            Console.WriteLine(c.Name);
        }
    }
    public static Course? FindCourseByCode(List<Course> courses, string? courseCode)
    {
        return courses.Find(c => c.Code == courseCode);
    }
    public static void UpdateCourseDetails(List<Course> courses, string courseCode, string newName, string newDescription)
    {
        Course? course = courses.Find(c => c.Code == courseCode);
        if (course != null)
        {
            course.Name = newName;
            course.Description = newDescription;
        }
        else
        {
            Console.WriteLine("Course not found.");
        }
    }
}
}
