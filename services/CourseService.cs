using LMS.Models;

namespace LMS.Services {
    public class CourseService {
        private IList<Course> courses;
        private string? query;
        private static object _lock;
        private static CourseService instance;

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
                        || c.Code.ToUpper().Contains(query ?? string.Empty));
            }
        }
        private CourseService()
        {
            courses = new List<Course>();
        }

        public void Add(Course course) {
            courses.Add(course);
        }
        public static void CreateCourse(CourseService courseService)
        {
            Console.WriteLine("------------------------------------------");
            Console.Write("* Course Code: ");
            var code = Console.ReadLine();
            Console.Write("* Course Name: ");
            var name = Console.ReadLine();
            Console.Write("* Course Description: ");
            var desc = Console.ReadLine();
            Course theCourse = new Course(code, name, desc); //construct course
            courseService.Add(theCourse); //add course to list
            Console.WriteLine("------------------------------------------");
        }
    }
}