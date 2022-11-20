using FO74EQ_HFT_2021222.Endpoint.Services;
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
    public class StudentController : Controller
    {
        IStudentLogic logic;
        IHubContext<SignalRHub> Hub;

        public StudentController(IStudentLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.Hub = hub;
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
            this.Hub.Clients.All.SendAsync("StudentCreated", value);
        }

        // PUT:
        [HttpPut]
        public void Put([FromBody] Student value)
        {
            logic.Update(value);
            this.Hub.Clients.All.SendAsync("StudentUpdated", value);
        }

        // DELETE:
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var temp = this.logic.Read(id);
            logic.Delete(id);
            this.Hub.Clients.All.SendAsync("StudentDeleted", temp);
        }
    }
}
