namespace MAUI.Canvas.Views;

public partial class AddModuleView : ContentPage
{
	public AddModuleView()
	{
		InitializeComponent();
	}

    private void AddClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//LinkStudent");
    }
}