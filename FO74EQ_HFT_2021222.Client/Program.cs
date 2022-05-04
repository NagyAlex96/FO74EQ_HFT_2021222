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
            try
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

                        Console.WriteLine("\nEnter Student DateOfBirth: ");
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
                        Console.Write("Enter TeacherId: ");
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

                        Console.WriteLine("\nEnter GradeBook CourseId: ");
                        int courseIdGrade = int.Parse(Console.ReadLine());

                        Console.WriteLine("\nEnter GradeBook Grade: ");
                        int grade = int.Parse(Console.ReadLine());

                        Console.WriteLine("\nEnter GradeBook Rating: ");
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
                        throw new Exception("Unknown error in creation");
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
        static void List(string entity)
        {
            switch (entity.ToLower())
            {
                case "classroom":
                    List<ClassRoom> classRoom = rest.Get<ClassRoom>("classroom");

                    foreach (var item in classRoom)
                    {
                        Console.WriteLine($"ClassRoom id: {item.ClassRoomId}\nCapacity: {item.Capacity}\n");
                    }
                    break;

                case "course":
                    List<Course> course = rest.Get<Course>("course");

                    foreach (var item in course)
                    {
                        Console.WriteLine($"CourseId: {item.CourseId}\nCourseName: {item.Name}\nDateOfAnnounce: {item.DateOfAnnounced}\nCredit: {item.Credit}\nClassRoomId: {item.ClassRoomId}\nRequirementId: {item.RequirementId}\n");
                    }
                    break;

                case "gradebook":
                    List<GradeBook> gradebook = rest.Get<GradeBook>("gradebook");

                    foreach (var item in gradebook)
                    {
                        Console.WriteLine($"GradeBookId: {item.GradeBookId}\nNeptunId: {item.NeptunId}\nTeacherId: {item.TeacherId}\nCourseId: {item.CourseId}\nGrade: {item.Grade}\nRating: {item.Rating}\n");
                    }
                    break;

                case "student":
                    List<Student> student = rest.Get<Student>("student");

                    foreach (var item in student)
                    {
                        Console.WriteLine($"NeptunId: {item.NeptunId}\nFirstname: {item.FirstName}\nLastname: {item.LastName}\nDateOfBirth: {item.DateOfBirth.ToShortDateString()}\nEmail: {item.Email}\n");
                    }
                    break;

                case "teacher":
                    List<Teacher> teacher = rest.Get<Teacher>("teacher");

                    foreach (var item in teacher)
                    {
                        Console.WriteLine($"TeacherId: {item.TeacherId}\nFirstname: {item.FirstName}\nLastname: {item.LastName}\nSalary: {item.Salary}\n");
                    }
                    break;
                
                default:
                    throw new Exception("Unknown error in list");
                    break;
            }

            Console.ReadLine();

        }

        static void Update(string entity)
        {
            switch (entity.ToLower())
            {
                case "student":
                    Console.Write("Enter Student NeptunId to Update: ");
                    int neptunId = int.Parse(Console.ReadLine());

                    Student Stud = rest.Get<Student>(neptunId, "student");
                    Console.Write($"New NeptunId [old: {Stud.NeptunId}]: ");
                    Stud.NeptunId = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nEnter Student First Name to Update: ");
                    Console.Write($"New first name [old: {Stud.FirstName}]: ");
                    Stud.FirstName = Console.ReadLine();

                    Console.WriteLine("\nEnter Student Last Name to Update: ");
                    Console.Write($"New last name [old: {Stud.LastName}]: ");
                    Stud.LastName = Console.ReadLine();

                    Console.WriteLine("\nEnter Student email address to Update: ");
                    Console.Write($"New last name [old: {Stud.Email}]: ");
                    Stud.Email = Console.ReadLine();

                    Console.WriteLine("\nEnter Student dateOfBirth to Update: ");
                    Console.Write($"New last name [old: {Stud.DateOfBirth.ToShortDateString()}]: ");
                    Stud.DateOfBirth = DateTime.Parse(Console.ReadLine());

                    rest.Put(Stud, "student");
                    break;

                case "teacher":

                    break;

                case "gradebook":
                    break;

                case "course":
                    break;

                case "classroom":
                    break;

                default:
                    throw new Exception("Unknown error");
                    break;
            }
        }

        static void Delete(string entity)
        {
            switch (entity.ToLower())
            {
                case "classroom":
                    Console.Write("Enter classroom's id to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "classroom");
                    break;

                case "course":
                    Console.Write("Enter course's id to delete: ");
                    id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "course");
                    break;

                case "gradebook":
                    Console.Write("Enter gradebook's id to delete: ");
                    id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "gradebook");
                    break;

                case "student":
                    Console.Write("Enter student's id to delete: ");
                    id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "student");
                    break;

                case "teacher":
                    Console.Write("Enter teacher's id to delete: ");
                    id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "teacher");
                    break;

                default:
                    throw new Exception();
                    break;
            }

        }

        static void Main(string[] args)
        {
            //Console.WriteLine("lefutott");

            rest = new RestService("http://localhost:48036/", "GradeBook");

            var classRoomSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("ClassRoom"))
                .Add("Create", () => Create("ClassRoom"))
                .Add("Delete", () => Delete("ClassRoom"))
                .Add("Update", () => Update("ClassRoom"))
                .Add("Exit", ConsoleMenu.Close);

            var courseSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Course"))
                .Add("Create", () => Create("Course"))
                .Add("Delete", () => Delete("Course"))
                .Add("Update", () => Update("Course"))
                .Add("Exit", ConsoleMenu.Close);

            var gradeBookSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("GradeBook"))
                .Add("Create", () => Create("GradeBook"))
                .Add("Delete", () => Delete("GradeBook"))
                .Add("Update", () => Update("GradeBook"))
                .Add("Exit", ConsoleMenu.Close);

            var studentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Student"))
                .Add("Create", () => Create("Student"))
                .Add("Delete", () => Delete("Student"))
                .Add("Update", () => Update("Student"))
                .Add("Exit", ConsoleMenu.Close);

            var teacherSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Teacher"))
                .Add("Create", () => Create("Teacher"))
                .Add("Delete", () => Delete("Teacher"))
                .Add("Update", () => Update("Teacher"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Students", () => studentSubMenu.Show())
                .Add("ClassRooms", () => classRoomSubMenu.Show())
                .Add("Courses", () => courseSubMenu.Show())
                .Add("GradeBooks", () => gradeBookSubMenu.Show())
                .Add("Teachers", () => teacherSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
