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
    public class CourseRespository : Repository<Course>, IRepository<Course>
    {
        public CourseRespository(NeptunDbContext ctx) : base(ctx)
        {
        }

        public override Course Read(int id)
        {
            return ctx.Course.FirstOrDefault(t => t.CourseId == id);
        }

        public override void Update(Course item)
        {
            var old = Read(item.CourseId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
