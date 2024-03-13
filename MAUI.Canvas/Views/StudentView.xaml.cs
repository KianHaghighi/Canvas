using MAUI.Canvas.ViewModels;
namespace MAUI.Canvas.Views;

public partial class StudentView : ContentPage
{
	public StudentView()
	{
		InitializeComponent();
		BindingContext = new StudentViewViewModel();
	}
}