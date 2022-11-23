using MyDiskApp.Services.Interface;
using MyDiskEF;

namespace MyDiskApp.Services
{
    public class UserIsExistService : IUserIsExist
    {
        private readonly UserContext _context;
        public UserIsExistService(UserContext context)
        {
            _context = context;
        }

        public bool UserIsExist(string login)
        {
            return !_context.Users.Any(u => u.Login == login);
        }

    }
}
