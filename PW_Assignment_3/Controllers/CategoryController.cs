using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PW_Assignment_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PW_Assignment_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepo repo;

        public CategoryController(ICategoryRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Category>> GetCategory()
        {
            System.Diagnostics.Debug.WriteLine("Hello from get all");
            return Ok(repo.Categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body");
            }
            return Ok(repo[id]);
        }

        [HttpPost]
        public Category Post([FromBody] Category category) =>
            repo.AddCategory(category);

        [HttpPost("{name}")]
        public Category Post(string name)
        {
            Category temp = repo.AddCategoryByName(name);
            return temp;
        }

        [HttpPut]
        public Category Put([FromBody, FromForm] Category category) =>
            repo.UpdateCategory(category);

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {

            if (repo.RemoveCategory(id))
            {
                return Ok();
            }

            return Conflict();
        }


        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, [FromBody] JsonPatchDocument<Category> patchDocument)
        {
            var res = (Category)((OkObjectResult)GetCategory(id).Result).Value;
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
