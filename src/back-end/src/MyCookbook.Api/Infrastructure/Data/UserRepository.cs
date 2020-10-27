using MyCookbook.Api.Domain;

namespace MyCookbook.Api.Infrastructure.Data
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(MyCookBookDbContext db) : base(db)
        {
        }
    }
}
