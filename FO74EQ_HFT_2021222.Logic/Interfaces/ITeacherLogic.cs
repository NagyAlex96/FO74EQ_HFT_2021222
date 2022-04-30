using FO74EQ_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO74EQ_HFT_2021222.Logic.Interfaces
{
    public interface ITeacherLogic
    {
        void Create(Teacher item);
        void Delete(int id);
        Teacher Read(int id);
        IQueryable<Teacher> ReadAll();
        void Update(Teacher item);
    }
}
