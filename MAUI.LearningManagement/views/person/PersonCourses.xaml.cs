using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.views.person;

[QueryProperty(nameof(personId), "personId")]
public partial class PersonCourses : ContentPage
{
    public int personId { get; set; }
	public PersonCourses()
	{
		InitializeComponent();
	}
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new PersonCoursesViewModel(personId);
        (BindingContext as PersonCoursesViewModel)?.Refresh();
    }
    private void ModulesClicked(object sender, EventArgs e)
    {
        var courseCode = (BindingContext as PersonCoursesViewModel)?.SelectedCourse?.Code;
        if (courseCode != null) 
        {
            Shell.Current.GoToAsync($"//CourseModules?personId={personId}&courseCode={courseCode}");
        }
    }
    private void AssignmentsClicked(object sender, EventArgs e)
    {
        var courseCode = (BindingContext as PersonCoursesViewModel)?.SelectedCourse?.Code;
        if (courseCode != null)
        {
            Shell.Current.GoToAsync($"//CourseAssignments?personId={personId}&courseCode={courseCode}");
        }
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Person");
    }
    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as PersonCoursesViewModel)?.Refresh();
    }
}