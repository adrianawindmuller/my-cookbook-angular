using MyCookbook.Api.Domain;

namespace MyCookbook.Api.Infrastructure.Data
{
    public class CategoryRepository : EfRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MyCookBookDbContext db) : base(db)
        {
        }
    }
}
