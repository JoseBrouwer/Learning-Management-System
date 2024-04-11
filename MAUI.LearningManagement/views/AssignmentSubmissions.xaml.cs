using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.views;

[QueryProperty(nameof(courseCode), "courseCode")]
[QueryProperty(nameof(assignmentName), "assignmentName")]
public partial class AssignmentSubmissions : ContentPage
{
    public string courseCode { get; set; }
    public string assignmentName { get; set; }
    public AssignmentSubmissions()
	{
        InitializeComponent();
	}
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AssignmentSubmissionsViewModel(courseCode, assignmentName);
        (BindingContext as AssignmentSubmissionsViewModel)?.Refresh();
    }
    private void GradeClicked(object sender, EventArgs e)
    {
        //IMPLEMENT
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ViewAssignments?courseCode={courseCode}");
    }
}