﻿using FO74EQ_HFT_2021222.Logic.Interfaces;
using FO74EQ_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FO74EQ_HFT_2021222.Endpoint.Controllers
{
    public class TeacherController : Controller
    {
		ITeacher logic;

        public TeacherController(ITeacher logic)
        {
            this.logic = logic;
        }

        // GET: 
        [HttpGet]
		public IEnumerable<Teacher> Get()
		{
			return logic.ReadAll();
		}

		// GET: one
		[HttpGet("{id}")]
		public Teacher Get(int id)
		{
			return logic.Read(id);
		}

		// POST:
		[HttpPost]
		public void Post([FromBody] Teacher value)
		{
			logic.Create(value);
		}

		// PUT:
		[HttpPut("{id}")]
		public void Put([FromBody] Teacher value)
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
