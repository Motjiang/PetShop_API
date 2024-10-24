using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop_API.Data;
using PetShop_API.DTOs;
using PetShop_API.Models.Domain;

namespace PetShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Dependency Injection
        private readonly ApplicationDbContext _context;

        //Constructor
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequestDto request)
        {
            var product = new ProductEntity()
            {
                Name = request.Brand,
                Description = request.Title,
                Price = request.Price
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return Ok("Product Saved Successfully");
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductEntity>>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductEntity>> GetProductById([FromRoute] long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(a => a.Id == id);

            if (product == null)
            {
                return NotFound("Product Not Found");
            }
            return Ok(product);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] long id, [FromBody] ProductRequestDto request)
        {
            var product = await _context.Products.FirstOrDefaultAsync(a => a.Id == id);

            if (product == null)
            {
                return NotFound("Product Not Found");
            }

            product.Name = request.Brand;
            product.Description = request.Title;
            product.Price = request.Price;
            product.UpdatedAt = DateTime.Now;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return Ok("Product Updated Successfully");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(a => a.Id == id);

            if (product == null)
            {
                return NotFound("Product Not Found");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok("Product Deleted Successfully");
        }
    }
}
