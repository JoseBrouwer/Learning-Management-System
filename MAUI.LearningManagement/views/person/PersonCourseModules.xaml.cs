using LMS.Models;
using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.views.person;

[QueryProperty(nameof(personId), "personId")]
[QueryProperty(nameof(courseCode), "courseCode")]
public partial class PersonCourseModules : ContentPage
{
    public int personId { get; set; }
    public string courseCode { get; set; }
    public PersonCourseModules()
	{
		InitializeComponent();
	}
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new PersonCourseModulesViewModel(courseCode);
        (BindingContext as PersonCourseModulesViewModel)?.Refresh();
    }
    private void ItemsClicked(object sender, EventArgs e)
    {

    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//PersonCourses?personId={personId}");
    }
}