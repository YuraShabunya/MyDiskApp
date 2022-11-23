using MyDiskApp.Services.Interface;
using MyDiskApp.ViewModels;
using MyDiskEF;
using MyDiskServices.Helpers;
using MyDiskServices.Interfaces;

namespace MyDiskApp.Services
{
    public class RecoverPasswordService : IRecoverPassword
    {
        private readonly UserContext _context;
        private readonly IHashPassword _hashPassword;
        public RecoverPasswordService(UserContext context, IHashPassword hashPassword)
        {
            _context = context;
            _hashPassword = hashPassword;
        }

        public bool ChangePassword(RecoverModel recover)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == recover.Login);
            if (user != null)
            {
                var Service = _context.UserServiceInformations.FirstOrDefault(sw => sw.Id == user.Id);

                if(Service != null && recover.SecretWord == Service.SecretWord)
                {
                    string newPassword = _hashPassword.GetHash(recover.Password);
                    user.Password = newPassword;
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
