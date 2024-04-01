using Library.Canvas.Models;
using Library.Canvas.Services;
using System.Collections.ObjectModel;


namespace MAUI.Canvas.ViewModels
{
    internal class CourseDetailViewViewModel
    {

        public CourseDetailViewViewModel()
        {
            course = new Course();
        }

        public string Name
        {
            get => course?.Name ?? string.Empty;
            set { if (course != null) course.Name = value; }
        }
        public string Description
        {
            get => course?.Description ?? string.Empty;
            set { if (course != null) course.Description = value; }
        }
        /*public string Prefix
        {
            get => course?.Prefix ?? string.Empty;
            set { if (course != null) course.Prefix = value; }
        }*/
        public int Id { get; set; }

        public string CourseCode
        {
            get => course?.Code ?? string.Empty;
        }

        private Course course;
        public void AddModules()
        {
            //implement
        }

        public void AddCourse()
        {
            CourseService.Current.Add(course);
            //s.GoToAsync("//Instructor");
        }
        public void AddPersonToCourse(Course course, Person person)
        {
            course.Roster.Add(person);
        }
        //added to make courses visible in the view
        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(CourseService.Current.Courses);
            }
        }
        public Course SelectedCourse { get; set; }
    }
}
