using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }
        
        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}