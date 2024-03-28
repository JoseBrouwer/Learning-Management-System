using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.dialogs;

[QueryProperty(nameof(courseCode), "courseCode")]
public partial class CourseModules : ContentPage
{
    public string courseCode { get; set; } //Matches Course.Cod
    public CourseModules()
	{
		InitializeComponent();
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseModulesViewModel(courseCode);
        (BindingContext as CourseModulesViewModel)?.Refresh();
    }
    private void AddModuleClicked(object sender, EventArgs e)
    {
        if(courseCode != null)
        {
            Shell.Current.GoToAsync($"//ModuleDetail?courseCode={courseCode}?");
        }
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
}