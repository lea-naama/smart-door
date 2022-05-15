using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartDoorServer.Entities;
using Entities.DTO;
using AutoMapper;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartDoorServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        ILogInBL _logInBL;
        IMapper _mapper;
        public LogInController(ILogInBL logInBL, IMapper mapper)
        {
            _logInBL = logInBL;
            _mapper = mapper;
        }
        // GET: api/<LogInController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LogInController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LogInController>
        [HttpPost]
        public async Task<IActionResult> GetUser([FromBody] LogInRequest request)
        {
            try
            {
                LogInResponse response = await _logInBL.GetUser(request.UserName, request.Password);
                //EmployeeDTO employeeDTO = _mapper.Map<EmployeeDTO>(employee);
                if (response.User == null)
                {
                    return new StatusCodeResult(StatusCodes.Status204NoContent);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<LogInController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LogInController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
