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

        public override async Task<IReadOnlyList<Category>> ListAllAsync()
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
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
