using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.models
{
    public class Submission
    {
        public string? Text {  get; set; }
        public int? Id { get; set; } //SET TO ID OF PERSON SUBMITTING
        public double? Grade {  get; set; } //FOR INSTRUCTOR TO ASSIGN
        public Submission(string? text="", int? id = 0, double? grade=0) 
        {
            Text = text;
            Id = id;
        }
        public override string ToString()
        {
            return $"\tID of submitter: {Id}\n\tTEXT: {Text}\n\tGRADE: {Grade}";
        }
    }
}
