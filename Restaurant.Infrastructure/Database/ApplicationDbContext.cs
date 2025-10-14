using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
namespace Restaurants.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext
    {

        internal DbSet<Restaurant> Restaurants { get; set; }
        internal DbSet<Dish> Dishes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RestaurantDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.OwnsOne(e => e.Address);
                entity.HasMany(e => e.Dishes)
                      .WithOne()
                      .HasForeignKey(d => d.RestaurantId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Dish>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

        }

        }
}
