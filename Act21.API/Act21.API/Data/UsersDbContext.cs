using Act21.API.Entities;
/*using Act21.API.Models;*/
using Microsoft.EntityFrameworkCore;

namespace Act21.API.Data
{
    public class UsersDbContext : DbContext
    {

        /*private readonly IConfiguration Configuration;*/
        public UsersDbContext (DbContextOptions options) : base(options)
        {
            /*Configuration = configuration;*/
        }

        public DbSet<User> Users { get; set; }

        /*public DbSet<LoginModel> LoginInfos { get; set; }*/
    }
}
