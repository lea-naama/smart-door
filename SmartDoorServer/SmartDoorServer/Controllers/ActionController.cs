using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SmartDoorServer.Entities;
using Action = SmartDoorServer.Entities.Action;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartDoorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        IActionDL _iActionDL;
        SmartDoorContext _smartDoorContext;
        public ActionController(IActionDL iActionDL, SmartDoorContext smartDoorContext)
        {
            _iActionDL = iActionDL;
            _smartDoorContext = smartDoorContext;
            Console.WriteLine( _iActionDL.detectFaces());
            
        }

        // GET: api/<ActionController>
        [HttpGet("{from}/{to}")]
        public List<TableRow> Get(int id, DateTime from, DateTime to)
        {
            List<TableRow> tmp = _iActionDL.GetActionsByDates(id, from, to);
            return tmp;
        }

        // GET api/<ActionController>/5
        [HttpGet]
        public List<Action> Get()
        {
            return _smartDoorContext.Actions.ToList() ;
        }

        // POST api/<ActionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ActionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ActionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
