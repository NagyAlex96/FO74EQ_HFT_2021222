﻿using FO74EQ_HFT_2021222.Logic.Interfaces;
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
        //TODO minden osztálynak kell, hogy legyen 5 Non-crud metódusa, vagy összesen kell 5?

        IRepository<Student> studRepo; //for nonCrud methods
        IRepository<Teacher> teachRepo; //for nonCrud methods

        public GradeBookLogic(IRepository<GradeBook> repository)
        {
            this.gradeRepo = repository;
        }

        public GradeBookLogic(IRepository<GradeBook> gradeRepo, IRepository<Student> studRepo)
        {
            this.gradeRepo = gradeRepo;
            this.studRepo = studRepo;
        }

        public GradeBookLogic(IRepository<GradeBook> gradeRepo, IRepository<Teacher> teachRepo)
        {
            this.gradeRepo = gradeRepo;
            this.teachRepo = teachRepo;
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

        public IEnumerable<KeyValuePair<string, double>> GetAllStudentAverageGrade()
        {
            //TODO: hibakezelést érdemes megcsinálni?
            var gradeRead = gradeRepo.ReadAll();
            var studRead = studRepo.ReadAll();


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


            return from x in gradeRead
                   join y in teacherRead on x.TeacherId equals y.TeacherId
                   group x by y.TeacherId
                   into f
                   select new KeyValuePair<string, double>
                   (
                       f.Key.ToString(),
                       f.Average(t => t.Rating)
                   );
            ;
        }


        #endregion    
    }
}
