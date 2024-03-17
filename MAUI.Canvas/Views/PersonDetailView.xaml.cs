using MAUI.Canvas.ViewModels;
namespace MAUI.Canvas.Views;

public partial class PersonDetailView : ContentPage
{
	public PersonDetailView()
	{
		InitializeComponent();
        BindingContext = new PersonDetailViewViewModel();
    }
    public int PersonId
    {
        set; get;
    }

    private void OkClick(object sender, EventArgs e)
    {
        (BindingContext as PersonDetailViewViewModel).AddPerson();
    }

    private void CancelClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
}