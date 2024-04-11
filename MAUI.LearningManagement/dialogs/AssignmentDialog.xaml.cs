using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.dialogs;

[QueryProperty(nameof(courseCode), "courseCode")]
[QueryProperty(nameof(assignmentName), "assignmentName")]
public partial class AssignmentDialog : ContentPage
{
    public string courseCode { get; set; } //Matches Course.Code
    public string assignmentName { get; set; }
    public AssignmentDialog()
	{
		InitializeComponent();
        //BindingContext = new AssignmentDialogViewModel(courseCode, assignmentName);
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AssignmentDialogViewModel(courseCode, assignmentName);
    }
    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as AssignmentDialogViewModel)?.AddAssignment();
        Shell.Current.GoToAsync($"//ViewAssignments?courseCode={courseCode}");
    }
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ViewAssignments?courseCode={courseCode}");
    }
}