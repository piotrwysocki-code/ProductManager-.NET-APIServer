using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PW_Assignment_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PW_Assignment_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepo repo;

        public EmployeesController(IEmployeeRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetEmployee()
        {
            return Ok(repo.Employees);
        }


        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body");
            }
            return Ok(repo[id]);
        }

        [HttpPost]
        public Employee Post([FromBody] Employee employee) =>
            repo.AddEmployee(employee);

        [HttpPut]
        public Employee Put([FromBody, FromForm] Employee employee) =>
            repo.UpdateEmployee(employee);

        [HttpDelete("{id}")]
        public void Delete(int id) => repo.RemoveEmployee(id);


        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, [FromBody] JsonPatchDocument<Employee> patchDocument)
        {
            var res = (Employee)((OkObjectResult)GetEmployee(id).Result).Value;
            if (res != null)
            {
                patchDocument.ApplyTo(res);
                repo.saveDbChanges();
                return Ok();
            }
            return NotFound();
        }
    }
    
}
