using MyCookbook.Domain.Recipes;
using MyCookbook.Infrastructure.Data.DbContexts;

namespace MyCookbook.Infrastructure.Data.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(MyCookBookDbContext db) : base(db)
        {
        }
    }
}
