using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.views;

[QueryProperty(nameof(courseCode), "courseCode")]
public partial class CourseModulesView : ContentPage
{
    public string courseCode { get; set; } //Matches Course.Code
    public CourseModulesView()
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
            Shell.Current.GoToAsync($"//ModuleDetail?courseCode={courseCode}");
        }
    }
    private void RemoveModuleClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseModulesViewModel)?.Remove();
    }
    private void ViewItemsClicked(object sender, EventArgs e)
    {
        var moduleName = (BindingContext as CourseModulesViewModel)?.SelectedModule?.Name;
        if(moduleName != null)
        {
            //NOTE the use of '&' for multiple parameters
            Shell.Current.GoToAsync($"//ViewItems?courseCode={courseCode}&moduleName={moduleName}");
        }
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseModulesViewModel)?.Refresh();
    }
}