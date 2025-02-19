using Microsoft.EntityFrameworkCore;

namespace testRedis.data
{
    public class AppDbContext :DbContext 
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<models.Product> Products { get; set; }
        public DbSet<models.Category> Categories { get; set; }


    }
}
