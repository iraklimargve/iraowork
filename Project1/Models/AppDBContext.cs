using Microsoft.EntityFrameworkCore;

namespace Project1.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<TestModel> TestModels { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<MarketCompany> MarketCompanies { get; set; }
    }
}
