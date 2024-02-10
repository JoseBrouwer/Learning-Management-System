using System;

namespace LMS.Models
{
    public class Assignment
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? TotalAvailablePoints { get; set; }
        public string? DueDate { get; set; }
        public Assignment(string? name, string? description, double? totalAvailablePoints, string? dueDate)
        {
            Name = name;
            Description = description;
            TotalAvailablePoints = totalAvailablePoints;
            DueDate = dueDate;
            Console.WriteLine("Assignment Created");
        }
    }
}