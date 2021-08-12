using Microsoft.EntityFrameworkCore;
using MyCookbook.Domain;
using MyCookbook.Domain.Categories;
using System.Reflection;
using System.Threading.Tasks;

namespace MyCookbook.Infrastructure.Data.DbContexts
{
    public class MyCookBookDbContext : DbContext, IUnitOfWork
    {
        public MyCookBookDbContext(DbContextOptions<MyCookBookDbContext> options)
            : base(options)
        {

        }

        public async Task<bool> CommitAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<Category>().HasData(
                new { Id = 1, Name = "Bolos" },
                new { Id = 2, Name = "Sopas" },
                new { Id = 3, Name = "Carnes" },
                new { Id = 4, Name = "Massas" },
                new { Id = 5, Name = "Peixe" });
        }
    }
}
