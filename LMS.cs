using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using LMS.Models;
using LMS.Services;
using LMS.Helpers;

namespace LMS //Learning Management System
{ 
    public class Program
    {
        public static void MainMenu()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Perform operations on:");
            Console.WriteLine("1. Courses");
            Console.WriteLine("2. Students");
            Console.WriteLine("3. Display this menu");
            Console.WriteLine("4. Exit");
            //Console.WriteLine("------------------------------------------");
        }
        public static void CourseMenu()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Perform operations on Courses:");
            Console.WriteLine("1. Create a Course");
            Console.WriteLine("2. Delete a Course");
            Console.WriteLine("3. Search for a Course");
            Console.WriteLine("4. List all Courses");
            Console.WriteLine("5. List all Students in a Course");
            Console.WriteLine("6. Update a Course's information");
            Console.WriteLine("7. Create an assignment for a Course");
            Console.WriteLine("8. Remove an assignment from a Course");
            Console.WriteLine("9. List all assignments for a Course");
            Console.WriteLine("10. Display this menu");
            Console.WriteLine("11. Back to main menu");
            //Console.WriteLine("------------------------------------------");
        }
        public static void StudentMenu()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Perform operations on Students:");
            Console.WriteLine("1. Create a Student");
            Console.WriteLine("2. Add a Student to a Course");
            Console.WriteLine("3. Remove a Student from a Course");
            Console.WriteLine("4. Search for a Student");
            Console.WriteLine("5. List all Students");
            Console.WriteLine("6. List a Student's Courses");
            Console.WriteLine("7. Update a Student's information");
            Console.WriteLine("8. Display this menu");
            Console.WriteLine("9. Back to main menu");
            //Console.WriteLine("------------------------------------------");
        }
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
                    Console.WriteLine("Unexpected Input.");
                    Console.Write("Please make another selection: ");
                }
            } while (select < 0);
            return select;
        }
        static public void Main(string[] args)
        {
            List<Course> courses = new List<Course>(); //list of courses
            List<Person> students = new List<Person>(); //list of students
            var courseHelper = new CourseHelper();
            var personHelper = new PersonHelper();

            var input = -1;
            MainMenu();
            do
            {
                Console.WriteLine("------------------------------------------");
                Console.Write("Select an Option, or 3 for the menu: ");
                input = UserInput();
                switch (input)
                {
                    case 1:
                        CourseMenu();
                        do
                        {
                            Console.WriteLine("------------------------------------------");
                            Console.Write("Select an Option, or 10 for the menu: ");
                            input = UserInput();
                            switch (input)
                            {
                                case 1:
                                    courseHelper.CreateCourse();
                                    break;
                                case 2: 
                                    courseHelper.DeleteCourse();
                                    break;
                                case 3:
                                    Course course = courseHelper.FindCourse();
                                    break;
                                case 4:
                                    courseHelper.ListCourses();
                                    break;
                                case 5:
                                    courseHelper.FindCourse().ListPeople();
                                    break;
                                case 6:
                                    courseHelper.UpdateCourse();
                                    break;
                                case 7:
                                    courseHelper.CreateAssignment();
                                    break;
                                case 8: 
                                    courseHelper.RemoveAssignment();
                                    break;
                                case 9: 
                                    courseHelper.ListAssignments();
                                    break;
                                case 10:
                                    CourseMenu();
                                    break;
                                case 11:
                                    MainMenu();
                                    break;
                            }
                           // Console.WriteLine("------------------------------------------");
                        }while(input != 11);
                        break;
                    case 2:
                        StudentMenu();
                        do
                        {
                            Console.WriteLine("------------------------------------------");
                            Console.Write("Select an Option, or 8 for the menu: ");
                            input = UserInput();
                            switch (input)
                            {
                                case 1:
                                    personHelper.CreateStudent();
                                    break;
                                case 2:
                                    PersonHelper.AddStudent(students, courses);
                                    break;
                                case 3:
                                    PersonHelper.RemoveStudent(students, courses);
                                    break;
                                case 4:
                                    Person student = personHelper.FindStudent();
                                    break;
                                case 5:
                                    personHelper.ListStudents();
                                    break;
                                case 6:
                                    Person foundStudent = personHelper.FindStudent();
                                    if (foundStudent != null)
                                        PersonHelper.ListStudentCourses(foundStudent);
                                    break;
                                case 7:
                                    PersonHelper.UpdateStudent(students, courses);
                                    break;
                                case 8:
                                    StudentMenu();
                                    break;
                                case 9:
                                    MainMenu();
                                    break;
                            }
                            //Console.WriteLine("------------------------------------------");
                        }while(input != 9);
                        break;
                    case 3:
                        MainMenu();
                        break;
                }
                //Console.WriteLine("------------------------------------------");
            }while(input != 4);
        }
    } 
}
