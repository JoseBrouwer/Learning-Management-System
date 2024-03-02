using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.views;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
		InitializeComponent();
        BindingContext = new InstructorViewModel();
	}

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PersonDetail");
        //Example of type coercion using "as" --> Safe Type Conversion
        //(BindingContext as PersonViewModel)?.AddPerson();
    }
}