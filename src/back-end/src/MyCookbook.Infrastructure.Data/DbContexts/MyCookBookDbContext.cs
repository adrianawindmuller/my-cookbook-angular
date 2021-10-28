using Microsoft.EntityFrameworkCore;
using MyCookbook.Domain;
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
        }
    }
}
