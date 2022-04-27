using FO74EQ_HFT_2021222.Models;
using FO74EQ_HFT_2021222.Repository.Database;
using FO74EQ_HFT_2021222.Repository.Generic_Repository;
using FO74EQ_HFT_2021222.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO74EQ_HFT_2021222.Repository.Model_Repository
{
    public class StudentRepository : Repository<Student>, IRepository<Student>
    {
        public StudentRepository(NeptunDbContext ctx) : base(ctx)
        {

        }

        public override void Update(Student item)
        {
            //var old = 1; //TODO
            var old = Read(item.NeptunId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }

        public override Student Read(int id) //TODO
        {
            throw new NotImplementedException();
            //return ctx.Student.FirstOrDefault(t => t.NeptunId == id); //TODO
            //return null;
        }

        public Student Read(string id)
        {
            return ctx.Student.FirstOrDefault(t => t.NeptunId == id);
        }
    }
}
