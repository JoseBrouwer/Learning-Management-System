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
    internal class CourseDialogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Course? course;
        public string Code
        {
            get { return course?.Code ?? string.Empty; }
            set
            {
                if(course == null)
                {
                    course = new Course();
                }
                else
                    course.Code = value;
            }
        }
        public string Name
        {
            get { return course?.Name ?? string.Empty; }
            //value keyword, when R-value = getter, when L-value = setter
            set
            {
                if (course == null)
                    course = new Course();
                course.Name = value;
            }
        }
        public string Description
        {
            get { return course?.Description ?? string.Empty; }
            set
            {
                if (course == null)
                    course = new Course();
                course.Description = value;
            }
        }
        public void AddCourse()
        {
            if (course != null)
            {
                CourseService.Current.AddOrUpdate(course);
            }
        }
        public CourseDialogViewModel(string code) 
        {
            if(code == string.Empty || code == null)
            {
                course = new Course();
            }
            else
            {
                course = CourseService.Current.Get(code) ?? new Course();
            }
        }
    }
}
