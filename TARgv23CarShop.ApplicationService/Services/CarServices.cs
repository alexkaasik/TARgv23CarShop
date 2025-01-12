﻿using Microsoft.EntityFrameworkCore;

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

        public async Task<Car> Create(CarDto dto)
        {
            Car car = new();

            car.CarId = Guid.NewGuid();
            car.CarName = dto.CarName;
            car.CarPrice = dto.CarPrice;
            car.CarYear = dto.CarYear;
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;
            

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }
    }
}
