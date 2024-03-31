using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Library.Canvas.Models;
using Library.Canvas.Services;

namespace MAUI.Canvas.ViewModels
{
    internal class EditEnrollmentsViewModel 
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Course? course;
        private Person? student;
        public EditEnrollmentsViewModel(Course course, Person student)
        {
            if (course == null || student == null)
            {
                course = new Course();
            }
            else
            {
                this.course = course;
                this.student = student;
            }
        }
        public string Query { get; set; }
        public ObservableCollection<Person> People
        {
            get
            {
                //maybe change this line to:
                //return new ObservableCollection<Person>(course.Roster.ToList());
                return new ObservableCollection<Person>(PersonService.Current.People);
            }
        }
        public void Refresh()
        {
            //or nameof(Roster)
            NotifyPropertyChanged(nameof(People));
        }
        public void Remove()
        {
            CourseService.Current.Remove(course);
            Refresh();
        }

    }
}
