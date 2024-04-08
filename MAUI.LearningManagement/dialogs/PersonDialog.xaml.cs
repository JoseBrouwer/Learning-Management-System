using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.dialogs;

[QueryProperty(nameof(PersonId), "personId")]
public partial class PersonDialog : ContentPage
{
    public int PersonId { get; set; } //Matches Person.IntId
	public PersonDialog()
	{
		InitializeComponent();
		BindingContext = new PersonDialogViewModel(0);
	}
    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as PersonDialogViewModel)?.AddPerson();
        Shell.Current.GoToAsync("//CreatePerson");
    }
    private void CancelClicked(object sender, EventArgs e)
    {
		//return to PersonDialog.xaml
		Shell.Current.GoToAsync("//CreatePerson");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new PersonDialogViewModel(PersonId);
    }
}