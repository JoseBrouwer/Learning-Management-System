using MAUI.LearningManagement.viewmodels;

namespace MAUI.LearningManagement.views;

[QueryProperty(nameof(courseCode), "courseCode")]
[QueryProperty(nameof(moduleName), "moduleName")]
public partial class ModuleItemsView : ContentPage
{
    public string courseCode { get; set; } //Matches Course.Code
    public string moduleName { get; set; } //Matches Module.Name
    public ModuleItemsView()
	{
		InitializeComponent();
	}
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ModuleItemsViewModel(courseCode, moduleName);
        (BindingContext as ModuleItemsViewModel)?.Refresh();
    }
    private void AddItemClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ItemDetail?courseCode={courseCode}&moduleName={moduleName}");
    }
    private void UpdateItemClicked(object sender, EventArgs e)
    {
    }
    private void RemoveItemClicked(object sender, EventArgs e)
    {
    }
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//ViewModules?courseCode={courseCode}");
    }
}