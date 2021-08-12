using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCookbook.Domain.Recipes;

namespace MyCookbook.Infrastructure.Data.Mapping
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Image");

            builder.HasKey(p => p.Id)
                .HasName("ImageId");

            builder.Property(p => p.Id)
                   .HasColumnName("ImageId");

            builder.Property(p => p.RawContent)
                .IsRequired()
                .HasColumnType("varchar(MAX)");
        }
    }
}
