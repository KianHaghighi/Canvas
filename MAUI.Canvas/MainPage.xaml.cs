using MAUI.Canvas.ViewModels;
namespace MAUI.Canvas;


public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainViewViewModel();
	}
	private void StudentClicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("//StudentView");
    }
	private void InstructorClicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("//InstructorView");
    }
}

