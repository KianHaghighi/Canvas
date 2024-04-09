using MAUI.Canvas.ViewModels;
namespace MAUI.Canvas.Views;

public partial class AssignGradeView : ContentPage
{
	public AssignGradeView()
	{
		InitializeComponent();
		BindingContext = new AssignGradeViewModel();
	}
}