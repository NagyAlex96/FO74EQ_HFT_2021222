using FO74EQ_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FO74EQ_HFT_2021222.Logic.Interfaces
{
    public interface IStudent
    {
        void Create(Student item);
        void Delete(int id);
        Student Read(int id);
        IQueryable<Student> ReadAll();
        void Update(Student item);
    }
}
