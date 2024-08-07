using InnoApi.Models;
using Microsoft.EntityFrameworkCore;
namespace InnoApi.Controllers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) 
            :base(dbContextOptions)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
