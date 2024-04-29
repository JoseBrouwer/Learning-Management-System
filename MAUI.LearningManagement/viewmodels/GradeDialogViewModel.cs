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
    internal class GradeDialogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Assignment? assignment;
        private Submission? submission;
        public double Grade
        {
            get { return submission?.Grade ?? 0; }
            set { 
                if (submission != null)
                {
                    if((value > -1) && (value < assignment?.TotalAvailablePoints))
                        submission.Grade = value;
                    else if(value < -1)
                    {
                        submission.Grade = 0;
                    }
                    else
                    {
                        submission.Grade = assignment?.TotalAvailablePoints;
                    }
                }
            }
        }
        public GradeDialogViewModel(string code, int submitterId, string assignmentName) 
        {
            if (submitterId == 0)
                submission = new Submission();
            else
            {
                Course? course = CourseService.Current.Get(code);
                assignment = CourseService.Current.GetAssignment(course, assignmentName);
                submission = CourseService.Current.GetSubmission(assignment, submitterId);
            }
        }
    }
}
