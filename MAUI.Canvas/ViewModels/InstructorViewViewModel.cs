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
    internal class InstructorViewViewModel : INotifyPropertyChanged
    {
        public void AddEnrollmentClick(Shell s)
        {
            s.GoToAsync($"//PersonDetail?personId=0");
        }
        public void AddCourseClick(Shell s)
        {
            s.GoToAsync($"//CourseDetail");
        }
        public void LinkStudentClick(Shell s)
        {
            s.GoToAsync($"//LinkStudent");
        }
        public void EditEnrollmentClicked(Shell s)
        {
            /*if (SelectedPerson == null) { return; }
            s.GoToAsync($"//PersonDetail?personId={SelectedPerson.Id}");*/
            s.GoToAsync($"//EditEnrollments");
        }
        public void RemoveEnrollmentClick()
        {
            if (SelectedPerson == null) { return; }

            PersonService.Current.Remove(SelectedPerson);
            RefreshView();
        }
        public void ViewModulesClick(Shell s)
        {
            //SelectedCourse is null here
            //theres no SelectedCourse property in the InstructorViewModel, only in LinkStudentView
            //so I need to add a SelectedCourse property to the InstructorViewModel
            //1.list the courses from a menu, and allow the user to select one
            //maybe instead of a viewmodules view model, just add this functionality to the CourseDetailViewModel
            //with a button on CourseDetail view model that says "View Modules"
            if (SelectedCourse == null) { return; }
            s.GoToAsync($"//CourseModules?courseCode={SelectedCourse.Code}");
        }
        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(People));
            NotifyPropertyChanged(nameof(Courses));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Person SelectedPerson { get; set; }
        public Course SelectedCourse { get; set; }
        private string query;
        public string Query
        {
            get => query;
            set
            {
                query = value;
                NotifyPropertyChanged(nameof(People));
            }
        }
        public ObservableCollection<Person> People
        {
            get
            {

                var filteredList = PersonService
                    .Current
                    .People
                    .Where(
                    s => s.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty));
                return new ObservableCollection<Person>(filteredList);

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
