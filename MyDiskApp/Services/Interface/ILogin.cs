using MyDiskApp.ViewModels;
using MyDiskEF.Models;

namespace MyDiskApp.Services.Interface
{
    public interface ILogin
    {
        public User Login(LoginModel model);
    }
}
