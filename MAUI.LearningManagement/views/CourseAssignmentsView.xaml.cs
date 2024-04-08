using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.views;

[QueryProperty(nameof(courseCode), "courseCode")]
public partial class CourseAssignmentsView : ContentPage
{
    public string courseCode { get; set; } //Matches Course.Code

    public CourseAssignmentsView()
	{
        InitializeComponent();
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseAssignmentsViewModel(courseCode);
        (BindingContext as CourseAssignmentsViewModel)?.Refresh();
    }
    private void AddClicked(object sender, EventArgs e)
    {
        if(courseCode != null)
        {
            Shell.Current.GoToAsync($"//AssignmentDetail?courseCode={courseCode}");
        }
    }
    private void UpdateClicked(object sender, EventArgs e)
    {
        
    }
    private void RemoveClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseAssignmentsViewModel)?.Remove();
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
}