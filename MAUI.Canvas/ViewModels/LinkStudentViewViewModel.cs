using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.Canvas.ViewModels
{
    internal class LinkStudentViewViewModel
    {
        public void LinkStudentClick(Shell s)
        {
            s.GoToAsync($"//LinkStudent");
        }
    }
}
