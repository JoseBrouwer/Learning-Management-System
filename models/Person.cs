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
        public Guid Id { get; }
        public Guid PersonId { get; private set; }

        public Person(string? name, Years? classification, double? grades)
        {
            Name = name;
            Classification = classification;
            Courses = new List<Course>();
            Grades = grades;
            Console.WriteLine("Person Created");
            Grades = grades;
            PersonId = Guid.NewGuid();
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
            return $"{Name}: {Classification} \n";
        }
    }
}