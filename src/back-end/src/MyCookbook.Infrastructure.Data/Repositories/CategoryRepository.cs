using Microsoft.EntityFrameworkCore;
using MyCookbook.Domain.Recipes;
using MyCookbook.Infrastructure.Data.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCookbook.Infrastructure.Data.Repositories
{
    public class CategoryRepository : EfRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MyCookBookDbContext db) : base(db)
        {
        }

        public async Task<IReadOnlyList<Category>> ListAllWithRecipesAsync()
        {
            return await Db
                .Set<Category>()
                .Include(x => x.Recipes)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category> ByIdWithRecipesAsync(int id)
        {
            return await Db
                .Set<Category>()
                .Include(x => x.Recipes)
                    .ThenInclude(x => x.Images)
                .Include(x => x.Recipes)
                    .ThenInclude(r => r.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
