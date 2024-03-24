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
    class InstructorViewModel: INotifyPropertyChanged
    {
        private PersonService personService;
        private CourseService courseService;
        public event PropertyChangedEventHandler? PropertyChanged;

        //[CallerMemberName] = You're taking the name of the calling method/property for later use.
        //Then use it to trigger the event when the function is called
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Query { get; set; }
        public Course? SelectedCourse
        {
            get; set;
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
        public ObservableCollection<Course> Courses
        {
            get
            {
                //Explicit call to conversion constructor
                //NOTE: Use of "Students" and not "Persons"
                return new ObservableCollection<Course>(courseService.Courses //MAKE NULL PROOF
                    .ToList().Where(c =>
                        c.Name.ToUpper().Contains(Query ?? string.Empty)
                        || c.Code.ToUpper().Contains(Query ?? string.Empty)
                        || c.Description.ToUpper().Contains(Query ?? string.Empty)));
            }
        }
        //public void AddCourse()
        //{
        //    courseService?.AddOrUpdate(new Course());

        //    //Changed property, must notify to ensure it is updated
        //    NotifyPropertyChanged(nameof(Courses));
        //}
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Courses));
        }
        public void Remove()
        {
            courseService.Remove(SelectedCourse);
            Refresh();
        }
        public InstructorViewModel()
        {
            personService = PersonService.Current;
            courseService = CourseService.Current;
        }
    }
}
