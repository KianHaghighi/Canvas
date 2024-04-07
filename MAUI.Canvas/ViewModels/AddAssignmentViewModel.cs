using Library.Canvas.Services;
using Library.Canvas.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MAUI.Canvas.ViewModels
{
    internal class AddAssignmentViewModel : INotifyPropertyChanged
    {
        public string AssignmentName { get; set; }
        public string AssignmentDescription { get; set; }
        public int AssignmentTotalAvailablePoints { get; set; }
        public DateTime AssignmentDueDate { get; set; }
        public Course SelectedCourse { get; set; }
        
        public AddAssignmentViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddAssignment()
        {
            var course = this.SelectedCourse;
            course.Assignments.Add(new Assignment(AssignmentName, AssignmentDescription, AssignmentTotalAvailablePoints, AssignmentDueDate));
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
