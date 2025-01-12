﻿using Microsoft.AspNetCore.Mvc;
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
    }
}