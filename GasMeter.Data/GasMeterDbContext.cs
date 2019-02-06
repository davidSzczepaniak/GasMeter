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

            modelBuilder.Entity<Measure>().HasOne(item => item.Image)
                       .WithOne()
                       .HasForeignKey<CapturedImage>(item => item.Id)
                       .IsRequired(true)
                       .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<CapturedImage> CapturedImages { get; set; }
    }
}
