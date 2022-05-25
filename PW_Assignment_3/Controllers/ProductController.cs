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
    public class ProductController : ControllerBase
    {
        private IProductRepo repo;

        public ProductController(IProductRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProduct()
        {
            return Ok(repo.Products);
        }


        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body");
            }
            return Ok(repo[id]);
        }
        
        [HttpPost]
        public Product Post([FromBody] Product product) =>
            repo.AddProduct(product);

        [HttpPut]
        public Product Put([FromForm] Product product) =>
            repo.UpdateProduct(product);

        [HttpDelete("{id}")]
        public void Delete(int id) => repo.RemoveProduct(id);


        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, [FromBody] JsonPatchDocument<Product> patchDocument)
        {
            var res = (Product)((OkObjectResult)GetProduct(id).Result).Value;
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
