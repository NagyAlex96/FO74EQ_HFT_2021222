using FO74EQ_HFT_2021222.Logic.Interfaces;
using FO74EQ_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FO74EQ_HFT_2021222.Endpoint.Controllers
{
    public class StudentController : Controller
    {
		IStudent logic;

        public StudentController(IStudent logic)
        {
            this.logic = logic;
        }

        // GET: 
        [HttpGet]
		public IEnumerable<Student> Get()
		{
			return logic.ReadAll();
		}

		// GET: one
		[HttpGet("{id}")]
		public Student Get(int id)
		{
			return logic.Read(id);
		}

		// POST:
		[HttpPost]
		public void Post([FromBody] Student value)
		{
			logic.Create(value);
		}

		// PUT:
		[HttpPut("{id}")]
		public void Put([FromBody] Student value)
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
