using MAUI.Canvas.ViewModels;
namespace MAUI.Canvas.Views;

public partial class StudentView : ContentPage
{
	public StudentView()
	{
		InitializeComponent();
		BindingContext = new StudentViewViewModel();
	}
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
	private void SeeCoursesClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//SeeCoursesView");
		//(BindingContext as StudentViewViewModel)?.SeeCoursesClick (Shell.Current);
	}
	private void SubmitAnAssignmentClicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("//SubmitAssignmentView");
    }
}