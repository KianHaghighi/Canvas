using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library.Canvas.Models;
using Library.Canvas.Services;

namespace MAUI.Canvas.ViewModels
{
    internal class StudentViewViewModel
    {
        public void SeeEnrollmentsClick(Shell s)
        {
            //need to be able to select a user, then see the classes that they are enrolled in
            s.GoToAsync($"//PersonDetail?personId=0");
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
