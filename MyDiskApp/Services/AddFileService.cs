using MyDiskApp.Services.Interface;
using MyDiskEF;
using MyDiskEF.Models;

namespace MyDiskApp.Services
{
    public class AddFileService : IAddFile
    {
        private readonly UserContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public AddFileService(UserContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public async Task AddFileAsync(User user, IFormFile uploadedFile)
        {
            if (!_context.Files.Any(x => x.Name == uploadedFile.FileName))
            {
                var newFile = new UserFile()
                {
                    Name = uploadedFile.FileName,
                    UserId = user.Id,
                    Path = $"\\Files\\{user.CurrentDirectory}\\{uploadedFile.FileName}",
                    ContentType = uploadedFile.ContentType
                };

                if (!Directory.Exists(_appEnvironment.WebRootPath + $"\\Files\\{user.CurrentDirectory}"))
                {
                    Directory.CreateDirectory(_appEnvironment.WebRootPath + $"\\Files\\{user.CurrentDirectory}");
                }

                _context.Files.Add(newFile);
                await _context.SaveChangesAsync();

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + newFile.Path, FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }
            }
        }
    }
}
