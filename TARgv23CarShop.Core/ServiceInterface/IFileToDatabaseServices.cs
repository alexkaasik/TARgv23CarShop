using TARgv23CarShop.Core.Domain;
using TARgv23CarShop.Core.Dto;

namespace TARgv23CarShop.Core.ServiceInterface
{
    public interface IFileToDatabaseServices
    {
        void UploadFilesToDatabase(CarDto dto, Car domain);
    }
}
