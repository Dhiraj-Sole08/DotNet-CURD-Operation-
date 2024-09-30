using AssignmentApp.DBMapper;
using AssignmentApp.DTOs;
using AssignmentApp.Models;
using AssignmentApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssignmentApp.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _service.GetProductsAsync();
            return Ok(result);
        }

       

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var product = await _service.AddProductAsync(productDto);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductCreateDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var product = await _service.UpdateProductAsync(id, productDto);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _service.DeleteProductAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
