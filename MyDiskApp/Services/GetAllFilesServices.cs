using MyDiskApp.Services.Interface;
using MyDiskEF;
using MyDiskEF.Models;

namespace MyDiskApp.Services
{
    public class GetAllFilesServices : IGetAllFiles
    {
        private readonly UserContext _context;
        public GetAllFilesServices(UserContext context)
        {
            _context = context;
        }

        public List<UserFile> GetAllFiles(int userId)
        {
            return _context.Files.ToList().FindAll(f => f.UserId == userId);
        }
    }
}
