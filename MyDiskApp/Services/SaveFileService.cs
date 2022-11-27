using MyDiskApp.Services.Interface;
using MyDiskEF;
using MyDiskEF.Models;

namespace MyDiskApp.Services
{
    public class SaveFileService : ISaveFile
    {
        private readonly UserContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public SaveFileService(UserContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public UserFile Save(User user, string name)
        {
            UserFile userFile = new UserFile();
            var saveFile = _context.Files.FirstOrDefault(x => x.UserId == user.Id && x.Name == name);
            if (saveFile != null)
            {
                userFile.Name = saveFile.Name;
                userFile.Path = _appEnvironment.WebRootPath + saveFile.Path;
                userFile.ContentType = saveFile.ContentType;
                return userFile;
            }

            return userFile;
        }
    }
}
