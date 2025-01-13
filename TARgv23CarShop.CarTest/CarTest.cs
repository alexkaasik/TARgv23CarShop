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

        public async Task GetDetails()
        {
            CarDto carDto = MockCarData();
            var car = await Svc<ICarServices>().Create(carDto);

            var result = await Svc<ICarServices>().DetailsAsync((Guid)car.CarId);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateData()
        {

            var guidDb = Guid.Parse("2F39BA90-3C52-4DA9-69EA-08DD33187518");
            var guidNew = Guid.NewGuid();

            CarDto dto = MockCarData();

            Car domain = new();

            domain.CarId = guidNew;
            domain.CarName = "adsg";
            domain.CarPrice = 142;
            domain.CarYear = DateTime.Now;
            domain.CreatedAt = DateTime.UtcNow;
            domain.ModifiedAt = DateTime.UtcNow;

            await Svc<ICarServices>().Update(dto);

            Assert.Equal(domain.CarId, guidNew);
            Assert.DoesNotMatch(domain.CarName, dto.CarName);
            Assert.NotEqual(domain.CarPrice, dto.CarPrice);
            Assert.NotEqual(domain.CarYear, dto.CarYear);

        }

        private CarDto MockCarData()
        {
            CarDto car = new()
            {
                CarName = "asd",
                CarPrice = 123-2f,
                CarYear = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            return car;
        }

        private CarDto MockCarDataToUpdate()
        {
            CarDto car = new()
            {
                CarName = "cna890wp",
                CarPrice = 51097,
                CarYear = DateTime.Now,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            return car;
        }
    }
}