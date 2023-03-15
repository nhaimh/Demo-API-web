using Microsoft.EntityFrameworkCore;

namespace SuperHeroApi.Data
{
    public class DataContext : DbContext
    {
        //public DataContext(DbContextOptions<DataContext> option) : base(option)
        //{

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseNpgsql("Host=localhost;Database=mytesst;Username=postgres;Password=123456");
        //}

        private readonly IConfiguration configuration;
        public DataContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("herodb"));
        }


        public DbSet<SuperHero> SuperHeroes { set; get; }
    }
}
