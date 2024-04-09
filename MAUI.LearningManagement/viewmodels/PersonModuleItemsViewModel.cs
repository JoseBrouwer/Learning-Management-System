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
    internal class PersonModuleItemsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Course? course;
        private Module? module;
        public PersonModuleItemsViewModel(string code, string moduleName)
        {
            if (code == string.Empty || code == null
                || moduleName == string.Empty || moduleName == null)
            {
                course = new Course();
                module = new Module();
            }
            else
            {
                course = CourseService.Current.Get(code) ?? new Course();
                module = course?.Modules?.Where(m => m.Name == moduleName).FirstOrDefault();
            }
        }
        public ObservableCollection<Item> Items
        {
            get
            {
                return new ObservableCollection<Item>(module.Items.ToList());
            }
        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Items));
        }
    }
}
