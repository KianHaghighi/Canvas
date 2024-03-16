using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Canvas.ViewModels
{
    internal class InstructorViewViewModel
    {
        public void AddEnrollmentClick(Shell s)
        {
            s.GoToAsync($"//PersonDetail?personId=0");
        }
    }
}
