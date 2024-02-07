using LMS.Models;

namespace LMS.Helpers 
{
    public static class CourseHelper
    {
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
        public static void CreateCourse(List<Course> courses)
        {
            Console.Write("* Course Code: ");
            var code = Console.ReadLine();
            code = code?.ToUpper();
            Console.Write("* Course Name: ");
            var name = Console.ReadLine();
            name = name?.ToUpper();
            Console.Write("* Course Description: ");
            var desc = Console.ReadLine();
            Course theCourse = new Course(code, name, desc); //construct course
            courses.Add(theCourse); //add course to list
        }
        public static void DeleteCourse(List<Course> courses)
        {
            ListCourses(courses);
            Course course = FindCourse(courses);
            if (course != null)
            {
                Console.WriteLine("Are you sure you want to delete this course? (y/n)");
                var select = Console.ReadLine();
                select = select?.Trim();
                select = select?.ToLower();
                if (select == "y" || select == "yes")
                {
                    courses.Remove(course);
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
        public static void ListCourses(List<Course> courses)
        {
            Console.WriteLine("ALL COURSES: ");
            foreach (var course in courses)
                Console.WriteLine($"* {course.Code}: {course.Name}");
            Console.WriteLine("\n");
        }
        public static Course FindCourse(List<Course> courses)
        {
            Console.WriteLine("Search for a course by code, name, or Description:");
            Console.WriteLine("NOTE: Description is case-sensitive and can search by substring.");
            var query = Console.ReadLine();
            query = query?.Trim();
            var course = courses.Find(x => x.Description != null && x.Description.Contains(query));
            if (course == null)
            {
                query = query.ToUpper();
                course = courses.Find(x => x.Code == query || x.Name == query);
            }
            while(course == null && query != null)
            {
                Console.WriteLine("Course not found, try again.\nEnter 'cancel' to cancel.");
                query = Console.ReadLine();
                query = query?.Trim();
                if (query == "cancel")
                    break;
                course = courses.Find(x => x.Description != null && x.Description.Contains(query));
                if (course == null)
                {
                    query = query.ToUpper();
                    course = courses.Find(x => x.Code == query || x.Name == query);
                }
            }
            Console.WriteLine($"Course(s) found:");
            if(course == null)
                Console.WriteLine($"\tNONE FOUND");
            else
                Console.WriteLine($"{course}");
            return course; //null handled in main
        }
        public static void UpdateCourse(List<Course> courses)
        {
            ListCourses(courses);
            Console.Write("Name, Code, or Description of Course: ");
            Course course = FindCourse(courses);
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
                            CreateAssignment(courses);
                            break;
                        case 5:
                            RemoveAssignment(courses);
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
        public static void CreateAssignment(List<Course> courses)
        {
            ListCourses(courses);
            Course course = FindCourse(courses);
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
        public static void RemoveAssignment(List<Course> courses)
        {
            ListCourses(courses);
            Course course = FindCourse(courses);
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
        public static void ListAssignments(List<Course> courses)
        {
            ListCourses(courses);
            Course course = FindCourse(courses);
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