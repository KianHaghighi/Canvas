using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library.Canvas.Models;
using Library.Canvas.Services;

namespace MAUI.Canvas.ViewModels
{
    public class SubmitAssignmentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private CourseService _courseService;
        private Course? course;
        private Person? student;
        private Person _selectedStudent;
        private Assignment _selectedAssignment;
        private string description;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public SubmitAssignmentViewModel(int id)
        {
            student = PersonService.Current.People.FirstOrDefault(p => p.Id == id);
        }
        public SubmitAssignmentViewModel(CourseService courseService)
        {
            _courseService = courseService;
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
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
        public Assignment SelectedAssignment
        {
            get { return _selectedAssignment; }
            set
            {
                _selectedAssignment = value;
                OnPropertyChanged(nameof(SelectedAssignment));
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
        /*public IEnumerable<Assignment> AssignmentsForSelectedCourse
        {
            get
            {
                if (course == null)
                {
                    return Enumerable.Empty<Assignment>();
                }
                return course.Assignments;
            }
        }*/
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
        public void SubmitAssignment()
        {
            if (SelectedAssignment != null)
            {
                SelectedAssignment.Submissions.Add(new ContentItem(student.Name, description));
            }
        }
    }
}
