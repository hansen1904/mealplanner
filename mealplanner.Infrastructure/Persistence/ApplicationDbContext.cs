using mealplanner.Domain.Base;
using mealplanner.Domain.Entities;
using mealplanner.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace mealplanner.Infrastructure.Persistence
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            this.Database.EnsureCreated();
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<FoodItem>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<FoodItemAmount>()
                .HasKey(x => x.Id);


            modelBuilder.Entity<Recipe>()
                .HasMany(x => x.FoodAmount)
                .WithOne(x => x.Recipe)
                .HasForeignKey(e => e.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FoodItem>()
                .HasMany(x => x.FoodAmount)
                .WithOne(x => x.FoodItem)
                .HasForeignKey(e => e.FoodItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public override int SaveChanges()
        {
            var now = DateTime.UtcNow;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is AuditableEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.Created = now;
                            entity.LastModified = now;
                            break;

                        case EntityState.Modified:
                            Entry(entity).Property(x => x.Created).IsModified = false;
                            entity.LastModified = now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
