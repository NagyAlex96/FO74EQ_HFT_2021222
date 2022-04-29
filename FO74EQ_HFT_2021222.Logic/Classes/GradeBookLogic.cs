using FO74EQ_HFT_2021222.Logic.Interfaces;
using FO74EQ_HFT_2021222.Models;
using FO74EQ_HFT_2021222.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FO74EQ_HFT_2021222.Logic.Classes
{
    public class GradeBookLogic : IGradeBook
    {
        IRepository<GradeBook> gradeRepo;
        //TODO érdemes létrehozni?
        //IRepository<Student> studRepo; //for nonCrud methods

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

        #region Non-Crud

        public IEnumerable<Student> GetAverageOfSelectedStudent(int teacherId)
        {
            //TODO: hibakezelés
            var gradeRead = gradeRepo.ReadAll();
            List<Student> selectedStudents = new List<Student>();

            foreach (var grade in gradeRead)
            {
                if (teacherId == grade.TeacherId)
                {
                    foreach (var student in gradeRead)
                    {
                        selectedStudents.Add(student.Neptun);
                    }
                }
            }

            return selectedStudents;
        }

        #endregion    
    }
}
