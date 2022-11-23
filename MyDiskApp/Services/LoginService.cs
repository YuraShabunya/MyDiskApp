using MyDiskApp.Services.Interface;
using MyDiskApp.ViewModels;
using MyDiskEF;
using MyDiskEF.Models;
using MyDiskServices.Helpers;
using MyDiskServices.Interfaces;

namespace MyDiskApp.Services
{
    public class LoginService : ILogin
    {
        private readonly UserContext _context;
        private readonly IHashPassword _hashPassword; 
        public LoginService(UserContext context, IHashPassword hashPassword)
        {
            _context = context;
            _hashPassword = hashPassword;
        }
        public User Login(LoginModel model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == model.Login
                                            && u.Password == _hashPassword.GetHash(model.Password));

            return user;
        }
    }
}
