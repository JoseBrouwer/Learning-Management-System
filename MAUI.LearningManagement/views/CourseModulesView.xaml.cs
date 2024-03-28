using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.views;

[QueryProperty(nameof(courseCode), "courseCode")]
public partial class CourseModulesView : ContentPage
{
    public string courseCode { get; set; } //Matches Course.Cod
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
            Shell.Current.GoToAsync($"//ModuleDetail?courseCode={courseCode}?");
        }
    }
    private void RemoveModuleClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseModulesViewModel)?.Remove();
    }
    private void ViewItemsClicked(object sender, EventArgs e)
    {
        if(courseCode != null)
        {
            Shell.Current.GoToAsync($"//ViewItems?courseCode={courseCode}?");
        }
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
}