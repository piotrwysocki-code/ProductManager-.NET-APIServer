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
    public class SalesController : ControllerBase
    {
        private ISalesRepo repo;

        public SalesController(ISalesRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Sale>> GetSale()
        {
            return Ok(repo.Sales);
        }


        [HttpGet("{id}")]
        public ActionResult<Sale> GetSale(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body");
            }
            return Ok(repo[id]);
        }

        [HttpPost]
        public Sale Post([FromBody] Sale sale) =>
            repo.AddSale(sale);

        [HttpPut]
        public Sale Put([FromBody, FromForm] Sale sale) =>
            repo.UpdateSale(sale);

        [HttpDelete("{id}")]
        public void Delete(int id) => repo.RemoveSale(id);


        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, [FromBody] JsonPatchDocument<Sale> patchDocument)
        {
            var res = (Sale)((OkObjectResult)GetSale(id).Result).Value;
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
