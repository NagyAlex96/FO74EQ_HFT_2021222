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
        StudentLogic studentLogic;
        TeacherLogic teacherLogic;

        GradeBookLogic gradeBookLogicBasicForCreate;
        GradeBookLogic gradeBookLogicForNonCrud1;
        GradeBookLogic gradeBookLogicForNonCrud2;
        GradeBookLogic gradeBookLogicForNonCrud3;
        GradeBookLogic gradeBookLogicForNonCrud4;


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
                new GradeBook("5#5#5#4#3#4"),

                new GradeBook("5#1#5#3#3#2"),
                new GradeBook("5#1#5#2#5#3"),
            }.AsQueryable();


            mockGradeBookRepository = new Mock<IRepository<GradeBook>>();
            mockGradeBookRepository.Setup(x => x.ReadAll()).Returns(gradeBookInputData);
            gradeBookLogicBasicForCreate = new GradeBookLogic(mockGradeBookRepository.Object);

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

            gradeBookLogicForNonCrud1 = new GradeBookLogic(mockGradeBookRepository.Object, mockStudentRepository.Object, null, null, null);

            gradeBookLogicForNonCrud2 = new GradeBookLogic(mockGradeBookRepository.Object, null, mockTeacherRepository.Object, null, null);            
            
            gradeBookLogicForNonCrud3 = new GradeBookLogic(mockGradeBookRepository.Object, null, mockTeacherRepository.Object, null, mockCourseRespository.Object); 
            
            gradeBookLogicForNonCrud4 = new GradeBookLogic(mockGradeBookRepository.Object, null, null, null, mockCourseRespository.Object);

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

            Assert.That(() => gradeBookLogicBasicForCreate.Create(new GradeBook
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
        public void CreateCourseTest()
        {
            Assert.That(() => courseLogic.Create(new Course
            {
                CourseId = 1,
                Name = "Biológia",
                DateOfAnnounced = new DateTime(2020, 01, 01),
                Credit = 5,
                ClassRoomId = 2,
                RequirementId = 1,

            }), Throws.Nothing);
        }

        [Test]
        public void CreateClassRoomTest()
        {
            Assert.That(() => classRoomLogic.Create(new ClassRoom
            {
                ClassRoomId = 1,
                Capacity = 100,

            }), Throws.Nothing);
        }

        [Test]
        public void CheckAverageOfAverageGradeOfStudentsTest()
        {
            //GradeBookId, NeptunId, TeacherId, CourseId, Grade, Rating

            //check average of average
            var result = gradeBookLogicForNonCrud1.GetAllStudentAverageGrade().Average(t=>t.Value);

            double expected = 3.3;

            Assert.That(expected, Is.EqualTo(result));
        }

        [Test]
        public void GetAverageRatingOfTeacherRatingTest()
        {
            //GradeBookId, NeptunId, TeacherId, CourseId, Grade, Rating

            double result = gradeBookLogicForNonCrud2.GetAverageRatingOfTeacher().Average(t=>t.Value);

            double expected = 3.15;

            Assert.That(expected, Is.EqualTo(result));
        }               
       
        [Test]
        public void GetCoursesByTakingExactTeacherTest()
        {
            //GradeBookId, NeptunId, TeacherId, CourseId, Grade, Rating

            var result = gradeBookLogicForNonCrud3.GetCourseByTeacher(5).Count();

            int expectedCount = 4;

            Assert.That(expectedCount, Is.EqualTo(result));
        }        
        
        [Test]
        public void GetAverageOfAllCourseTest()
        {
            //GradeBookId, NeptunId, TeacherId, CourseId, Grade, Rating

            var result = gradeBookLogicForNonCrud4.GetAllCourseAverageGrade();

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Subject005", 4),
                new KeyValuePair<string, double>("Subject004", 3),
                new KeyValuePair<string, double>("Subject003", 2.5),
                new KeyValuePair<string, double>("Subject002", 5),
                new KeyValuePair<string, double>("Subject001", 2),
            };

            Assert.That(expected, Is.EqualTo(result));
        }        
        
        [Test]
        public void GetAverageGradeByDateOfBirthTest()
        {
            var result = gradeBookLogicForNonCrud1.GetAverageGradeByDateOfBirth();

            var expected = new List<KeyValuePair<int, double>>()
            {
                new KeyValuePair<int, double>(1999, 3.5),
                new KeyValuePair<int, double>(2000, 4),          
                new KeyValuePair<int, double>(1998, 2.5),
            };

            Assert.That(expected, Is.EqualTo(result));
        }

        #endregion
    }
}
