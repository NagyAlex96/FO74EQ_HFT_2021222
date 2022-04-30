using FO74EQ_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO74EQ_HFT_2021222.Logic.Interfaces
{
    public interface IClassRoomLogic
    {
        void Create(ClassRoom item);
        void Delete(int id);
        ClassRoom Read(int id);
        IQueryable<ClassRoom> ReadAll();
        void Update(ClassRoom item);
    }
}
