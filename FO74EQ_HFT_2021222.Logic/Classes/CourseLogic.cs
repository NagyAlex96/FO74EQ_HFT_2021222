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
    public class CourseLogic : ICourseLogic
    {
        IRepository<Course> repo;
        public CourseLogic(IRepository<Course> repository)
        {
            this.repo = repository;
        }

        #region CRUD
        public void Create(Course item)
        {
            if(item.ClassRoomId < 1)
            {
                throw new Exception("ClassRoomId cannot be smaller than 1");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Course Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Course> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Course item)
        {
            this.repo.Update(item);
        } 
        #endregion
    }
}
