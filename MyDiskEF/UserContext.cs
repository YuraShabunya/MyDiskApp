using Microsoft.EntityFrameworkCore;
using MyDiskEF.Models;

namespace MyDiskEF
{
    public class UserContext : DbContext
    {
        public DbSet<Loggy> Loggies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserExtraInformation> UserExtraInformations { get; set; }
        public DbSet<UserFile> Files { get; set; }
        public DbSet<UserServiceInformation> UserServiceInformations { get; set; }
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
