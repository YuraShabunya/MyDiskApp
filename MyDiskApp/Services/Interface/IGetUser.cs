using MyDiskEF.Models;

namespace MyDiskApp.Services.Interface
{
    public interface IGetUser
    {
        public User GetUser(string login);
    }
}
