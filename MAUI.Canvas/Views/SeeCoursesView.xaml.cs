using MAUI.Canvas.ViewModels;
namespace MAUI.Canvas.Views;

[QueryProperty(nameof(studentId), "studentId")]
public partial class SeeCoursesView : ContentPage
{
	public int studentId
	{
        set; get;
    }
	public SeeCoursesView()
	{
		InitializeComponent();
		BindingContext = new SeeCoursesViewModel(studentId);
	}
	private void CancelClicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("//Student");
    }
}