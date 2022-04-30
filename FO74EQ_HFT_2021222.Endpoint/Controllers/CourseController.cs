using FO74EQ_HFT_2021222.Logic.Interfaces;
using FO74EQ_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FO74EQ_HFT_2021222.Endpoint.Controllers
{
    public class CourseController : Controller
    {
		ICourseLogic logic;
        public CourseController(ICourseLogic logic)
        {
            this.logic = logic;
        }

        // GET: 
        [HttpGet]
		public IEnumerable<Course> Get()
		{
			return logic.ReadAll();
		}

		// GET: one
		[HttpGet("{id}")]
		public Course Get(int id)
		{
			return logic.Read(id);
		}

		// POST:
		[HttpPost]
		public void Post([FromBody] Course value)
		{
			logic.Create(value);
		}

		// PUT:
		[HttpPut("{id}")]
		public void Put([FromBody] Course value)
		{
			logic.Update(value);
		}

		// DELETE:
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			logic.Delete(id);
		}
	}
}
