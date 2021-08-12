using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCookbook.Domain.Recipes;

namespace MyCookbook.Infrastructure.Data.Mapping
{
    public class RecipeMap : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("Recipe");

            builder.HasKey(p => p.Id)
                .HasName("RecipeId");

            builder.Property(p => p.Id)
                   .HasColumnName("RecipeId");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(60)");

            builder.HasOne(p => p.User)
                 .WithMany(p => p.Recipes)
                 .IsRequired();

            builder.HasOne(p => p.Category)
                 .WithMany()
                 .IsRequired();

            builder.Property(p => p.NumberPortion)
                 .IsRequired();

            builder.Property(p => p.PreparationTimeInMinutes)
                .IsRequired();

            builder.Property(p => p.Ingredients)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.PreparationMode)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.HasMany(p => p.Images)
                .WithOne()
                .IsRequired();

            builder.Property(p => p.Published)
                .IsRequired();

            builder.Property(p => p.Created)
                .IsRequired();

            builder.Property(p => p.Rating)
                .IsRequired();

            builder.Property(p => p.Favorite)
                .HasDefaultValue(false);

        }
    }
}
