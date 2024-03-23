using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.dialogs;

public partial class CourseDialog : ContentPage
{
	public CourseDialog()
	{
		InitializeComponent();
        BindingContext = new CourseDialogViewModel();
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new CourseDialogViewModel();
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