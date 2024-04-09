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
    internal class PersonCoursesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Person? person;
        public string Query { get; set; }
        public Course? SelectedCourse
        {
            get; set;
        }
        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(person.Courses.ToList());
            }
        }
        public PersonCoursesViewModel(int Id)
        {
            if (Id < 0)
            {
                person = new Person();
            }
            else
            {
                person = PersonService.Current.Get(Id);
            }
        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Courses));
        }
    }
    
}
