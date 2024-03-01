using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Models;
using LMS.Services;

namespace MAUI.LearningManagement.viewmodels
{
    class PersonViewModel
    {
        private PersonService personService;
        public ObservableCollection<Person> Persons 
        {
            get
            {
                //Explicit call to conversion constructor
                //NOTE: Use of "Students" and not "Persons"
                return new ObservableCollection<Person>(personService.Students);
            }
        }
        public PersonViewModel()
        {
            personService = PersonService.Current;
        }
    }
}
