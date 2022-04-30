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
    public class StudentLogic : IStudent
    {
        const int youngestStudent = 18;
        IRepository<Student> repo;

        public StudentLogic(IRepository<Student> repository)
        {
            this.repo = repository;
        }

        #region CRUD
        public void Create(Student item)
        {
            int compareResult = DateTime.Compare(item.DateOfBirth, DateTime.Now.AddYears(youngestStudent < 18 ? -18 : youngestStudent));

            bool condition = item.NeptunId == ""
                || item.FirstName == ""
                || item.LastName == ""
                || item.Email == ""
                || compareResult < 1;
            if (condition)
            {
                throw new Exception("Hibás adatbevitel. Az összes adatot ki kell töltenie.");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Student Read(int id) //TODO
        {
            return this.repo.Read(id);
        }

        //public Student Read(string id) //TODO
        //{
        //    return this.repo.Read(id);
        //}

        public IQueryable<Student> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Student item)
        {
            this.repo.Update(item);
        }

        #endregion    
    }
}
