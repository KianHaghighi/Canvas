using Library.Canvas.Database;
using Library.Canvas.Models;
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
}