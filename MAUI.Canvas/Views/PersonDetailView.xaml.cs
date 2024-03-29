using MAUI.Canvas.ViewModels;
namespace MAUI.Canvas.Views;

//line added from Mills' vid about Editing Student Enrollments
[QueryProperty(nameof(PersonId), "personId")]
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
        //consider adding a breakpoint here to see if the binding context is null
        //F and Kian is being added to the database properly
        (BindingContext as PersonDetailViewViewModel).AddPerson();
        Shell.Current.GoToAsync("//Instructor");
    }

    private void CancelClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
    private void RemoveEnrollmentClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).RemoveEnrollmentClick();
    }
    //added in attempt to see the people that have already been enrolled
    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new PersonDetailViewViewModel(PersonId);
    }
}