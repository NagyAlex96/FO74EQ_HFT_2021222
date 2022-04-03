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
    public class ClassRoomRepository : Repository<ClassRoom>, IRepository<ClassRoom>
    {
        public ClassRoomRepository(NeptunDbContext ctx) : base(ctx)
        {
        }

        public override ClassRoom Read(int id)
        {
            return ctx.ClassRoom.FirstOrDefault(t => t.ClassRoomId == id);
        }

        public override void Update(ClassRoom item)
        {
            var old = Read(item.ClassRoomId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
