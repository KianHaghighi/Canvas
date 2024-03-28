using Library.Canvas.Models;
using System.Collections.ObjectModel;

using Library.Canvas.Services;
namespace MAUI.Canvas.ViewModels
{
    internal class LinkStudentViewViewModel
    {
        public void OkClick(Shell s)
        {
            s.GoToAsync($"//LinkStudent");
        }
        public void AddPersonToCourse(Course course, Person person)
        {
            course.Roster.Add(person);
        }
        public ObservableCollection<Person> Students
        {
            get
            {
                return new ObservableCollection<Person>(PersonService.Current.People);
            }
        }
       /* public ObservableCollection<Person> Courses
        {
            get
            {
                //return new ObservableCollection<Person>(CourseService.Current.Courses);
            }
        }*/
    }
}
