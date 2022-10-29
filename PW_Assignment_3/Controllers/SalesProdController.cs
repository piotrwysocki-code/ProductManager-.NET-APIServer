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
    public class SalesProdController : ControllerBase
    {
        private ISalesProdRepo repo;

        public SalesProdController(ISalesProdRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<SalesProd>> GetSalesProd()
        {
            return Ok(repo.SalesProds);
        }


        [HttpGet("{id}")]
        public ActionResult<List<SalesProd>> GetSalesProd(int id)
        {
            if (id == 0)
            {
                return BadRequest("Value must be passed in the request body");
            }
            return Ok(repo[id]);
        }


        [HttpGet("{id},{id2}")]
        public ActionResult<SalesProd> GetSalesProdById(int id, int id2)
        {
            if (id != 0 && id2 != 0)
            {
                var temp = repo.getSalesProd(id, id2);
                return Ok(temp);

            }

            return BadRequest("Value must be passed in the request body");

        }


        [HttpPost]
        public SalesProd Post([FromBody] SalesProd salesprod) =>
            repo.AddSalesProd(salesprod);

        [HttpPut]
        public SalesProd Put([FromBody, FromForm] SalesProd prods) =>
            repo.UpdateSalesProd(prods);

        [HttpDelete]
        public void Delete([FromBody] SalesProd prod)
        {
            Console.WriteLine("Hello?");
            repo.RemoveSalesProd(prod.SaleId, prod.ProductId);
        }
        


        [HttpPatch("{id},{id2}")]
        public StatusCodeResult Patch(int id, int id2, [FromBody] JsonPatchDocument<SalesProd> patchDocument)
        {
            var res = (SalesProd)((OkObjectResult)GetSalesProdById(id, id2).Result).Value;
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
