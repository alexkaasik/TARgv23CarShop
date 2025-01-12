using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARgv23CarShop.Data;
using TARgv23CarShop.Core.ServiceInterface;
using TARgv23CarShop.Core.Domain;
using TARgv23CarShop.Core.Dto;
using TARgv23CarShop.Models.Cars;

namespace TARgv23CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly TARgv23CarShopContext _context;
        private readonly ICarServices _carServices;

        public CarsController
            (
                TARgv23CarShopContext context,
                ICarServices CarServices
            )
        { 
            _context = context;
            _carServices = CarServices;
        }

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

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarDetailsViewModel();

            vm.CarId = car.CarId;
            vm.CarName = car.CarName;
            vm.CarYear = car.CarYear;
            vm.CarPrice = car.CarPrice;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarCreateAndUpdateViewModel car = new();

            return View("CreateAndUpdate", car);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateAndUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                CarId = vm.CarId,
                CarName = vm.CarName,
                CarPrice = vm.CarPrice,
                CarYear = vm.CarYear,
            };

            var result = await _carServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarCreateAndUpdateViewModel();

            vm.CarId = car.CarId;
            vm.CarName = car.CarName;
            vm.CarPrice = car.CarPrice;
            vm.CarYear = car.CarYear;

            return View("CreateAndUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarCreateAndUpdateViewModel vm)
        {
            var dto = new CarDto()
            {

                CarId = vm.CarId,
                CarName = vm.CarName,
                CarPrice = vm.CarPrice,
                CarYear = vm.CarYear,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
            };


            var result = await _carServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarDeleteViewModel();

            vm.CarId = car.CarId;
            vm.CarName = car.CarName;
            vm.CarPrice = car.CarPrice;
            vm.CarYear = car.CarYear;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt; 

            return View(vm);
        }

        [HttpPost]
        // Some reason Id is show's all zero's, need to find a fix later.
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            
            var car = await _carServices.Delete(id);

            if (car == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}