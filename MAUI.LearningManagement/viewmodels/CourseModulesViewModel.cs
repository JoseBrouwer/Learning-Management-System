using LMS.Models;
using LMS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.LearningManagement.viewmodels
{
    class CourseModulesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Course? course;
        public Module? SelectedModule
        {
            get; set;
        }
        public CourseModulesViewModel(string code)
        {
            if (code == string.Empty || code == null)
            {
                course = new Course();
            }
            else
            {
                course = CourseService.Current.Get(code) ?? new Course();
            }
        }
        public ObservableCollection<Module> Modules
        {
            get
            {
                return new ObservableCollection<Module>(course.Modules.ToList());
            }
        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Modules));
        }
    }
}
