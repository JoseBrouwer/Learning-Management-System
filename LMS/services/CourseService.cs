using LMS.Models;

namespace LMS.Services
{
    public class CourseService
    {
        private IList<Course> courses;
        private string? query;
        private static object _lock = new object();
        private static CourseService? instance;

        public static CourseService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new CourseService();
                    }
                }

                return instance;
            }
        }
        public IEnumerable<Course> Courses
        {
            get
            {
                return courses.Where(
                    c =>
                        c.Name.ToUpper().Contains(query ?? string.Empty)
                        || c.Code.ToUpper().Contains(query ?? string.Empty)
                        || c.Description.ToUpper().Contains(query ?? string.Empty));
            }
        }
        private CourseService()
        {
            courses = new List<Course>
            { 
                new Course{Code = "COP4530", Name = "DSII", Description = "Data Structures"},
                new Course{Code = "COP4531", Name = "Complexity Analysis", Description = "Algorithms"},
                new Course{Code = "COP4870", Name = "C#", Description = "Full-Stack App Development"},
            };
            //courses[1].AddPerson(new Person { Name = "Testing Roster" });
        }
        public Course? Get(string code)
        {
            return courses.FirstOrDefault(c => c.Code == code);
        }
        public IEnumerable<Course> GetByStudentId(Guid personId)
        {
            return courses.Where(c => c.PersonId == personId);
        }
        public bool IsCodeUnique(string code)
        {
            return !Courses.Any(course => course.Code.Equals(code, StringComparison.OrdinalIgnoreCase));
        }
        public void AddOrUpdate(Course course) //FIX TO HANDLE UPDATING, CREATES DUPES
        {
            if (course.Code == string.Empty)
            {
                course.Code = "DEFAULT";

                //ONLY doesn't create a dupe bc its a local app
                //CHANGE WHEN IMPLEMENTING SERVICES
                courses.Add(course);
            }
            else if(IsCodeUnique(course.Code))
                courses.Add(course);
        }
        public void Add(Course course)
        {
            courses.Add(course);
        }
        public void Remove(Course course)
        {
            courses.Remove(course);
        }
        public bool IsPersonInRoster(Course course, Person person)
        {
            foreach (Person student in course.Roster ?? new List<Person>())
            {
                if (student == person)
                    return true;
            }
            return false;
        }
        public void RemovePersonFromRoster(Course course, Person person)
        {
            if(IsPersonInRoster(course, person))
                course?.Roster?.Remove(person);
        }
        public void Delete(Course courseToDelete)
        {
            courses.Remove(courseToDelete);
        }
    }
}