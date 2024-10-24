using PetShop_API.Data;
using PetShop_API.Models.Domain;
using PetShop_API.Repository.Interface;

namespace PetShop_API.Repository.Implementatioon
{
    public class ProductEntityRepository : IProductEntityRepository
    {
        //Dependency Injection
        private readonly ApplicationDbContext _context;

        //Constructor
        public ProductEntityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductEntity> AddProduct(ProductEntity product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public Task<ProductEntity> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductEntity> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductEntity>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductEntity> UpdateProduct(ProductEntity product)
        {
            throw new NotImplementedException();
        }
    }
}
