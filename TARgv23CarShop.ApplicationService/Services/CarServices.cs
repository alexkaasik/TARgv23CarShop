using Microsoft.EntityFrameworkCore;

using TARgv23CarShop.Data;
using TARgv23CarShop.Core.ServiceInterface;
using TARgv23CarShop.Core.Domain;
using TARgv23CarShop.Core.Dto;

namespace TARgv23CarShop.ApplicationService.Services
{
    public class CarServices : ICarServices
    {
        private readonly TARgv23CarShopContext _context;

        public CarServices
            (
                TARgv23CarShopContext context
            )
        {
            _context = context;
        }

        public async Task<Car> DetailsAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.CarId == id);

            return result;
        }
    }
}
