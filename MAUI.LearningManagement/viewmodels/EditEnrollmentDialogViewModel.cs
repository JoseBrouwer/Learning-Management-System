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
    internal class EditEnrollmentDialogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        //[CallerMemberName] = You're taking the name of the calling method/property for later use.
        //Then use it to trigger the event when the function is called
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Course? course;
        public EditEnrollmentDialogViewModel(string code)
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
        public Person? SelectedStudent
        {
            get; set;
        }
        public ObservableCollection<Person> Roster
        {
            get
            {
                return new ObservableCollection<Person>(course.Roster.ToList());
                    //.ToList().Where(
                    //s => s?.Name?.ToUpper()?.Contains(Query?.ToUpper() ?? string.Empty) ?? false));
            }
        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Roster));
        }
        public void Remove()
        {
            CourseService.Current.RemovePersonFromRoster(course, SelectedStudent);
            PersonService.Current.DeleteCourse(SelectedStudent, course);
            Refresh();
        }
    }
}
