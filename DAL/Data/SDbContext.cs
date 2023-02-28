using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class SDbContext : DbContext
    {
        public SDbContext(DbContextOptions<SDbContext> options) : base(options)
        {
        }

        public DbSet<Result> Results { get; set; }
        public DbSet<KeyWord> KeyWords { get; set; }
    }
}
