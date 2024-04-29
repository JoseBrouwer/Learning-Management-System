using LMS.models;
using LMS.Models;
using LMS.Services;
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
    public Submission submission { get; set; }
    public double? tempGrade { get; set; }
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
        submission.Grade = tempGrade;
        Shell.Current.GoToAsync($"//Submissions?courseCode={courseCode}&assignmentName={assignmentName}");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new GradeDialogViewModel(courseCode, submitterId, assignmentName);
        
        //I am storing the Grade before modification since I am changing it directly
        Course? course = CourseService.Current.Get(courseCode);
        Assignment? assignment = CourseService.Current.GetAssignment(course, assignmentName);
        submission = CourseService.Current.GetSubmission(assignment, submitterId);
        tempGrade = submission?.Grade;
    }
}