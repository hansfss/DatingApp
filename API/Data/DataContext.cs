using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class DataContext : DbContext//instance of DbContext can be used to query and save intances of entities (entity framework)
    {
        public DbSet<AppUser> Users { get; set; }//DbSet takes the type of the class we want to create a database set for
        
        public DataContext(DbContextOptions options) : base(options)//constructor
        {

        }
    }
}
//DataContext class acts as the bridge b/w our code and the database
//DataContext needs to be injected into other parts of the application, service needs to be added the Startup class inside ConfigureServices()