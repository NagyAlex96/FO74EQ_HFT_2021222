using FO74EQ_HFT_2021222.Endpoint.Services;
using FO74EQ_HFT_2021222.Logic.Interfaces;
using FO74EQ_HFT_2021222.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace FO74EQ_HFT_2021222.Endpoint.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class TeacherController : Controller
    {
		ITeacherLogic logic;
        IHubContext<SignalRHub> hub;

        public TeacherController(ITeacherLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
			this.hub = hub;
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
            this.hub.Clients.All.SendAsync("TeacherCreated", value);

        }

        // PUT:
        [HttpPut]
		public void Put([FromBody] Teacher value)
		{
			logic.Update(value);
            this.hub.Clients.All.SendAsync("TeacherUpdated", value);

        }

        // DELETE:
        [HttpDelete("{id}")]
		public void Delete(int id)
		{
            var temp = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("TeacherDeleted", temp);
        }
	}
}
