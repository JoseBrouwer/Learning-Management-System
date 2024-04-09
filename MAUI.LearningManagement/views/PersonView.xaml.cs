using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.views;

public partial class PersonView : ContentPage
{
	public PersonView()
	{
		InitializeComponent();
        BindingContext = new PersonViewModel();
	}

    private void CoursesClicked(object sender, EventArgs e)
    {
        var personId = (BindingContext as PersonViewModel)?.SelectedPerson?.IntId;
        Shell.Current.GoToAsync($"//PersonCourses?personId={personId}");
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as PersonViewModel)?.Refresh();
    }
    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as PersonViewModel)?.Refresh();
    }
}