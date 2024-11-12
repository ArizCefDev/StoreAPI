using Microsoft.EntityFrameworkCore;
using StoreAPI.Model.Entity;

namespace StoreAPI.Model.Context
{
    public class AppDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
        {

        }
    }
}
