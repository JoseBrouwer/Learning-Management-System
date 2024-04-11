using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.dialogs;

[QueryProperty(nameof(courseCode), "courseCode")]
public partial class AddEnrollmentDialog : ContentPage
{
    public string courseCode { get; set; } //Matches Course.Code
    public AddEnrollmentDialog()
	{
		InitializeComponent();
		BindingContext = new AddEnrollmentDialogViewModel(courseCode);
	}
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AddEnrollmentDialogViewModel(courseCode);
    }
    private void AddClicked(object sender, EventArgs e)
    {
        var personId = (BindingContext as AddEnrollmentDialogViewModel)?.SelectedPerson?.IntId;
        (BindingContext as AddEnrollmentDialogViewModel)?.AddEnrollment((int)personId);
        Shell.Current.GoToAsync($"//EditEnrollment?courseCode={courseCode}");
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//EditEnrollment?courseCode={courseCode}");
    }
}