using MAUI.Canvas.ViewModels;
namespace MAUI.Canvas.Views;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
		InitializeComponent();
		BindingContext = new InstructorViewViewModel();
	}
	private void CancelClicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("//MainPage");
    }
	private void AddEnrollmentClicked(object sender, EventArgs e)
	{
		(BindingContext as InstructorViewViewModel)?.AddEnrollmentClick(Shell.Current);
    }
    private void EditEnrollmentClicked(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).EditEnrollmentClicked(Shell.Current);
    }
    private void RemoveEnrollmentClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).RemoveEnrollmentClick();
    }
    private void AddCourseClicked(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).AddCourseClick(Shell.Current);
    }
    private void LinkStudentClicked(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).LinkStudentClick(Shell.Current);
    }
    private void ViewModulesClicked(object sender, EventArgs e)
    {
        /*var courseCode = (BindingContext as InstructorViewViewModel)?.SelectedCourse?.Code;
        if (courseCode != null)
        {
            Shell.Current.GoToAsync($"//ViewModules?courseCode={courseCode}");
        }*/
        (BindingContext as InstructorViewViewModel).ViewModulesClick(Shell.Current);
    }
    private void AssignGradeClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AssignGradeView");
    }   
}