using MAUI.Canvas.ViewModels;

namespace MAUI.Canvas.Views;

public partial class LinkStudentView : ContentPage
{
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
        (BindingContext as LinkStudentViewViewModel).OkClick(Shell.Current);
    }
    

}