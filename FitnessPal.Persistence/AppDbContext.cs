using FitnessPal.Domain.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessPal.Persistence.Configurations.Entities;
using FitnessPal.Persistence.Configurations.Identity;
using FitnessPal.Application.Models.Identity;
using FitnessPal.Domain.Models;

namespace FitnessPal.Persistence
{
    public class AppDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<DailyWeight> DailyWeights { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MealItem> MealItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new IngredientConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<User>(b =>
            {
                b.HasMany(e => e.DailyWeights)
                .WithOne(e => e.User)
                .HasForeignKey("UserId")
                .IsRequired();

                b.HasIndex(u => u.Email)
                .IsUnique();

                b.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
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

                b.HasMany(m => m.Ingredients)
                .WithMany(i => i.Meals)
                .UsingEntity<MealItem>(
                    j => j.HasOne(mi => mi.Ingredient)
                          .WithMany(i => i.MealItems)
                          .HasForeignKey(mi => mi.IngredientId)
                          .HasPrincipalKey(i => i.Id),
                    j => j.HasOne(mi => mi.Meal)
                          .WithMany(m => m.MealItems)
                          .HasForeignKey(mi => mi.MealId)
                          .HasPrincipalKey(m => m.Id),
                    j =>
                    {
                        j.HasKey(mi => new { mi.MealId, mi.IngredientId });
                    }
                );
            });


            modelBuilder.Entity<Role>(b =>
            {
                b.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.UtcNow;

                if(entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
