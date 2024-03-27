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
    internal class AddEnrollmentDialogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        //[CallerMemberName] = You're taking the name of the calling method/property for later use.
        //Then use it to trigger the event when the function is called
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Course? course;
        public AddEnrollmentDialogViewModel(string code)
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
        public Person? SelectedPerson
        {
            get; set;
        }

        private Person? person;
        public void AddEnrollment(int pId)
        {
            if (pId == 0)
            {
                person = new Person();
            }
            else
            {
                person = PersonService.Current.Get(pId) ?? new Person();
            }
            //Add selected person to the Roster
            if(!CourseService.Current.IsPersonInRoster(course, person))
            {
                course?.AddPerson(person);
            }
        }
    }
}
