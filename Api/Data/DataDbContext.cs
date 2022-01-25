using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }

        public DbSet<Hero> Heroes { get; set; }
    }
}
