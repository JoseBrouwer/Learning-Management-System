using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.views;

public partial class PersonView : ContentPage
{
	public PersonView()
	{
		InitializeComponent();
        BindingContext = new PersonViewModel();
	}

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        //PersonDetail is the PersonDialog page, route in AppShell.xaml
        Shell.Current.GoToAsync("//PersonDetail");

        //Example of type coercion using "as" --> Safe Type Conversion
        //(BindingContext as PersonViewModel)?.AddPerson();
    }
    private void UpdateClicked(object sender, EventArgs e)
    {
        var personId = (BindingContext as PersonViewModel)?.SelectedPerson?.IntId;

        if(personId != null)
        {
            Shell.Current.GoToAsync($"//PersonDetail?personId={personId}");
        }
        
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as PersonViewModel)?.Refresh();
    }

    private void RemoveClicked(object sender, EventArgs e)
    {
        (BindingContext as PersonViewModel)?.Remove();
    }
}