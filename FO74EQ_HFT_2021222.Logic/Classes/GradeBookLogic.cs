using FO74EQ_HFT_2021222.Logic.Interfaces;
using FO74EQ_HFT_2021222.Models;
using FO74EQ_HFT_2021222.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO74EQ_HFT_2021222.Logic.Classes
{
    public class GradeBookLogic : IGradeBook
    {
        IRepository<GradeBook> gradeRepo;
        IRepository<Student> studRepo; //for nonCrud methods

        public GradeBookLogic(IRepository<GradeBook> repository)
        {
            this.gradeRepo = repository;
        }

        #region CRUD
        public void Create(GradeBook item)
        {
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

        //adott tanárhoz tartozó diákok neve
        public IEnumerable<Student> GetAverageOfSelectedStudent(int teacherId)
        {
            var temp = gradeRepo.ReadAll();
            List<Student> vissza = new List<Student>();
            foreach (var grade in temp)
            {
                if (teacherId == grade.TeacherId)
                {
                    foreach (var student in temp)
                    {
                        vissza.Add(student.Neptun);
                    }
                }
            }

            //var Q3 = from x in gradeRepo.ReadAll()
            //         join y in studRepo.ReadAll()
            //         on x.NeptunId equals y.NeptunId
            //         orderby y.NeptunId descending
            //         select new Student()
            //         {
            //             FirstName = $"{y.FirstName}{y.LastName}",
            //             Average = gradeRepo.ReadAll().
            //             Average(r => r.Rating),
            //         };

            //var Q3 = from x in gradeRepo.ReadAll()
            //         join y in studRepo.ReadAll()
            //         on x.NeptunId equals y.NeptunId
            //         orderby y.NeptunId descending
            //         select new
            //         {
            //             FullName = $"{y.FirstName}{y.LastName}",
            //             Average = gradeRepo.ReadAll().
            //             Average(r => r.Rating),
            //         };

            return null;
        }
    }
}
