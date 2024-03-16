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
        //need to implement AddPerson method in PersonDetailViewViewModel
        //this line is causing an error -> likely because Name is not set on the PersonDetailViewViewModel
        (BindingContext as PersonDetailViewViewModel).AddPerson();
    }

    private void CancelClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
}