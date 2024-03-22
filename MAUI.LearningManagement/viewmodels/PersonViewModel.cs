using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LMS.Models;
using LMS.Services;

namespace MAUI.LearningManagement.viewmodels
{
    class PersonViewModel : INotifyPropertyChanged
    {
        private PersonService personService;
        public event PropertyChangedEventHandler? PropertyChanged;

        //[CallerMemberName] = You're taking the name of the calling method/property for later use.
        //Then use it to trigger the event when the function is called
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Person> Persons 
        {
            get
            {
                //Explicit call to conversion constructor
                //NOTE: Use of "Students" and not "Persons"
                return new ObservableCollection<Person>(personService.Students);
            }
        }
        public Person? SelectedPerson
        {
            get; set;
        }
        public void AddPerson()
        {
            personService?.AddOrUpdate(new Person());

            //Changed property, must notify to ensure it is updated
            NotifyPropertyChanged(nameof(Persons));
        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Persons));
        }
        public void Remove()
        {
            personService.Remove(SelectedPerson);
            Refresh();
        }
        public PersonViewModel()
        {
            personService = PersonService.Current;
        }
    }
}
