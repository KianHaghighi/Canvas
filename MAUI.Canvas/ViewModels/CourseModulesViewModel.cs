using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

using Library.Canvas.Models;
using Library.Canvas.Services;
using System.Runtime.CompilerServices;

namespace MAUI.Canvas.ViewModels
{
    internal class CourseModulesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Course? course;
        public Module? SelectedModule
        {
            get; set;
        }
        public CourseModulesViewModel(string code)
        {
            if (code == string.Empty || code == null)
            {
                course = new Course();
            }
            else
            {
                course = CourseService.Current.Get(code) ?? new Course();
            }
        }
        public ObservableCollection<Module> Modules
        {
            get
            {
                return new ObservableCollection<Module>(course.Modules.ToList());
            }
        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Modules));
        }
        /*public void Remove()
        {
            CourseService.Current.RemoveModule(course, SelectedModule);
            Refresh();
        }*/
    }
}

