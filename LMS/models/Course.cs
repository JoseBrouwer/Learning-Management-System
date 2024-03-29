using LMS.Models;

namespace LMS.Models {
    public class Course
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Person>? Roster { get; set; }
        public List<Assignment>? Assignments { get; set; }
        public List<Module>? Modules { get; set; }
        public Guid PersonId { get; private set; }
        public Course(string? code = "", string? name = "", string? description = "")
        {
            Code = code;
            Name = name;
            Description = description;
            Roster = new List<Person>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
            //Modules.Add(new Module { Name = "TEST MODULE", Description = "Testing"});
            Console.WriteLine("Course Created");
        }
        public void AddPerson(Person person) //Adds a Person to the Roster
        {
            Roster?.Add(person);
        }
        public void RemovePerson(Person person) //Removes a Person from the Roster
        {
            Roster?.Remove(person);
        }
        public void ListPeople() //Lists every Person in the Roster
        {
            if (Roster == null)
                return;
            else
            {
                /*Course Title
                 *  Number of Students: x
                 *      Jose Brouwer
                 *      Alejandro Brouwer
                 *      Etc...*/
                Console.WriteLine($"{Name}\n");
                Console.WriteLine($"\tNumber of Students: {Roster.Count}");
                foreach (var student in Roster)
                {
                    Console.WriteLine($"\t\t{student}");
                }
            }
        }
        public override string ToString()
        {
            return $"\tCODE:{Code}\n\tNAME:{Name}\n\tDESCRIPTION:{Description}\n";
        }
    }
}