using FitnessPal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessPal.Persistence.Configurations.Entities
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasData(
                new Ingredient
                {
                    Id = 1,
                    Carbs = 13,
                    Protein = 10,
                    Fat = 3,
                    Calories = 216,
                    Description = "Description example",
                    Name = "Example"
                }
            );
        }
    }
}
