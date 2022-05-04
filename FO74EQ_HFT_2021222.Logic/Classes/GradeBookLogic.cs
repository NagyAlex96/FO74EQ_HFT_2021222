using FO74EQ_HFT_2021222.Logic.Interfaces;
using FO74EQ_HFT_2021222.Models;
using FO74EQ_HFT_2021222.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FO74EQ_HFT_2021222.Logic.Classes
{
    public class GradeBookLogic : IGradeBookLogic
    {
        IRepository<GradeBook> gradeRepo;

        IRepository<Student> studRepo;
        IRepository<Teacher> teachRepo;
        IRepository<ClassRoom> classRepo;
        IRepository<Course> courseRepo;

        public GradeBookLogic(IRepository<GradeBook> repository, IRepository<Student> studRepo = null, IRepository<Teacher> teachRepo = null, IRepository<ClassRoom> classRepo = null, IRepository<Course> courseRepo = null)
        {
            this.gradeRepo = repository;
            this.studRepo = studRepo;
            this.teachRepo = teachRepo;
            this.classRepo = classRepo;
            this.courseRepo = courseRepo;
        }

        #region CRUD
        public void Create(GradeBook item)
        {
            if (item.NeptunId <= 0)
            {
                throw new Exception("NeptunId cannot be smaller than 1");
            }
            this.gradeRepo.Create(item);
        }

        public void Delete(int id)
        {
            this.gradeRepo.Delete(id);
        }

        public GradeBook Read(int id)
        {
            return this.gradeRepo.Read(id);
        }

        public IQueryable<GradeBook> ReadAll()
        {
            return this.gradeRepo.ReadAll();
        }

        public void Update(GradeBook item)
        {
            this.gradeRepo.Update(item);
        }

        #endregion

        #region Non-Crud

        public IEnumerable<KeyValuePair<string, double>> GetAllStudentAverageGrade()
        {
            var gradeRead = gradeRepo.ReadAll();
            var studRead = studRepo.ReadAll();

            if (gradeRead == null || studRead == null)
            {
                throw new NullReferenceException();
            }

            return from x in gradeRead
                   join y in studRead on x.NeptunId equals y.NeptunId
                   group x by y.NeptunId
                    into f
                   select new KeyValuePair<string, double>
                   (
                       f.Key.ToString(),
                       f.Average(t => t.Grade)
                   );
            ;
        }

        public IEnumerable<KeyValuePair<string, double>> GetAverageRatingOfTeacher()
        {
            var gradeRead = gradeRepo.ReadAll();
            var teacherRead = teachRepo.ReadAll();

            if (gradeRead == null || teacherRead == null)
            {
                throw new NullReferenceException();
            }

            return from x in gradeRead
                   join y in teacherRead on x.TeacherId equals y.TeacherId
                   group x by y.TeacherId
                   into f
                   select new KeyValuePair<string, double>
                   (
                       f.Key.ToString(),
                       f.Average(t => t.Rating)
                   );

        }

        /// <summary>
        /// Returns all names of the courses that this teacher is taking
        /// </summary>
        /// <param name="teacherId">Identification of teacher</param>
        /// <returns></returns>
        public IEnumerable<string> GetCourseByTeacher(int teacherId)
        {
            var gradeRead = gradeRepo.ReadAll();
            var teacherRead = teachRepo.ReadAll();
            var courseRead = courseRepo.ReadAll();


            if (gradeRead == null || courseRead == null || teacherRead == null)
            {
                throw new NullReferenceException();
            }

            var returnedValue = from x in courseRead
                                join y in gradeRead on x.CourseId equals y.CourseId
                                join z in teacherRead on y.TeacherId equals z.TeacherId
                                where z.TeacherId == teacherId && y.TeacherId == teacherId
                                orderby x.Name ascending
                                select x.Name;

            return returnedValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, double>> GetAllCourseAverageGrade()
        {
            var gradeRead = gradeRepo.ReadAll();
            var courseRead = courseRepo.ReadAll();

            if (gradeRead == null || courseRead == null)
            {
                throw new NullReferenceException();
            }

            var a = from x in gradeRead
                    join y in courseRead on x.CourseId equals y.CourseId
                    group x by y.Name
                    into f
                    select new KeyValuePair<string, double>
                   (
                      f.Key,
                      f.Average(t => t.Grade)

                   );

            return a;
        }


        //születési évekre leosztva, milyen átlagot értek el a hallgatók
        public IEnumerable<KeyValuePair<int, double>> GetAverageGradeByDateOfBirth()
        {
            var gradeRead = gradeRepo.ReadAll();
            var studentRead = studRepo.ReadAll();

            if (gradeRead == null || studentRead == null)
            {
                throw new NullReferenceException();
            }

            return from x in gradeRead
                   join y in studentRead on x.NeptunId equals y.NeptunId
                   group x by y.DateOfBirth.Year
                    into f
                   select new KeyValuePair<int, double>
                  (
                     f.Key,
                     f.Average(t => t.Grade)
                  );

        }


        #endregion    
    }
}
