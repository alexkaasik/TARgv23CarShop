using TARgv23CarShop.Core.Domain;
using TARgv23CarShop.Core.Dto;
using TARgv23CarShop.Core.ServiceInterface;
using TARgv23CarShop.Data.Migrations;

namespace TARgv23CarShop.CarTest
{
    public class CarTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyCar_WhenReturnResult()
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
    }
}