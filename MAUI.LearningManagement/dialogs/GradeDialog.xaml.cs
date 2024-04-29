using LMS.models;
using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.dialogs;

[QueryProperty(nameof(courseCode), "courseCode")]
[QueryProperty(nameof(assignmentName), "assignmentName")]
[QueryProperty(nameof(submitterId), "submitterId")]
public partial class GradeDialog : ContentPage
{
    public string courseCode { get; set; }
    public string assignmentName { get; set; }
    public int submitterId { get; set; }
    public GradeDialog()
	{
		InitializeComponent();
        //BindingContext = new GradeDialogViewModel(submission, assignmentName);
	}
    private void OkClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//Submissions?courseCode={courseCode}&assignmentName={assignmentName}");
    }
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//Submissions?courseCode={courseCode}&assignmentName={assignmentName}");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new GradeDialogViewModel(courseCode, submitterId, assignmentName);
    }
}