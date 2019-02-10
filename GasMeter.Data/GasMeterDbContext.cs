using GasMeter.DataModels;
using Microsoft.EntityFrameworkCore;

namespace GasMeter.Data
{
    public class GasMeterDbContext : DbContext
    {
        public GasMeterDbContext(DbContextOptions<GasMeterDbContext> options) :base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<CapturedImage> CapturedImages { get; set; }
    }
}
