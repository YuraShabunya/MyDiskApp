using MyDiskApp.Services.Interface;
using MyDiskApp.ViewModels;
using MyDiskEF;
using MyDiskEF.Models;
using MyDiskServices.Helpers;
using MyDiskServices.Interfaces;

namespace MyDiskApp.Services
{
    public class AddUserService : IAddUser
    {
        private readonly UserContext _context;
        private readonly IHashPassword _hashPassword;

        public AddUserService(UserContext context, IHashPassword hashPassword)
        {
            _context = context;
            _hashPassword = hashPassword;
        }

        public void AddUser(RegisterModel model)
        {
            var newUser = new User
            {
                Login = model.Login,
                Password = _hashPassword.GetHash(model.Password),
                CurrentDirectory = model.Login,
                userExtraInformation = new UserExtraInformation { FirstName = model.FirstName, LastName = model.LastName, Birthday = model.Birthday },
                userServiceInformation = new UserServiceInformation { Email = model.Email, SecretWord = model.SecretWord, CreatedDate = DateTime.Today },
            };

            _context.Add(newUser);
            _context.SaveChanges();
        }
    }
}
