using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
namespace Restaurants.Infrastructure.Database
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
       
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
