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
    public class TeacherLogic : ITeacherLogic
    {
        IRepository<Teacher> repo;

        public TeacherLogic(IRepository<Teacher> repository)
        {
            this.repo = repository;
        }

        #region CRUD
        public void Create(Teacher item)
        {

            if (item.TeacherId < 1 || item.FirstName == "" || item.LastName == "" || item.Salary < 0)
            {
                throw new Exception("Hibásan töltötte ki a tanár adatait");
            }

            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Teacher Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Teacher> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Teacher item)
        {
            this.repo.Update(item);
        }

        #endregion    
    }
}
