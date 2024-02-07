using LMS.Models;

namespace LMS.Services {
    public class PersonService {
        private static PersonService instance;
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
        private IEnumerable<Person> projects;
        private PersonService()
        {
            projects = new List<Person>();
        }

        public IEnumerable<Person> GetByClient(Guid personId)
        {
            return projects.Where(p => p.PersonId == personId);
        }
    }
}