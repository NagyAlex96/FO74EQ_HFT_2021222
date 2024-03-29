﻿using FO74EQ_HFT_2021222.Endpoint.Services;
using FO74EQ_HFT_2021222.Logic.Interfaces;
using FO74EQ_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace FO74EQ_HFT_2021222.Endpoint.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class GradeBookController : Controller
    {
		IGradeBookLogic logic;
        IHubContext<SignalRHub> hub;


        public GradeBookController(IGradeBookLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
			this.hub = hub;
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
            this.hub.Clients.All.SendAsync("GradeBookCreated", value);
        }

        // PUT:
        [HttpPut]
		public void Put([FromBody] GradeBook value)
		{
			logic.Update(value);
            this.hub.Clients.All.SendAsync("GradeBookUpdated", value);
        }

        // DELETE:
        [HttpDelete("{id}")]
		public void Delete(int id)
		{
            var temp = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("GradeBookDeleted", temp);
        }
    }
}
