﻿using FO74EQ_HFT_2021222.Logic.Interfaces;
using FO74EQ_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FO74EQ_HFT_2021222.Endpoint.Controllers
{
	[Route("[controller]")]
	[ApiController]

	//ClassRoom
	public class ClassRoomController : Controller
    {
        IClassRoomLogic logic;

        public ClassRoomController(IClassRoomLogic logic)
        {
            this.logic = logic;
        }

		// GET: 
		[HttpGet]
		public IEnumerable<ClassRoom> Get()
		{
			return logic.ReadAll();
		}

		// GET: one
		[HttpGet("{id}")]
		public ClassRoom Get(int id)
		{
			return logic.Read(id);
		}

		// POST:
		[HttpPost]
		public void Post([FromBody] ClassRoom value)
		{
			logic.Create(value);
		}

		// PUT:
		[HttpPut]
		public void Put([FromBody] ClassRoom value)
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
