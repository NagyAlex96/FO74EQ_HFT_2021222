using FO74EQ_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO74EQ_HFT_2021222.Logic.Interfaces
{
    public interface ICourse
    {
        void Create(Course item);
        void Delete(int id);
        Course Read(int id);
        IQueryable<Course> ReadAll();
        void Update(Course item);
    }
}
