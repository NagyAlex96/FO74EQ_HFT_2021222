using FO74EQ_HFT_2021222.Logic.Interfaces;
using FO74EQ_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FO74EQ_HFT_2021222.Endpoint.Controllers
{
    public class GradeBookController : Controller
    {
		IGradeBook logic;

        public GradeBookController(IGradeBook logic)
        {
            this.logic = logic;
        }

        // GET: GradeBookController
        [HttpGet]
		public IEnumerable<GradeBook> Get()
		{
			return logic.ReadAll();
		}

		// GET: one
		[HttpGet("{id}")]
		public GradeBook Get(int id)
		{
			return logic.Read(id);
		}

		// POST:
		[HttpPost]
		public void Post([FromBody] GradeBook value)
		{
			logic.Create(value);
		}

		// PUT:
		[HttpPut("{id}")]
		public void Put([FromBody] GradeBook value)
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
