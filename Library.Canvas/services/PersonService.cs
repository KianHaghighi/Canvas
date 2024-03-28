using Library.Canvas.Database;
using Library.Canvas.Models;

namespace Library.Canvas.Services;

public class PersonService
{
    private static PersonService? _instance;
    public IEnumerable<Person> People
    {
        get
        {
            return FakeDatabase.People;
        }
    }
    public static PersonService Current
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PersonService();
            }

            return _instance;
        }
    }
    private PersonService()
    {
        //IMPLEMENT
       // FakeDatabase.People.Add(new Person("Test", "Freshman"));
    }

    public void Add(Person student)
    {
        FakeDatabase.People.Add(student);
        var test = FakeDatabase.People;
    }

    public void Remove(Person student)
    {
        FakeDatabase.People.Remove(student);
    }
    public Person? GetById(int id)
    {
        return FakeDatabase.People.FirstOrDefault(p => p.Id == id);
    }

}