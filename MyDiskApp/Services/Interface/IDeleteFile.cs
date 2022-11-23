using MyDiskEF.Models;

namespace MyDiskApp.Services.Interface
{
    public interface IDeleteFile
    {
        public Task DeleteFileAsync(User user, string name);
    }
}
