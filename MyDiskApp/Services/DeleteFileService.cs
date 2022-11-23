using MyDiskApp.Services.Interface;
using MyDiskEF;
using MyDiskEF.Models;

namespace MyDiskApp.Services
{
    public class DeleteFileService : IDeleteFile
    {
        private readonly UserContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public DeleteFileService(UserContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public async Task DeleteFileAsync(User user, string name)
        {
            var fileDelete = _context.Files.FirstOrDefault(x => x.UserId == user.Id && x.Name == name);
            if (fileDelete != null)
            {
                File.Delete(_appEnvironment.WebRootPath + fileDelete.Path);
                _context.Files.Remove(fileDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
