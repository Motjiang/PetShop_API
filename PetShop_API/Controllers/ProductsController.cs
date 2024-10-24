using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop_API.Data;
using PetShop_API.DTOs;
using PetShop_API.Models.Domain;
using PetShop_API.Repository.Interface;

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
        public async Task<IActionResult> AddProduct(ProductRequestDto request)
        {
            var product = new ProductEntity
            {
                Brand = request.Brand,
                Title = request.Title
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return Ok("Product Saved Successfully");
        }
    }
}
