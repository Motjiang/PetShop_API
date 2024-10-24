using Microsoft.EntityFrameworkCore;
using PetShop_API.Models.Domain;

namespace PetShop_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }    
}
