using LMS.Models;
using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.dialogs;

[QueryProperty(nameof(courseCode), "courseCode")]

public partial class CourseDialog : ContentPage
{
    public string courseCode { get; set; } //Matches Course.Code
	public CourseDialog()
	{
		InitializeComponent();
        BindingContext = new CourseDialogViewModel(courseCode);
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseDialogViewModel(courseCode);
    }
    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDialogViewModel)?.AddCourse();
        Shell.Current.GoToAsync("//Instructor");
    }
    private void CancelClicked(object sender, EventArgs e)
    {
        //return to PersonDialog.xaml
        Shell.Current.GoToAsync("//Instructor");
    }
}