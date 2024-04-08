namespace MAUI.LearningManagement
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void PersonViewClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Person");
        }
        private void CreatePersonClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//CreatePerson");
        }
        private void InstructorViewClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Instructor");
        }
    }
}
