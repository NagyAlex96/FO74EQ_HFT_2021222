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
    public class GradeBookRepository : Repository<GradeBook>, IRepository<GradeBook>
    {
        public GradeBookRepository(NeptunDbContext ctx) : base(ctx)
        {
        }

        public override GradeBook Read(int id)
        {
            return ctx.GradeBook.FirstOrDefault(t => t.GradeBookId == id);
        }

        public override void Update(GradeBook item)
        {
            var old = Read(item.GradeBookId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
