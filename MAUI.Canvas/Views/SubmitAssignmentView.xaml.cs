using MAUI.Canvas.ViewModels;
using Library.Canvas.Services;
using Library.Canvas.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace MAUI.Canvas.Views;

public partial class SubmitAssignmentView : ContentPage
{
    public int studentId
    {
        set; get;
    }
    public SubmitAssignmentView()
    {
        InitializeComponent();
        BindingContext = new SubmitAssignmentViewModel(studentId);
    }
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Student");
    }
    private void SubmitClicked(object sender, EventArgs e)
    {
        (BindingContext as SubmitAssignmentViewModel).SubmitAssignment();
        Shell.Current.GoToAsync("//Student");
    }
}