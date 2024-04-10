using MAUI.Canvas.ViewModels;
namespace MAUI.Canvas.Views;

public partial class AssignGradeView : ContentPage
{
	public AssignGradeView()
	{
		InitializeComponent();
		BindingContext = new AssignGradeViewModel();
	}
	private void CancelClicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("//Instructor");
    }
}