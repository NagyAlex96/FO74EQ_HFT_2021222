using FO74EQ_HFT_2021222.Logic.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FO74EQ_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NonCrudController : Controller
    {
        GradeBookLogic logic;

        public NonCrudController(GradeBookLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> GetAllStudentAverageGrade()
        {
            return this.logic.GetAllStudentAverageGrade();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> GetAverageRatingOfTeacher()
        {
            return logic.GetAverageRatingOfTeacher();
        }

        [HttpGet("{teacherId}")]
        public IEnumerable<string> GetCourseByTeacher(int teacherId)
        {
            return this.logic.GetCourseByTeacher(teacherId);
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> GetAllCourseAverageGrade()
        {
            return logic.GetAllCourseAverageGrade();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<int, double>> GetAverageGradeByDateOfBirth()
        {
            return logic.GetAverageGradeByDateOfBirth();
        }
    }
}
