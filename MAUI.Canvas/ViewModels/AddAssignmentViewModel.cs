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
        public AddAssignmentViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AddAssignment()
        {

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
