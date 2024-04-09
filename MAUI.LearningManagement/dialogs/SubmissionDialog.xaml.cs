using LMS.Models;

namespace MAUI.LearningManagement.dialogs;

[QueryProperty(nameof(personId), "personId")]
[QueryProperty(nameof(courseCode), "courseCode")]
[QueryProperty(nameof(assignmentName), "assignmentName")]
public partial class SubmissionDialog : ContentPage
{
    public int personId { get; set; }
    public string courseCode { get; set; }
    public string assignmentName { get; set; }
    public SubmissionDialog()
	{
		InitializeComponent();
	}

    private void SubmitClicked(object sender, EventArgs e)
    {
        //ADD SUBMISSION IN PERSONSERVICE
        Shell.Current.GoToAsync($"//CourseAssignments?personId={personId}&courseCode={courseCode}");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//CourseAssignments?personId={personId}&courseCode={courseCode}");
    }
}