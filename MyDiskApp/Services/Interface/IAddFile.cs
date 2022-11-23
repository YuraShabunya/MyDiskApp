using MyDiskEF.Models;

namespace MyDiskApp.Services.Interface
{
    public interface IAddFile
    {
        public Task AddFileAsync(User user, IFormFile uploadfile);
    }
}
