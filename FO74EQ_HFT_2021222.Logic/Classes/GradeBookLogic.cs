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
        IRepository<GradeBook> repo;

        public GradeBookLogic(IRepository<GradeBook> repository)
        {
            this.repo = repository;
        }

        public void Create(GradeBook item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public GradeBook Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<GradeBook> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(GradeBook item)
        {
            this.repo.Update(item);
        }
    }
}
