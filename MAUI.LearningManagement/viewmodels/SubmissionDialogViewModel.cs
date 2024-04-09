using LMS.models;
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
    class SubmissionDialogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Course? course;
        private Person? person;
        private Assignment? assignment;
        private Submission? submission;

        public string Text
        {
            get { return submission?.Text; }
            set
            {
                if(submission != null)
                {
                    submission.Text = value;
                }
            }
        }
        public SubmissionDialogViewModel(int personId, string code, string name)
        {
            if (personId < 0 || code == string.Empty || code == null 
                || name == string.Empty || name == null)
            {
                course = new Course();
                person = new Person();
                submission = new Submission();
            }
            else
            {
                course = CourseService.Current.Get(code) ?? new Course();
                person = PersonService.Current.Get(personId);
                assignment = CourseService.Current.GetAssignment(course, name);
                submission = new Submission("", personId);
            }
        }
        public void Submit()
        {
            if(assignment != null && submission != null && person != null)
            {
                PersonService.Current.SubmitAssignment(assignment, submission, person.IntId);
            }
        }
    }
}
