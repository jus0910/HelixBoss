using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelixBoss.BusinessEntity;
using HelixBoss.Interfaces;
using HelixBoss.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelixBoss.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService<Product> _service;

        public ProductsController(IProductService<Product> service)
        {
            _service = service;
        }

        // GET: api/Products
        [HttpGet]
        public ProductBE<Product> Get()
        {
            var result = new ProductBE<Product>();
            result.Product = _service.GetAllAsync().Result.ToArray();

            return result;
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var result = new ProductBE<Product>();
            var prd = await _service.GetAsync(id);

            if(prd == null)
            {
                return NotFound();
            }
            result.Product = new Product[] { prd };

            return Ok(result);
        }
        
        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            value = await _service.CreateAsync(value);

            return CreatedAtAction("Get", new { id = value.Id }, new ProductBE<Product> { Product = new Product[] { value } } );
        }
        
        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Product value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != value.Id)
            {
                return BadRequest("Id from URL does not match request");
            }

            if (!ProductExists(id))
            {
                return NotFound();
            }  

            var result = await _service.UpdateAsync(value);
            
            return Ok(result);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prd = await _service.DeleteAsync(id);
            if (prd == null)
            {
                return NotFound();
            }

            return Ok(prd);
        }

        private bool ProductExists(int id)
        {
            var result = _service.GetAsync(id).Result;
            return result != null;
        }
    }
}
