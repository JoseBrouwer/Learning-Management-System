using LMS.models;
using LMS.Models;

namespace LMS.Services {
    public class PersonService {

        private IList<Person> students;
        private IList<Course> courses;
        private int LastId //returns last id value assigned
        {
            get
            {
                //Basically a SQL SELECT on "students" and we return the Max value
                return students.Select(s => s.IntId).Max();
            }
        }
        private string? query;
        private static object _lock = new object();
        private static PersonService? instance;
        
        public static PersonService Current {
            get
            {
                if (instance == null)
                {
                    instance = new PersonService();
                }
                return instance;
            }
        }
        public IEnumerable<Person> Students
        {
            get
            {
                return students.Where(
                    s =>
                        s.Name.ToUpper().Contains(query ?? string.Empty)
                        || s.Id.ToString() == (query ?? string.Empty));
            }
        }
        private PersonService()
        {
            students = new List<Person>
            {
                new Person{Name = "TestPerson 1", Classification = (Person.Years?)0, Grades = 100, IntId = 1},
                new Person{Name = "TestPerson 2", Classification = (Person.Years?)1, Grades = 100, IntId = 2},
                new Person{Name = "TestPerson 3", Classification = (Person.Years?)2, Grades = 100, IntId = 3},
                new Person{Name = "TestPerson 4", Classification = (Person.Years?)3, Grades = 100, IntId = 4},
                new Person{Name = "TestPerson 5", Classification = (Person.Years?)4, Grades = 100, IntId = 5},
            };
            courses = new List<Course>();
        }
        public Person? Get(int id)
        {
            return students.FirstOrDefault(p => p.IntId == id);
        }
        public IEnumerable<Person> Search(string query)
        {
            this.query = query;
            return Students;
        }
        public void AddOrUpdate(Person student)
        {
            if(student.IntId == 0)
            {
                //cant use ++ because LastId doesn't have a set
                student.IntId = LastId + 1;

                //ONLY doesn't create a dupe bc its a local app
                //CHANGE WHEN IMPLEMENTING SERVICES
                students.Add(student);
            }
        }
        //Kept for the sake of not breaking Console App
        public void Add(Person student)
        {
            students.Add(student);
        }
        public void AddCourse(Course course, Person person)
        {
            person?.Courses?.Add(course);
        }
        public void Remove(Person student)
        {
            students.Remove(student);
        }
        public void Delete(Person studentToDelete)
        {
            students.Remove(studentToDelete);
        }
        public void DeleteCourse(Person student, Course courseToDelete)
        {
            student?.Courses?.Remove(courseToDelete);
        }
        public bool IsFirstSubmission(Assignment assignment, Submission submission, int personId)
        {
            foreach(Submission sub in assignment.Submissions)
            {
                //Has this user submitted something for this assignment?
                if(sub.Id == personId)
                {
                    return false;
                }
            }
            return true;
        }
        public void SubmitAssignment(Assignment assignment, Submission submission, int personId)
        {
            if(IsFirstSubmission(assignment, submission, personId))
                assignment.Submissions?.Add(submission);
            else
            {
                // Find the existing submission for the personId
                var existingSubmission = assignment.Submissions?.FirstOrDefault(s => s.Id == personId);

                // If found, remove the existing submission
                if (existingSubmission != null)
                {
                    assignment.Submissions?.Remove(existingSubmission);
                    assignment.Submissions?.Add(submission);
                }    
            }
        }
    }
}