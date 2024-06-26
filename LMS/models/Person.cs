using LMS.Services;

namespace LMS.Models {
    public class Person
    {
        
        public string? Name { get; set; }
        public enum Years
        {
            Freshman,
            Sophomore,
            Junior,
            Senior,
            Graduate
        }
        public Years? Classification { get; set; } //Freshman, Sophomore, etc...
        public double? Grades { get; set; }
        public List<Course>? Courses { get; set; }
        public Guid Id { get; set; }
        public int IntId { get; set; }

        public Person(string? name = "", Years? classification = 0, double? grades = 0)
        {
            Name = name;
            Classification = classification;
            Courses = new List<Course>();
            //Course newCourse = new Course { Code = "007", Name = "TEST", Description = "Testing..."};
            //CourseService.Current.Add(newCourse);
            //Courses.Add(newCourse);
            Grades = grades;
            Id = Guid.NewGuid();
            Console.WriteLine("Person Created");
        }
        public void ListStudentCourses() //Lists every Course in the Courses
        {
            if (Courses == null)
                return;
            else
            {
                /*Student Name
                 *  Number of Courses: x
                 *      Course 1
                 *      Course 2
                 *      Etc...*/
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"{Name}\n");
                Console.WriteLine($"\tNumber of Courses: {Courses.Count}");
                foreach (var course in Courses)
                {
                    Console.WriteLine($"\t\t{course}");
                }
                Console.WriteLine("------------------------------------------");
            }
        }
        public override string ToString()
        {
            return $"{Name}: {Classification} : {Grades} \n";
        }
    }
}