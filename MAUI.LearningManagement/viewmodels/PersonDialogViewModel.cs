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
    public class PersonDialogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        //[CallerMemberName] = You're taking the name of the calling method/property for later use.
        //Then use it to trigger the event when the function is called
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Person? person;
        public string Name
        {
            get { return person?.Name ?? string.Empty; }
            //value keyword, when R-value = getter, when L-value = setter
            set { 
                if(person == null)
                    person = new Person();
                person.Name = value; 
            }
        }
        private string? year;
        public string Year
        {
            get { 
                if(year == null)
                    year = string.Empty;
                return year; 
            }
            set
            {
                year = value;
                NotifyPropertyChanged(nameof(Year)); // Notify the UI of change
            }
            //get { return person?.Classification.ToString() ?? string.Empty; }
            //set {
            //    if (person == null)
            //        person = new Person();
            //    if (Enum.TryParse<Person.Years>(value, out var result))
            //    {
            //        Year = result; // This sets the underlying enum property.
            //    }; 
            }
        
        public double Grades
        {
            get { return person?.Grades ?? 0; }
            set {
                if (person == null)
                    person = new Person();
                person.Grades = value; 
            }
        }
        public PersonDialogViewModel()
        {
            person = new Person();
        }
        public void AddPerson()
        {
            if(person != null)
            {
                if (Enum.TryParse<Person.Years>(year, true, out var result))
                {
                    person.Classification = result;
                }
                else
                    person.Classification = 0;
                PersonService.Current.AddOrUpdate(person);
            }
        }
    }
}
