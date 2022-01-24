using Microsoft.EntityFrameworkCore;

namespace Dotnet6_WebApiBasic.Data
{
    public class HeroesDbContext : DbContext
    {
        public HeroesDbContext(DbContextOptions<HeroesDbContext> options) : base(options)
        {

        }

        public DbSet<Hero> Heroes { get; set; }
    }
}
