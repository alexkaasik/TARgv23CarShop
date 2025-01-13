using Microsoft.AspNetCore.Http;

namespace TARgv23CarShop.Core.Dto
{
    public class CarDto
    {
        public Guid? CarId { get; set; }

        public string? CarName { get; set; }

        public float? CarPrice { get; set; }

        public DateTime? CarYear { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public List<IFormFile> Files { get; set; }

        public IEnumerable<FileToDatabaseDto> Image { get; set; }
            = new List<FileToDatabaseDto>();
    }
}
