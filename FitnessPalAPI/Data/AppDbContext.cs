using FitnessPalAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace FitnessPalAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<DailyWeight> DailyWeights { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Food> Foods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasMany(e => e.DailyWeights)
            .WithOne(e => e.User)
            .HasForeignKey("UserId")
            .IsRequired();

            modelBuilder.Entity<Goal>()
            .HasOne(e => e.User)
            .WithOne(e => e.Goal)
            .HasForeignKey<Goal>(e => e.UserId)
            .IsRequired();

            modelBuilder.Entity<Meal>()
            .HasOne(e => e.User)
            .WithMany(e => e.Meals)
            .HasForeignKey(e => e.UserId)
            .IsRequired();

            modelBuilder.Entity<Meal>()
            .HasMany(e => e.Foods)
            .WithMany()
            .UsingEntity<MealItem>();

        }
    }
}
