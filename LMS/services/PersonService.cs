using LMS.Models;

namespace LMS.Services {
    public class PersonService {

        private IList<Person> students;
        private IList<Course> courses;
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
        public void Add(Person student)
        {
            students.Add(student);
        }
        public void AddCourse(Course course)
        {
            courses.Add(course);
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