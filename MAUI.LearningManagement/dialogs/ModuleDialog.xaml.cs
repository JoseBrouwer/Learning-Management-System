using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.dialogs;

[QueryProperty(nameof(courseCode), "courseCode")]
public partial class ModuleDialog : ContentPage
{
    public string courseCode { get; set; } //Matches Course.Code
    public ModuleDialog()
	{
		InitializeComponent();
        BindingContext = new ModuleDialogViewModel(courseCode);
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ModuleDialogViewModel(courseCode);
    }
    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ModuleDialogViewModel)?.AddModule();
        Shell.Current.GoToAsync("//Instructor");
    }
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
}