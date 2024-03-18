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
	/*private void SeeEnrollmentsClicked(object sender, EventArgs e)
	{
        (BindingContext as StudentViewViewModel)?.SeeEnrollmentsClick(Shell.Current);
    }*/
}