using System.Xml;
using TARgv23CarShop.Core.Domain;
using TARgv23CarShop.Core.Dto;
using TARgv23CarShop.Core.ServiceInterface;
using TARgv23CarShop.Data.Migrations;

namespace TARgv23CarShop.CarTest
{
    public class CarTest : TestBase
    {
        [Fact]
        public async Task CreateDataTest()
        {
            //Arrange
            CarDto dto = new();

            dto.CarName = "asd";
            dto.CarPrice = 12345 - 2f;
            dto.CarYear = DateTime.Now;
            dto.CreatedAt = DateTime.Now;
            dto.ModifiedAt = DateTime.Now;

            //Act
            var result = await Svc<ICarServices>().Create(dto);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetDetails()
        { 
            CarDto carDto = MockCarData();
            var car = await Svc<ICarServices>().Create(carDto);

            var result = await Svc<ICarServices>().DetailsAsync((Guid)car.CarId);

            Assert.NotNull(result); 
        }



        private CarDto MockCarData()
        {
            CarDto car = new()
            {
                CarName = "asd",
                CarPrice = 100,
                CarYear = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            return car;
        }
    }
}