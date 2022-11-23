using MyDiskEF.Models;

namespace MyDiskApp.Services.Interface
{
    public interface IGetAllFiles
    {
        public List<UserFile> GetAllFiles(int userId);
    }
}
