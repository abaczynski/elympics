using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Elympics.Data;
public class RandomNumberDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public RandomNumberDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public DbSet<RandomNumber> Numbers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));

    [PrimaryKey("NumberId")]
    public class RandomNumber
    {
        public int NumberId { get; set; }
        public int NumberValue { get; set; }
    }

}
