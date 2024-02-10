using LMS.Models;

namespace LMS.Services {
    public class PersonService {

        private IList<Person> students;
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
        private IEnumerable<Person> Students
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
            students = new List<Person>();
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
        public void Delete(Person studentToDelete)
        {
            students.Remove(studentToDelete);
        }
    }
}