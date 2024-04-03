namespace MAUI.Canvas.Views;
using MAUI.Canvas.ViewModels;
using Library.Canvas.Models;

public partial class AddModuleView : ContentPage
{
	public AddModuleView()
	{
		InitializeComponent();
		BindingContext = new AddModuleViewViewModel();
	}

    private void AddClicked(object sender, EventArgs e)
    {
		Module m = new Module();
		(BindingContext as AddModuleViewViewModel)?.AddModuleToCourse(m);
		Shell.Current.GoToAsync("//LinkStudent");
    }
}