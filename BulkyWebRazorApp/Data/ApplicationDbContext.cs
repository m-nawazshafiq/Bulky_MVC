using BulkyWebRazorApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazorApp.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name ="Sci-Fi", DisplayOrder = 1}
                );
        }
    }
}
