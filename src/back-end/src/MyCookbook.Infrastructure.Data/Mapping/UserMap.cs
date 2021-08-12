using Microsoft.EntityFrameworkCore;
using MyCookbook.Domain.Recipes;

namespace MyCookbook.Infrastructure.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(p => p.Id)
                   .HasName("UserId");

            builder.Property(p => p.Id)
                   .HasColumnName("UserId");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Photo)
                .IsRequired()
                .HasColumnType("varchar(MAX)");


            builder.Property(p => p.Password)
                .IsRequired()
                .HasColumnType("varchar(50)");




        }
    }
}
