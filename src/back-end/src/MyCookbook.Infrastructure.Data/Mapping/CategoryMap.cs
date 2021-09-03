using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCookbook.Domain.Recipes;

namespace MyCookbook.Infrastructure.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(p => p.Id)
                   .HasName("CategoryId");

            builder.Property(p => p.Id)
                   .HasColumnName("CategoryId");

            builder.Property(p => p.Name)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(p => p.Icon)
                .IsRequired();

            builder.HasMany(p => p.Recipes)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
