using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace TestFile.Models
{
    public class ImageDbContext:DbContext
    {
        public ImageDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<ImageModel> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageModel>()
                .HasIndex(b => b.Title)
                .IsUnique();
        }
    }
}
