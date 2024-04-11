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
    internal class AssignmentDialogViewModel
    { 
        private Course? course;
        private Assignment? assignment;

        public string Name
        {
            get { return assignment?.Name ?? string.Empty; }
            set
            {
                if (assignment == null)
                {
                    assignment = new Assignment();
                }
                else
                    assignment.Name = value;
            }
        }
        private string pointsInput; // This holds the raw string input from the user
        public string Description
        {
            get { return assignment?.Description ?? string.Empty; }
            set
            {
                if (assignment == null)
                    assignment = new Assignment();
                assignment.Description = value;
            }
        }
        public string Points
        {
            get { return pointsInput; }
            set
            {
                pointsInput = value;
                // Attempt to parse the input string to a double
                if (double.TryParse(pointsInput, out double parsedPoints))
                {
                    // If parsing is successful, set the parsed value to your Points property
                    assignment.TotalAvailablePoints = parsedPoints;
                }
                //else
                //{
                //    assignment.TotalAvailablePoints = 0.00;
                //}
            }
        }
        public string DueDate
        {
            get { return assignment?.DueDate ?? string.Empty; }
            set
            {
                if (assignment == null)
                    assignment = new Assignment();
                assignment.DueDate = value;
            }
        }

        public AssignmentDialogViewModel(string code, string name) 
        {
            if (code == string.Empty || code == null)
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
        public void AddAssignment()
        {
            if (assignment != null)
            {
                CourseService.Current.AddOrUpdateAssignment(course, assignment);
            }
        }
    }
}
