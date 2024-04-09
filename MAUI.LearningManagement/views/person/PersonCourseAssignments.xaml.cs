using LMS.Models;
using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.views.person;

[QueryProperty(nameof(personId), "personId")]
[QueryProperty(nameof(courseCode), "courseCode")]
public partial class PersonCourseAssignments : ContentPage
{
    public int personId { get; set; }
    public string courseCode { get; set; }
    public PersonCourseAssignments()
	{
		InitializeComponent();
	}
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new PersonCourseAssignmentsViewModel(courseCode);
        (BindingContext as PersonCourseAssignmentsViewModel)?.Refresh();
    }
    private void StartClicked(object sender, EventArgs e)
    {
        var assignmentName = (BindingContext as PersonCourseAssignmentsViewModel)?.SelectedAssignment?.Name;
        if(assignmentName != null)
        {
            Shell.Current.GoToAsync($"//SubmissionDetail?personId={personId}&courseCode={courseCode}&assignmentName={assignmentName}");
        }
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//PersonCourses?personId={personId}");
    }
}