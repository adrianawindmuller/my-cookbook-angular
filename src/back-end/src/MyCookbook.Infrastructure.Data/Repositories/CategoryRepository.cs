using MyCookbook.Domain.Recipes;
using MyCookbook.Infrastructure.Data.DbContexts;

namespace MyCookbook.Infrastructure.Data.Repositories
{
    public class CategoryRepository : EfRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MyCookBookDbContext db) : base(db)
        {
        }
    }
}
