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
    internal class PersonViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Query { get; set; }
        public ObservableCollection<Person> Persons
        {
            get
            {
                //Explicit call to conversion constructor
                //NOTE: Use of "Students" and not "Persons"
                return new ObservableCollection<Person>(PersonService.Current.Students
                    .ToList().Where(s
                    => s?.Name?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false));
            }
        }
        public PersonViewModel() { }
        public Person? SelectedPerson
        {
            get; set;
        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Persons));
        }
    }
}
