using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCookbook.Api.Domain;

namespace MyCookbook.Api.Infrastructure.Mapping
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
                .HasColumnType("varchar(20)") // Qualquer quantidade de caracteres até 200
                .IsRequired();


            // char(9) limita para exatamente 9 caracteres.

        }
    }
}
