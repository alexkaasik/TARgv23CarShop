using Microsoft.EntityFrameworkCore;

namespace TARgv23CarShop.Data
{
    public class TARgv23CarShopContext : DbContext
    {
        public TARgv23CarShopContext(DbContextOptions<TARgv23CarShopContext> options) : base(options) { }
    }
}
