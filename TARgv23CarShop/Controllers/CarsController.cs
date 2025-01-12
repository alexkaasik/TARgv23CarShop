using Microsoft.AspNetCore.Mvc;
using TARgv23CarShop.Models.Car;
using TARgv23CarShop.Data;

namespace TARgv23CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly TARgv23CarShopContext _context;

        public CarsController(TARgv23CarShopContext context) { _context = context; }

        public IActionResult Index()
        {
            var result = _context.Cars
                .Select(x => new CarIndexViewModel
                {
                    CarId = x.CarId,
                    CarName = x.CarName,
                    CarPrice = x.CarPrice,
                    CarYear = x.CarYear,

                });

            return View(result);
        }
    }
}