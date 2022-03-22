using Microsoft.EntityFrameworkCore;
using MyCookbook.Domain.Recipes;
using System.Reflection;

namespace MyCookbook.Infrastructure.Data.DbContexts
{
    public class MyCookBookDbContext : DbContext
    {
        public MyCookBookDbContext(DbContextOptions<MyCookBookDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipe { get; set; }

        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Está é a forma automática para aplicar o mapeamento 
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Seed();
        }
    }
}
