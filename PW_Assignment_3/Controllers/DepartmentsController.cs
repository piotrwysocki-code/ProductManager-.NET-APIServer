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
    public class DepartmentsController : ControllerBase
    {
        private IDepartmentRepo repo;

        public DepartmentsController(IDepartmentRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Department>> GetDepartment()
        {
            return Ok(repo.Departments);
        }


        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartment(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body");
            }
            return Ok(repo[id]);
        }

        [HttpPost("{name}")]
        public Department Post(string name) {
            Department temp = repo.AddDepartmentByName(name);
            return temp;
        }   

        [HttpPost]
        public Department Post([FromBody] Department dept)
        {
            repo.AddDepartment(dept);
            return dept;
        }
 

        [HttpPut]
        public Department Put([FromBody, FromForm] Department department) =>
            repo.UpdateDepartment(department);


        [HttpDelete("{id}")]
        public void Delete(int id) => repo.RemoveDepartment(id);


        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, [FromBody] JsonPatchDocument<Department> patchDocument)
        {
            var res = (Department)((OkObjectResult)GetDepartment(id).Result).Value;
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
