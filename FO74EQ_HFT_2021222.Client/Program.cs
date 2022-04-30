using ConsoleTools;
using FO74EQ_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FO74EQ_HFT_2021222.Client
{
    internal class Program
    {
        static RestService rest;

        static void Create(string entity)
        {
            switch (entity.ToLower())
            {
                case "student":
                    Console.Write("Enter Student NeptunId: ");
                    int neptunId = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nEnter Student First Name: ");
                    string firstName = Console.ReadLine();

                    Console.WriteLine("\nEnter Student Last Name: ");
                    string lastName = Console.ReadLine();

                    Console.WriteLine("\nEnter Student Email Address: ");
                    string email = Console.ReadLine();

                    Console.WriteLine("\nEnter Student DateOfBirth Name: ");
                    DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

                    rest.Post(new Student()
                    {
                        NeptunId = neptunId,
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dateOfBirth,
                        Email = email
                    }, "student");
                    break;

                case "teacher":
                    Console.Write("Enter TeacherId NeptunId: ");
                    int teacherId = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nEnter Teacher First Name: ");
                    string firstNameTeacher = Console.ReadLine();

                    Console.WriteLine("\nEnter Teacher Last Name: ");
                    string lastNameTeacher = Console.ReadLine();

                    Console.WriteLine("\nEnter Teacher salary: ");
                    int salary = int.Parse(Console.ReadLine());

                    rest.Post(new Teacher()
                    {
                        TeacherId = teacherId,
                        FirstName = firstNameTeacher,
                        LastName = lastNameTeacher,
                        Salary = salary,
                    }, "teacher");
                    break;

                case "gradebook":
                    Console.Write("Enter GradeBook Id: ");
                    int gradeBookId = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nEnter GradeBook NeptunId: ");
                    int neptunIdGrade = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nEnter GradeBook TeacherId: ");
                    int teacherIdGrade = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nEnter GradeBook teacherId: ");
                    int courseIdGrade = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nEnter GradeBook grade: ");
                    int grade = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("\nEnter GradeBook rating: ");
                    int rating = int.Parse(Console.ReadLine());

                    rest.Post(new GradeBook()
                    {
                        GradeBookId = gradeBookId,
                        NeptunId = neptunIdGrade,
                        TeacherId = teacherIdGrade,
                        CourseId = courseIdGrade,
                        Grade = grade,
                        Rating = rating,

                    }, "gradeBook");
                    break;

                case "course":
                    Console.Write("Enter Course Id: ");
                    int courseId = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nEnter Course name: ");
                    string name = Console.ReadLine();

                    Console.WriteLine("\nEnter Course date of announce: ");
                    DateTime dateOfAnnounce = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("\nEnter Course credit: ");
                    int credit = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nEnter Course class room Id: ");
                    int classRoomIdCourse = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nEnter Course requirementId: ");
                    int requireMentID = int.Parse(Console.ReadLine());

                    rest.Post(new Course()
                    {
                        CourseId = courseId,
                        Name = name,
                        DateOfAnnounced = dateOfAnnounce,
                        Credit = credit,
                        ClassRoomId = classRoomIdCourse,
                        RequirementId = requireMentID,

                    }, "Course");
                    break;

                case "classroom":
                    Console.Write("Enter class room Id: ");
                    int classRoomId = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nEnter class room capacity: ");
                    int capacity = int.Parse(Console.ReadLine());


                    rest.Post(new ClassRoom()
                    {
                        ClassRoomId = classRoomId,
                        Capacity = capacity,

                    }, "classRoom");
                    break;

                default:
                    throw new Exception("Unknown error");
                    break;
            }
        }

        static void List(string entity)
        {
            if (entity == "Student")
            {
                List<Student> actors = rest.Get<Student>("student");
                foreach (var item in actors)
                {
                    Console.WriteLine(item.NeptunId + ": " + $"{item.FirstName}{item.LastName}");
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Actor")
            {
                Console.Write("Enter Actor's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Student one = rest.Get<Student>(id, "student");
                Console.Write($"New name [old: {one.FirstName}{one.LastName}]: ");
                string name = Console.ReadLine();
                one.FirstName = name;
                rest.Put(one, "actor");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Actor")
            {
                Console.Write("Enter Actor's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "actor");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("lefutott");

            //rest = new RestService("http://localhost:48036/", "GradeBook");

            //var classRoomSubMenu = new ConsoleMenu(args, level: 1)
            //    .Add("List", () => List("ClassRoom"))
            //    .Add("Create", () => Create("ClassRoom"))
            //    .Add("Delete", () => Delete("ClassRoom"))
            //    .Add("Update", () => Update("ClassRoom"))
            //    .Add("Exit", ConsoleMenu.Close);

            //var courseSubMenu = new ConsoleMenu(args, level: 1)
            //    .Add("List", () => List("Course"))
            //    .Add("Create", () => Create("Course"))
            //    .Add("Delete", () => Delete("Course"))
            //    .Add("Update", () => Update("Course"))
            //    .Add("Exit", ConsoleMenu.Close);

            //var gradeBookSubMenu = new ConsoleMenu(args, level: 1)
            //    .Add("List", () => List("GradeBook"))
            //    .Add("Create", () => Create("GradeBook"))
            //    .Add("Delete", () => Delete("GradeBook"))
            //    .Add("Update", () => Update("GradeBook"))
            //    .Add("Exit", ConsoleMenu.Close);

            //var studentSubMenu = new ConsoleMenu(args, level: 1)
            //    .Add("List", () => List("Student"))
            //    .Add("Create", () => Create("Student"))
            //    .Add("Delete", () => Delete("Student"))
            //    .Add("Update", () => Update("Student"))
            //    .Add("Exit", ConsoleMenu.Close);

            //var teacherSubMenu = new ConsoleMenu(args, level: 1)
            //    .Add("List", () => List("Teacher"))
            //    .Add("Create", () => Create("Teacher"))
            //    .Add("Delete", () => Delete("Teacher"))
            //    .Add("Update", () => Update("Teacher"))
            //    .Add("Exit", ConsoleMenu.Close);


            //var menu = new ConsoleMenu(args, level: 0)
            //    .Add("Students", () => studentSubMenu.Show())
            //    .Add("ClassRooms", () => classRoomSubMenu.Show())
            //    .Add("Courses", () => courseSubMenu.Show())
            //    .Add("GradeBooks", () => gradeBookSubMenu.Show())
            //    .Add("Teachers", () => teacherSubMenu.Show())
            //    .Add("Exit", ConsoleMenu.Close);

            //menu.Show();

        }
    }
}
