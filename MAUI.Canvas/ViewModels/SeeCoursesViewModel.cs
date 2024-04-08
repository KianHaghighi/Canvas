using Library.Canvas.Models;
using Library.Canvas.Services;

using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MAUI.Canvas.ViewModels
{
    public class SeeCoursesViewModel : INotifyPropertyChanged
    {
        private CourseService _courseService;
        private Course? course;
        private Person? student;
        private Person _selectedStudent;

        //for submit assignment
        private Assignment SelectedAssignment;
        public SeeCoursesViewModel(int id)
        {
            student = PersonService.Current.People.FirstOrDefault(p => p.Id == id);
        }
     
        public SeeCoursesViewModel(CourseService courseService)
        {
            _courseService = courseService;
        }
        public SeeCoursesViewModel(int id, CourseService courseService)
        {
            _courseService = courseService;
            student = PersonService.Current.People.FirstOrDefault(p => p.Id == id);
        }
        public Person SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
                OnPropertyChanged(nameof(CoursesForSelectedStudent));
            }
        }
        public IEnumerable<Course> GetCoursesForStudent(Person student)
        {
            return Courses.Where(course => course.Roster.Contains(student));
        }
        public IEnumerable<Course> CoursesForSelectedStudent
        {
            get { return GetCoursesForStudent(SelectedStudent); }
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
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
