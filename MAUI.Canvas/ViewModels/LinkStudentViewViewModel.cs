using Library.Canvas.Models;
using System.Collections.ObjectModel;

using Library.Canvas.Services;
namespace MAUI.Canvas.ViewModels
{
    internal class LinkStudentViewViewModel
    {
        public Person SelectedStudent { get; set; }
        public Course SelectedCourse { get; set; }
        public LinkStudentViewViewModel(Course course, Person student)
        {
            this.SelectedStudent = student;
            this.SelectedCourse = course;
        }
        public LinkStudentViewViewModel()
        {
        }
        public void AddPersonToCourse()
        {
            //couse null here
            var course = this.SelectedCourse;
            var student = this.SelectedStudent;
            if (course == null || student == null)
            {
                return;
            }
            course.Roster.Add(student);
        }
        public ObservableCollection<Person> Students
        {
            get
            {
                return new ObservableCollection<Person>(PersonService.Current.People);
            }
        }
        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(CourseService.Current.Courses);
            }
        }
    }
}
