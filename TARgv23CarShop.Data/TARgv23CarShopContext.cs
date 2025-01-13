using Microsoft.EntityFrameworkCore;
using TARgv23CarShop.Core.Domain;

namespace TARgv23CarShop.Data
{
    public class TARgv23CarShopContext : DbContext
    {
        public TARgv23CarShopContext(DbContextOptions<TARgv23CarShopContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }

        public DbSet<FileToDatabase> FileToDatabase { get; set; }

        
    }
}
