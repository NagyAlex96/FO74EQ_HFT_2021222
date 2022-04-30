using FO74EQ_HFT_2021222.Logic.Interfaces;
using FO74EQ_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FO74EQ_HFT_2021222.Endpoint.Controllers
{
    public class ClassRoomController : Controller
    {
        IClassRoom classRoom;

        public ClassRoomController(IClassRoom classRoom)
        {
            this.classRoom = classRoom;
        }

		// GET: 
		[HttpGet]
		public IEnumerable<ClassRoom> Get()
		{
			return classRoom.ReadAll();
		}

		// GET: one
		[HttpGet("{id}")]
		public ClassRoom Get(int id)
		{
			return classRoom.Read(id);
		}

		// POST:
		[HttpPost]
		public void Post([FromBody] ClassRoom value)
		{
			classRoom.Create(value);
		}

		// PUT:
		[HttpPut("{id}")]
		public void Put([FromBody] ClassRoom value)
		{
			classRoom.Update(value);
		}

		// DELETE:
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			classRoom.Delete(id);
		}
	}
}
