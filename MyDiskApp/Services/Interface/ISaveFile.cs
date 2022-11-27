using MyDiskEF.Models;

namespace MyDiskApp.Services.Interface
{
    public interface ISaveFile
    {
        public UserFile Save(User user, string name);
    }
}
