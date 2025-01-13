using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TARgv23CarShop.Core.Domain;
using TARgv23CarShop.Core.Dto;
using TARgv23CarShop.Core.ServiceInterface;
using TARgv23CarShop.Data;

namespace TARgv23CarShop.ApplicationService.Services
{
    public class FileToDatabaseService : IFileToDatabaseServices
    {

        private readonly IHostEnvironment _webHost;
        private readonly TARgv23CarShopContext _context;


        public FileToDatabaseService(IHostEnvironment webHost, TARgv23CarShopContext context)
        {
            _webHost = webHost;
            _context = context;
        }

        public void UploadFilesToDatabase(CarDto dto, Car domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var image in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            CarId = domain.CarId
                        };

                        image.CopyTo(target);
                        files.ImageData = target.ToArray();

                        _context.FileToDatabase.Add(files);
                    }
                }
            }
        }

		public async Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto)    
		{
			var image = await _context.FileToDatabase
				.Where(x => x.Id == dto.Id)
				.FirstOrDefaultAsync();

			_context.FileToDatabase.Remove(image);
			await _context.SaveChangesAsync();

			return image;
		}

	}
}
