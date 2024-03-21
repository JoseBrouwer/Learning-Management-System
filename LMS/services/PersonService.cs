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
                new Person("TestPerson", (Person.Years?)0, 100),
                new Person("TestPerson", (Person.Years?)1, 100),
                new Person("TestPerson", (Person.Years?)2, 100),
                new Person("TestPerson", (Person.Years?)3, 100),
                new Person("TestPerson", (Person.Years ?)4, 100),
            };
            courses = new List<Course>();
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
            }
            students.Add(student);
        }
        //Kept for the sake of not breaking Console App
        public void Add(Person student)
        {
            students.Add(student);
        }
        public void AddCourse(Course course)
        {
            courses.Add(course);
        }
        public void Remove(Person student)
        {
            students.Remove(student);
        }
        public void Delete(Person studentToDelete)
        {
            students.Remove(studentToDelete);
        }
        public void DeleteCourse(Course courseToDelete)
        {
            courses.Remove(courseToDelete);
        }
    }
}