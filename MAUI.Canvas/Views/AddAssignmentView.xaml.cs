namespace MAUI.Canvas.Views;

public partial class AddAssignmentView : ContentPage
{
	public AddAssignmentView()
	{
		InitializeComponent();
	}
	private void CancelClicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("//LinkStudent");
    }
   /* private void AddAssignmentClicked(object sender, EventArgs e)
	{
        (BindingContext as AddAssignmentViewModel)?.AddAssignmentClick(Shell.Current);
    }*/
}