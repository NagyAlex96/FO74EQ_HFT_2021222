using FO74EQ_HFT_2021222.Logic.Classes;
using FO74EQ_HFT_2021222.Repository.Model_Repository;
using FO74EQ_HFT_2021222.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FO74EQ_HFT_2021222.Repository.Interfaces;

namespace FO74EQ_HFT_2021222.Test
{
    [TestFixture]
    public class Test
    {
        ClassRoomLogic classRoomLogic;

        CourseLogic courseLogic;

        GradeBookLogic gradeBookLogic;
        GradeBookLogic gradeBookLogic2;
        GradeBookLogic gradeBookLogic3;

        StudentLogic studentLogic;

        TeacherLogic teacherLogic;


        Mock<IRepository<ClassRoom>> mockClassRoomRepository;
        Mock<IRepository<Course>> mockCourseRespository;
        Mock<IRepository<GradeBook>> mockGradeBookRepository;
        Mock<IRepository<Student>> mockStudentRepository;
        Mock<IRepository<Teacher>> mockTeacherRepository;


        [SetUp]
        public void Init()
        {
            #region ClassRoom
            var classRoomInputData = new List<ClassRoom>()
            {
                //classRoomId, Capacity
                new ClassRoom("1#10"),
                new ClassRoom("2#11"),
                new ClassRoom("3#12"),
                new ClassRoom("4#13"),
                new ClassRoom("5#14"),

            }.AsQueryable();


            mockClassRoomRepository = new Mock<IRepository<ClassRoom>>();
            mockClassRoomRepository.Setup(x => x.ReadAll()).Returns(classRoomInputData);
            classRoomLogic = new ClassRoomLogic(mockClassRoomRepository.Object);
            #endregion

            #region Course
            //TODO: Null kezelése
            var courseInputData = new List<Course>()
            {
                //CourseId, Name, DateOfAnnounced, Credit, ClassRoomId, RequirementId
                new Course("1#Subject001#07*30*2019#5#1#0"),
                new Course("2#Subject002#04*10*2015#3#2#1"),
                new Course("3#Subject003#02*15*2017#4#5#2"),
                new Course("4#Subject004#07*30*2019#1#4#3"),
                new Course("5#Subject005#02*10*2012#2#3#4"),

            }.AsQueryable();


            mockCourseRespository = new Mock<IRepository<Course>>();
            mockCourseRespository.Setup(x => x.ReadAll()).Returns(courseInputData);
            courseLogic = new CourseLogic(mockCourseRespository.Object);

            #endregion

            #region GradeBook
            var gradeBookInputData = new List<GradeBook>()
            {
                //GradeBookId, NeptunId, TeacherId, CourseId, Grade, Rating
                new GradeBook("1#1#1#5#4#4"),
                new GradeBook("2#2#2#4#3#2"),
                new GradeBook("3#3#3#3#2#4"),
                new GradeBook("4#4#4#2#5#3"),
                new GradeBook("5#5#5#1#2#2"),
                new GradeBook("5#5#6#10#3#4"),

                new GradeBook("5#1#6#12#3#2"),
                new GradeBook("5#1#6#15#5#3"),
            }.AsQueryable();


            mockGradeBookRepository = new Mock<IRepository<GradeBook>>();
            mockGradeBookRepository.Setup(x => x.ReadAll()).Returns(gradeBookInputData);
            gradeBookLogic = new GradeBookLogic(mockGradeBookRepository.Object);

            #endregion

            #region Student
            var studentInputData = new List<Student>()
            {
                //NeptunId, FirstName, LastName, DateOfBirth, Email
                new Student("1#Haney#Macy#06*26*1999#non.nisi.Aenean@Nuncuterat.ca"),
                new Student("2#Mosley#Willow#04*07*2000#Ut@elementumategestas.ca"),
                new Student("3#Chambers#Ira#07*16*1999#dui.semper@Namacnulla.edu"),
                new Student("4#Parsons#Hayley#08*14*2000#egestas.a@et.co.uk"),
                new Student("5#Tanner#Jeanette#01*21*1998#blandit@egetmollis.net"),
            }.AsQueryable();


            mockStudentRepository = new Mock<IRepository<Student>>();
            mockStudentRepository.Setup(x => x.ReadAll()).Returns(studentInputData);
            studentLogic = new StudentLogic(mockStudentRepository.Object);

            #endregion

            #region Teacher
            var teacherInputData = new List<Teacher>()
            {
                //TeacherId, LastName, FirstName, Salary
                new Teacher("1#John#Bass#212651"),
                new Teacher("2#Armando#Slater#162134"),
                new Teacher("3#Rhiannon#Pennington#265365"),
                new Teacher("4#Abigail#Thomas#392938"),
                new Teacher("5#Nora#Pennington#151121"),

            }.AsQueryable();


            mockTeacherRepository = new Mock<IRepository<Teacher>>();
            mockTeacherRepository.Setup(x => x.ReadAll()).Returns(teacherInputData);
            teacherLogic = new TeacherLogic(mockTeacherRepository.Object);

            #endregion

            gradeBookLogic2 = new GradeBookLogic(mockGradeBookRepository.Object, mockStudentRepository.Object);            
            
            gradeBookLogic3 = new GradeBookLogic(mockGradeBookRepository.Object, mockTeacherRepository.Object);

        }

        #region Test
        [Test]
        public void CreateTeacherTest()
        {
            Assert.That(() => teacherLogic.Create(new Teacher
            {
                FirstName = "A",
                LastName = "B",
                Salary = 10000,
                TeacherId = 1
            }), Throws.Nothing);
        }

        [Test]
        public void CreateStudentTest()
        {
            Assert.That(() => studentLogic.Create(new Student
            {
                NeptunId = 1,
                FirstName = "John",
                LastName = "Ryan",
                DateOfBirth = new DateTime(2005, 03, 01),
            }), Throws.Exception);
        }

        [Test]
        public void CreateGradeBookTest()
        {
            //GradeBookId, NeptunId, TeacherId, CourseId, Grade, Rating

            Assert.That(() => gradeBookLogic.Create(new GradeBook
            {
                GradeBookId = 1,
                NeptunId = 2,
                TeacherId = 1,
                CourseId = 2,
                Grade = 3,
                Rating = 3

            }), Throws.Nothing);
        }

        [Test]
        public void GetAverageGradeOfStudentsTest()
        {
            //GradeBookId, NeptunId, TeacherId, CourseId, Grade, Rating


            var result = gradeBookLogic2.GetAllStudentAverageGrade();

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("OEB005", 2.5)
            };

            Assert.That(expected, Is.EqualTo(expected));
        }

        [Test]
        public void GetAverageRatingOfTeacherRatingTest()
        {
            //GradeBookId, NeptunId, TeacherId, CourseId, Grade, Rating


            var result = gradeBookLogic3.GetAverageRatingOfTeacher();

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("1", 3)
            };

            Assert.That(expected, Is.EqualTo(expected));
        }

        #endregion
    }
}
