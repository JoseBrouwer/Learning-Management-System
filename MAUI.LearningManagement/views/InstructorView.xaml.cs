using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.views;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
		InitializeComponent();
        BindingContext = new InstructorViewModel();
	}
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InstructorViewModel)?.Refresh();
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    private void AddCourseClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CourseDetail");
    }
    private void AddStudentClicked(object sender, EventArgs e)
    {
       // Shell.Current.GoToAsync("//AddingStudent");
    }
    private void ViewModulesClicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync("//ModuleDetail");
    }
    private void ViewAssignmentsClicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync("//AssignmentDetail");
    }
    private void UpdateClicked(object sender, EventArgs e)
    {
        //Shell.Current.GoToAsync("//CourseDetail");
    }
    private void RemoveClicked(object sender, EventArgs e)
    {
       
    }
    private void SearchClicked(object sender, EventArgs e)
    {
        //Refresh() updates all properties of the View
        (BindingContext as InstructorViewModel)?.Refresh();
    }
}