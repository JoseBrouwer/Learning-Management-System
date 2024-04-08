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
    internal class CourseAssignmentsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        //[CallerMemberName] = You're taking the name of the calling method/property for later use.
        //Then use it to trigger the event when the function is called
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Course? course;
        public Assignment? SelectedAssignment
        {
            get; set;
        }
        public CourseAssignmentsViewModel(string code)
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
        public ObservableCollection<Assignment> Assignments
        {
            get
            {
                return new ObservableCollection<Assignment>(course.Assignments.ToList());
            }
        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Assignments));
        }
        public void Remove()
        {
            CourseService.Current.RemoveAssignment(course, SelectedAssignment);
            Refresh();
        }
    }
}
