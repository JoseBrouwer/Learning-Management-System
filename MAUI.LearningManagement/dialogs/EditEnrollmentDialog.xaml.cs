using LMS.Models;
using LMS.Services;
using MAUI.LearningManagement.viewmodels;
using System.Collections.ObjectModel;

namespace MAUI.LearningManagement.dialogs;

[QueryProperty(nameof(courseCode), "courseCode")]
public partial class EditEnrollmentDialog : ContentPage
{
    public string courseCode { get; set; } //Matches Course.Code
    public EditEnrollmentDialog()
	{
		InitializeComponent();
        //BindingContext = new EditEnrollmentDialogViewModel(courseCode);
	}
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EditEnrollmentDialogViewModel(courseCode);
        (BindingContext as EditEnrollmentDialogViewModel)?.Refresh();
    }
    private void AddStudentClicked(object sender, EventArgs e)
    {
        if (courseCode != null)
        {
            Shell.Current.GoToAsync($"//AddEnrollment?courseCode={courseCode}");
        }
    }
    private void RemoveStudentClicked(object sender, EventArgs e)
    {
        (BindingContext as EditEnrollmentDialogViewModel)?.Remove();
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }
}