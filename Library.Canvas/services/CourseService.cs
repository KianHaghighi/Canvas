using Library.Canvas.Database;
using Library.Canvas.Models;

using System.Collections.ObjectModel;


namespace Library.Canvas.Services;
public class CourseService
{
    private static CourseService? _instance;
    public IEnumerable<Course> Courses
    {
        get
        {
            return FakeDatabase.Courses;
        }
    }
    public IEnumerable<Assignment> Assignments
    {
        get
        {
            return FakeDatabase.Assignments;
        }
    }
    public IEnumerable<ContentItem> Submissions
    {
        get
        {
            return FakeDatabase.Courses.SelectMany(m => m.Assignments).SelectMany(a => a.Submissions);
        }
    }
    public static CourseService Current
    {
        get
        {
            if (_instance == null)
            {
                _instance = new CourseService();
            }

            return _instance;
        }
    }
    private CourseService()
    {

    }
    public Course? Get(string code)
    {
        return Courses.FirstOrDefault(c => c.Code == code);
    }
    public void Add(Course course)
    {
        FakeDatabase.Courses.Add(course);
    }

    public IEnumerable<Course> GetCoursesForStudent(Person student)
    {
        return Courses.Where(course => course.Roster.Contains(student));
    }
    public IEnumerable<Course> Search(string query)
    {
        return Courses.Where(s => s.Name.ToUpper().Contains(query.ToUpper())
            || s.Description.ToUpper().Contains(query.ToUpper())
            || s.Code.ToUpper().Contains(query.ToUpper()));
    }
    public void Remove(Course course)
    {
        FakeDatabase.Courses.Remove(course);
    }
    //functions for adding modules

    //determine if a module is unique
    public bool IsModuleUnique(Course course, string name)
    {
        foreach (Module module in course.Modules)
        {
            if (module.Name == name)
            {
                return false;
            }
        }
        return true;
    }
    public void AddOrUpdateModule(Course course, Module module)
    {
        if (IsModuleUnique(course, module.Name))
        {
            course?.Modules?.Add(module);
        }
    }
    public Module? GetModule(Course course, string name)
    {
        return course?.Modules?.FirstOrDefault(m => m.Name == name);
    }
    public ObservableCollection<ContentItem> GetSubmissions(Assignment assignment)
    {
        return new ObservableCollection<ContentItem>(assignment.Submissions);
    }
}