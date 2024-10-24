using PetShop_API.Models.Domain;

namespace PetShop_API.Repository.Interface
{
    public interface IProductEntityRepository
    {
        Task<IEnumerable<ProductEntity>> GetProducts();
        Task<ProductEntity> GetProduct(int id);
        Task<ProductEntity> AddProduct(ProductEntity product);
        Task<ProductEntity> UpdateProduct(ProductEntity product);
        Task<ProductEntity> DeleteProduct(int id);
    }
}
