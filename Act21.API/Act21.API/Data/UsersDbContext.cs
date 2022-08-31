
using Act21.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Act21.API.Data
{
    public class UsersDbContext : DbContext
    {

        
        public UsersDbContext (DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<LoginModel> LoginInfos { get; set; }
    }
}
