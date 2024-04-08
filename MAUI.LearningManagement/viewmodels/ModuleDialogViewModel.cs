using LMS.Models;
using LMS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.LearningManagement.viewmodels
{
    class ModuleDialogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        private Course? course;
        private Module? module;

        public string Name
        {
            get { return module?.Name ?? string.Empty; }
            set
            {
                if(module == null)
                {
                    module = new Module();
                }
                else
                    module.Name = value;
            }
        }
        public string Description
        {
            get { return module?.Description ?? string.Empty; }
            set
            {
                if (module == null)
                    module = new Module();
                module.Description = value;
            }
        }

        public ModuleDialogViewModel(string code)
        {
            if (code == string.Empty || code == null)
            {
                course = new Course();
                module = new Module();
            }
            else
            {
                course = CourseService.Current.Get(code) ?? new Course();
                module = new Module();
            }
        }
        public void AddModule()
        {
            if(module != null)
            {
                CourseService.Current.AddOrUpdateModule(course, module);
            }
        }
    }
}
