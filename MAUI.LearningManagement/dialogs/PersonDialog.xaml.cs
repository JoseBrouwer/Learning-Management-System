using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.dialogs;

public partial class PersonDialog : ContentPage
{
	public PersonDialog()
	{
		InitializeComponent();
		BindingContext = new PersonDialogViewModel();
	}
    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as PersonDialogViewModel)?.AddPerson();
        Shell.Current.GoToAsync("//Person");
    }
    private void CancelClicked(object sender, EventArgs e)
    {
		//return to PersonDialog.xaml
		Shell.Current.GoToAsync("//Person");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new PersonDialogViewModel();
    }
}