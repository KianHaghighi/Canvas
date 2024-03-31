using MAUI.Canvas.ViewModels;
using Library.Canvas.Models;

namespace MAUI.Canvas.Views;

public partial class LinkStudentView : ContentPage
{
    //private Course course;
    //private Person student;

    public LinkStudentView()
    {
        InitializeComponent();
        BindingContext = new LinkStudentViewViewModel();
    }
	
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as LinkStudentViewViewModel).AddPersonToCourse();
        Shell.Current.GoToAsync("//Instructor");
    }
    

}