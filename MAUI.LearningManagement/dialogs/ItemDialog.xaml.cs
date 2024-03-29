using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.dialogs;

[QueryProperty(nameof(courseCode), "courseCode")]
[QueryProperty(nameof(moduleName), "moduleName")]
public partial class ItemDialog : ContentPage
{
    public string courseCode { get; set; } //Matches Course.Code
    public string moduleName { get; set; } //Matches Module.Name
    public ItemDialog()
	{
		InitializeComponent();

	}
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ItemDialogViewModel(courseCode, moduleName);
    }
    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ItemDialogViewModel)?.AddItem();
        Shell.Current.GoToAsync($"//ViewItems?courseCode={courseCode}&moduleName={moduleName}");
    }
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ViewItems");
    }
}