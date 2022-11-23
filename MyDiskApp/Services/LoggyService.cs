using MyDiskApp.Services.Interface;
using MyDiskEF;
using MyDiskEF.Models;

namespace MyDiskApp.Services
{
    public class LoggyService : ILoggy
    {
        private readonly UserContext _context;
        public LoggyService(UserContext context)
        {
            _context = context;
        }

        public async Task AddLogAsync(string login, string message, DateTime dateTime)
        {
            var newLoggy = new Loggy() { Login = login, Action = message, CreatedDate = dateTime };
            _context.Add(newLoggy);
            await _context.SaveChangesAsync();
        }
    }
}
