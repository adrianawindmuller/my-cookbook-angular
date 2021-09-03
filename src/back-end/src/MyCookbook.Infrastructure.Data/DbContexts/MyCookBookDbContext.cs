using Microsoft.EntityFrameworkCore;
using MyCookbook.Domain;
using MyCookbook.Domain.Recipes;
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
               new { Id = 2, Name = "Carnes" },
               new { Id = 3, Name = "Aves" },
               new { Id = 4, Name = "Peixe" },
               new { Id = 5, Name = "Saladas" },
               new { Id = 6, Name = "Sopas" },
               new { Id = 7, Name = "Massas" },
               new { Id = 8, Name = "Doces e sobremesas" },
               new { Id = 9, Name = "Lanches" },
               new { Id = 10, Name = "Alimentação saúdavel" }
               );

            builder.Entity<User>().HasData(
                new { Id = 1, Name = "Adriana W.", Email = "adri@gmail.com", Photo = "imagen.png", Password = "s5a4%wS5" });
        }
    }
}
