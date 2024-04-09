using LMS.Models;
using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.views.person;

[QueryProperty(nameof(personId), "personId")]
[QueryProperty(nameof(courseCode), "courseCode")]
[QueryProperty(nameof(moduleName), "moduleName")]
public partial class PersonModuleItems : ContentPage
{
    public int personId { get; set; }
    public string courseCode { get; set; }
    public string moduleName { get; set; }
    public PersonModuleItems()
	{
		InitializeComponent();
	}
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ModuleItemsViewModel(courseCode, moduleName);
        (BindingContext as ModuleItemsViewModel)?.Refresh();
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//CourseModules?personId={personId}&courseCode={courseCode}");
    }
}