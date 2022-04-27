using FO74EQ_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO74EQ_HFT_2021222.Logic.Interfaces
{
    public interface IGradeBook
    {
        void Create(GradeBook item);
        void Delete(int id);
        GradeBook Read(int id);
        IQueryable<GradeBook> ReadAll();
        void Update(GradeBook item);
    }
}
