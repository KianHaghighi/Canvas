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
        private Assignment? assignment;
        private Person _selectedStudent;
        private Assignment? _selectedAssignment;
        private string description;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public SubmitAssignmentViewModel(int id, string assignment_name)
        {
            student = PersonService.Current.People.FirstOrDefault(p => p.Id == id);
            assignment = CourseService.Current.Assignments.FirstOrDefault(a => a.Name == assignment_name);
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
                OnPropertyChanged(nameof(AssignmentsForSelectedCourse));
                OnPropertyChanged(nameof(SelectedAssignment));
            }
        }
        public IEnumerable<Course> GetCoursesForStudent(Person student)
        {
            return Courses.Where(course => course.Roster.Contains(student));
        }
        //maybe the error is in this function
        public IEnumerable<Course> CoursesForSelectedStudent
        {
            get { return GetCoursesForStudent(SelectedStudent); }
        }
        public IEnumerable<Assignment> AssignmentsForSelectedCourse
        {
            get
            {
               var _courses = GetCoursesForStudent(SelectedStudent);
               return _courses.SelectMany(c => c.Assignments);
            }
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
        public ObservableCollection<Assignment> Assignments
        {
            get
            {
                return new ObservableCollection<Assignment>(CourseService.Current.Assignments);
            }
        }
        public void SubmitAssignment()
        {
            var assignment = this.SelectedAssignment;
            if (assignment != null)
            {
                assignment.Submissions.Add(new ContentItem(student.Name, description));
            }
            
        }
    }
}
