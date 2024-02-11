using LMS.Models;
using LMS.Helpers;
using LMS.Services;

namespace LMS.Helpers
{
    public class PersonHelper
    {
        private PersonService personService = PersonService.Current;

        public PersonHelper() { }

        public static int UserInput()
        {
            var select = -1;
            do
            {
                var str = Console.ReadLine();
                try
                {
                    select = int.Parse(str ?? "-1");
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n Input was not an integer.");
                    Console.Write("Please make another selection: ");
                }
            } while (select < 0);
            return select;
        }
        public void CreateStudent()
        {
            Console.Write("* Student Name: ");
            var name = Console.ReadLine();
            name = name?.Trim();
            name = name?.ToUpper();
            Console.Write("* Student class (0-4 for Freshman-Graduate): ");
            var year = (Person.Years)UserInput();
            Console.Write("* Student Grade: ");
            var grade = UserInput();
            personService.Add(new Person(name, year, grade));
        }
        public void ListStudents()
        {
            Console.WriteLine("ALL STUDENTS: ");
            personService.Students.ToList().ForEach(Console.WriteLine);
        }
        public static void AddStudent(List<Person> students, List<Course> courses)
        {
            Person student = null;
            Course course = null;
            PersonHelper personHelper = new PersonHelper();
            do
            {
                personHelper.ListStudents();
                student = personHelper.FindStudent();
                CourseHelper courseHelper = new CourseHelper();
                courseHelper.ListCourses();
                course = courseHelper.FindCourse();
            }while(student == null || course == null);
            student.Courses?.Add(course);
            course.Roster?.Add(student);
            Console.WriteLine($"Student {student.Name} added to course {course.Code}: {course.Name}");
        }
        public static void RemoveStudent(List<Person> students, List<Course> courses)
        {
            Person student = null;
            Course course = null;
            CourseHelper courseHelper = new CourseHelper();
            PersonHelper personHelper = new PersonHelper();
            do
            {
                personHelper.ListStudents();
                student = personHelper.FindStudent();
                foreach(var c in student?.Courses)
                {
                    Console.WriteLine($"{c.Code}: {c.Name}");
                }
                course = courseHelper.FindCourse();
                if(course.Roster?.Contains(student) == false)
                {
                    Console.WriteLine("Student is not enrolled in that course. Try again.");
                    student = null;
                    course = null;
                }
                else
                {
                    break;
                }
            }while(student == null || course == null);
            student.Courses?.Remove(course);
            course.Roster?.Remove(student);
            Console.WriteLine($"Student {student.Name} removed from course {course.Code}: {course.Name}");
        }
        public static void ListStudentCourses(Person student)
        {
            int i = 0;
            if (student.Courses != null && student.Courses.Count != 0)
            {
                foreach (var course in student.Courses)
                {
                    Console.WriteLine($"{i}. {course.Code}: {course.Name}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("No courses found for the selected student.");
            }
        }
        public Person FindStudent()
        {
            Console.Write("Search for a Student by Name or Id: ");
            String query;
            Person student;
            do
            {
                query = Console.ReadLine()?.Trim().ToUpper();
                student = personService.Students.FirstOrDefault(x =>
                    ((x.Name?.Equals(query, StringComparison.OrdinalIgnoreCase) ?? false) == true)
                    || (x.Id.ToString().Equals(query, StringComparison.OrdinalIgnoreCase))
                    );
                if (student == null && query != "cancel")
                {
                    Console.WriteLine("Student not found. " + 
                        "Please try again, or enter 'cancel' to stop searching");
                }
                else if (student == null && query=="cancel")
                    Console.WriteLine("Cancelling...");
                else
                {
                    Console.WriteLine("Student found:");
                    Console.WriteLine(student);
                }
            } while (student == null && query != "cancel");

            return student;
        }
        public static void UpdateStudent(List<Person> students, List<Course> courses)
        {
            PersonHelper personHelper = new PersonHelper();
            Person student = personHelper.FindStudent();
            if (student != null)
            {
                var select = -1;
                do
                {
                    Console.WriteLine("Select value to update:");
                    Console.WriteLine("1. Name");
                    Console.WriteLine("2. Classification");
                    Console.WriteLine("3. Grades");
                    Console.WriteLine("4. Courses");
                    Console.WriteLine("5. Done Updating");
                    select = UserInput();
                    switch (select)
                    {
                        case 1:
                            Console.Write("New Name: ");
                            var name = Console.ReadLine();
                            name = name?.Trim();
                            name = name?.ToUpper();
                            student.Name = name;
                            break;
                        case 2:
                            Console.Write("New Classification (0-4 for Freshman-Graduate): ");
                            var year = (Person.Years)UserInput();
                            student.Classification = year;
                            break;
                        case 3:
                            Console.Write("New Grade: ");
                            var grade = UserInput();
                            student.Grades = grade;
                            break;
                        case 4:
                            var choice = -1;
                            do
                            {
                                Console.WriteLine("Select an option:");
                                Console.WriteLine("\t1. Add Course");
                                Console.WriteLine("\t2. Remove Course");
                                Console.WriteLine("\t3. Done Updating");
                                choice = UserInput();
                                switch (choice)
                                {
                                    case 1:
                                        AddStudent(students, courses ?? new List<Course>());
                                        break;
                                    case 2:
                                        RemoveStudent(students, courses ?? new List<Course>());
                                        break;
                                    default:
                                        Console.WriteLine("Invalid selection, try again.");
                                        break;
                                }
                            } while (choice > 0 && choice <= 2);
                            break;
                        case 5:
                            Console.WriteLine("Done updating...");
                            break;
                        default:
                            Console.WriteLine("Invalid selection, try again.");
                            break;
                    }
                } while (select > 0 && select < 5);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}