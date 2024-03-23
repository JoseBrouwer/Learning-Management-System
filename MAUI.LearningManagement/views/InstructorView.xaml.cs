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
    private void SearchClicked(object sender, EventArgs e)
    {
        //Refresh() updates all properties of the View
        (BindingContext as InstructorViewModel)?.Refresh();
    }
}