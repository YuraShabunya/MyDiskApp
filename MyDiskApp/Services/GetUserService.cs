using MyDiskApp.Services.Interface;
using MyDiskEF;
using MyDiskEF.Models;

namespace MyDiskApp.Services
{
    public class GetUserService : IGetUser
    {
        private readonly UserContext _context;

        public GetUserService(UserContext context)
        {
            _context = context;
        }

        public User GetUser(string login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == login);
            if (user == null)
                return null;

            var userServiceInformations = _context.UserServiceInformations.FirstOrDefault(id => id.Id == user.Id);
            var userExtraInformation = _context.UserExtraInformations.FirstOrDefault(id => id.Id == user.Id);

            if (userExtraInformation == null)
                if (userServiceInformations == null) 
                    return user;
            return user;
        }
    }
}
