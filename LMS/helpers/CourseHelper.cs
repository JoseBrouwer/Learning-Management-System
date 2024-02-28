using LMS.Models;
using LMS.Services;

namespace LMS.Helpers 
{
    public class CourseHelper
    {
        private CourseService courseService = CourseService.Current;

        public CourseHelper() { }

        public static int UserInput()
        {
            var select = -1;
            do
            {
                var str = Console.ReadLine();
                if (str == "cancel")
                    return -1;
                try
                {
                    select = int.Parse(str ?? "-1");
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n Input was not an integer.");
                    Console.Write("Please try again, or Enter 'cancel' to cancel: ");
                }
            } while (select < 0);
            return select;
        }
        public void CreateCourse()
        {
            Console.Write("* Course Code: ");
            var code = Console.ReadLine();
            code = code?.ToUpper();
            Console.Write("* Course Name: ");
            var name = Console.ReadLine();
            name = name?.ToUpper();
            Console.Write("* Course Description: ");
            var desc = Console.ReadLine();
            courseService.Add(new Course(code, name, desc));
        }
        public void DeleteCourse()
        {
            CourseHelper courseHelper = new CourseHelper();
            courseHelper.ListCourses();
            Course course = FindCourse();
            if (course != null)
            {
                Console.WriteLine("Are you sure you want to delete this course? (y/n)");
                var select = Console.ReadLine();
                select = select?.Trim();
                select = select?.ToLower();
                if (select == "y" || select == "yes")
                {
                    courseService.Delete(course);
                    Console.WriteLine("Course deleted.");
                }
                else
                {
                    Console.WriteLine("Course not deleted.");
                }
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }
        public void ListCourses()
        {
            Console.WriteLine("ALL COURSES: ");
            courseService.Courses.ToList().ForEach(Console.WriteLine);
        }
        /* Search for a course by Description, Code, or Name
         * Can cancel the search.
         * Returns a course object
         */
        public Course FindCourse()
        {
            Console.WriteLine("Search for a course by code, name, or Description:");
            Console.WriteLine("NOTE: Description is case-sensitive and can search by substring.");
            Course course;
            String query;
            do
            {
                query = Console.ReadLine()?.Trim();
                course = courseService.Courses.FirstOrDefault(x =>
                    (x.Description?.Contains(query, StringComparison.OrdinalIgnoreCase) ?? false)
                    || (x.Code?.Equals(query, StringComparison.OrdinalIgnoreCase) ?? false)
                    || (x.Name?.Equals(query, StringComparison.OrdinalIgnoreCase) ?? false)
                    );
                if (course == null && query != "cancel")
                {
                    Console.WriteLine("Course not found. " +
                        "Please try again, or enter 'cancel' to stop searching. ");
                }
                else if (course == null && query == "cancel")
                    Console.WriteLine("Cancelling...");
                else
                {
                    Console.WriteLine("Course found:");
                    Console.WriteLine(course);
                }
            } while (course == null && query != "cancel");

            return course;
        }
        public void UpdateCourse()
        {
            CourseHelper courseHelper = new CourseHelper();
            courseHelper.ListCourses();
            Console.Write("Name, Code, or Description of Course: ");
            Course course = courseHelper.FindCourse();
            if (course != null)
            {
                Console.WriteLine($"Course found: {course.Code}: {course.Name}");
                var select = -1;
                do
                {
                    Console.WriteLine("Select value to update:");
                    Console.WriteLine("1. Course Code");
                    Console.WriteLine("2. Course Name");
                    Console.WriteLine("3. Course Description");
                    Console.WriteLine("4. Add an Assignment");
                    Console.WriteLine("5. Remove an Assignment");
                    Console.WriteLine("6. Done Updating");
                    select = UserInput();
                    switch (select)
                    {
                        case 1:
                            Console.Write("Enter new Course Code: ");
                            var code = Console.ReadLine();
                            code = code?.ToUpper();
                            course.Code = code;
                            break;
                        case 2:
                            Console.Write("Enter new Course Name: ");
                            var name = Console.ReadLine();
                            name = name?.ToUpper();
                            course.Name = name;
                            break;
                        case 3:
                            Console.Write("Enter new Course Description: ");
                            var desc = Console.ReadLine();
                            course.Description = desc;
                            break;
                        case 4:
                            courseHelper.CreateAssignment();
                            break;
                        case 5:
                            courseHelper.RemoveAssignment();
                            break;
                        case 6:
                            break;
                        default:
                            Console.WriteLine("Invalid selection, try again.");
                            break;
                    }
                    
                }while(select > 0 && select != 6);
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }
        public void CreateAssignment()
        {
            CourseHelper courseHelper = new CourseHelper();
            courseHelper.ListCourses();
            Course course = courseHelper.FindCourse();
            if (course != null)
            {
                Console.Write("Assignment Name: ");
                var name = Console.ReadLine();
                name = name?.ToUpper();
                Console.Write("Assignment Description: ");
                var desc = Console.ReadLine();
                Console.Write("Total Points: ");
                var points = 0.00;
                try
                {
                    points = double.Parse(Console.ReadLine() ?? "-1");
                    if (points < 0)
                        throw new Exception();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Can't have negative points.");
                    return;
                }
                Console.Write("Assignment Due Date: ");
                var due = Console.ReadLine();
                Assignment assignment = new Assignment(name, desc, points, due);
                course.Assignments?.Add(assignment);
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }
        public void RemoveAssignment()
        {
            CourseHelper courseHelper = new CourseHelper();
            courseHelper.ListCourses();
            Course course = courseHelper.FindCourse();
            if (course != null)
            {
                Console.WriteLine("Select an Assignment to remove:");
                int i = 0;
                if(course.Assignments != null)
                {
                    foreach (var assignment in course.Assignments)
                    {
                        Console.WriteLine($"{i}. {assignment.Name}");
                        i++;
                    }
                    var select = UserInput();
                    if (select >= 0 && select < course.Assignments.Count)
                    {
                        course.Assignments.RemoveAt(select);
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("No assignments found.");
                }
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }
        public void ListAssignments()
        {
            CourseHelper courseHelper = new CourseHelper();
            courseHelper.ListCourses();
            Course course = courseHelper.FindCourse();
            if (course != null)
            {
                Console.WriteLine("Assignments:");
                int i = 0;
                if (course?.Assignments?.Count != 0 || course.Assignments != null)
                {
                    foreach (var assignment in course.Assignments)
                    {
                        Console.WriteLine($"\t{i}. {assignment.Name}");
                        i++;
                    }
                }
                else
                {
                    Console.WriteLine("No assignments found.");
                }
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }
    }
}