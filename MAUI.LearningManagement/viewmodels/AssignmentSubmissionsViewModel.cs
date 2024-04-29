using LMS.models;
using LMS.Models;
using LMS.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MAUI.LearningManagement.viewmodels
{
    internal class AssignmentSubmissionsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Course? course;
        private Assignment? assignment;
        public Submission? SelectedSubmission
        { 
            get; set; 
        }
        public AssignmentSubmissionsViewModel(string code, string name)
        {
            if (code == string.Empty || code == null
                || name == string.Empty || name == null)
            {
                course = new Course();
                assignment = new Assignment();
            }
            else
            {
                course = CourseService.Current.Get(code) ?? new Course();
                assignment = CourseService.Current.GetAssignment(course, name);
            }
        }
        public ObservableCollection<Submission> Submissions
        {
            get
            {
                return new ObservableCollection<Submission>(assignment.Submissions.ToList());
            }
        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Submissions));
        }
    }
}
