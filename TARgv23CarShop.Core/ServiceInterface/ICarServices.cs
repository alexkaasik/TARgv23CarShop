using TARgv23CarShop.Core.Domain;
using TARgv23CarShop.Core.Dto;

namespace TARgv23CarShop.Core.ServiceInterface
{
    public interface ICarServices
    {
        Task<Car> DetailsAsync(Guid id);

        Task<Car> Create(CarDto dto);

        Task<Car> Update(CarDto dto);
    }
}
