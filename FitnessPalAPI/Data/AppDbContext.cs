using FitnessPalAPI.Models.DatabaseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace FitnessPalAPI.Data
{
    public class AppDbContext : IdentityDbContext<User,IdentityRole<int>,int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<DailyWeight> DailyWeights { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<MealItem> MealItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensure the primary keys are configured properly for identity tables
            //modelBuilder.Entity<IdentityUserLogin<int>>().HasKey(iul => new { iul.LoginProvider, iul.ProviderKey, iul.UserId });
            //modelBuilder.Entity<IdentityUserRole<int>>().HasKey(iur => new { iur.UserId, iur.RoleId });
            //modelBuilder.Entity<IdentityUserToken<int>>().HasKey(iut => new { iut.UserId, iut.LoginProvider, iut.Name });

            modelBuilder.Entity<User>(b =>
            {
                b.HasMany(e => e.DailyWeights)
                .WithOne(e => e.User)
                .HasForeignKey("UserId")
                .IsRequired();

                b.HasIndex(u => u.Email)
                .IsUnique();
            });

            modelBuilder.Entity<Goal>(b =>
            {
                b.HasOne(e => e.User)
                .WithMany(e => e.Goals)
                .HasForeignKey(e => e.UserId)
                .IsRequired();
            });
            

            modelBuilder.Entity<Meal>(b =>
            {
                b.HasOne(e => e.User)
                .WithMany(e => e.Meals)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

                b.HasMany(e => e.Foods)
                .WithMany()
                .UsingEntity<MealItem>();
            });
            

        }
    }
}
