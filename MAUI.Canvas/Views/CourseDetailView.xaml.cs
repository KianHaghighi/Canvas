using MAUI.Canvas.ViewModels;
namespace MAUI.Canvas.Views;

public partial class CourseDetailView : ContentPage
{
	public CourseDetailView()
	{
		InitializeComponent();
		BindingContext = new CourseDetailViewViewModel();
	}
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailViewViewModel).AddCourse();
        Shell.Current.GoToAsync("//Instructor");
    }
    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseDetailViewViewModel();
    }
}