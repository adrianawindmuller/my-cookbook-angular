using Microsoft.EntityFrameworkCore;
using MyCookbook.Domain.Recipes;
using MyCookbook.Infrastructure.Data.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCookbook.Infrastructure.Data.Repositories
{
    public class RecipeRepository : EfRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(MyCookBookDbContext db) : base(db)
        {
        }

        public override Task<Recipe> GetByIdAsync(int id)
            => Db.Set<Recipe>()
            .Include(x => x.Category)
            .Include(x => x.Images)
            .FirstOrDefaultAsync(x => x.Id == id);

        public override async Task<IReadOnlyList<Recipe>> ListAllAsync()
            => await Db.Set<Recipe>()
            .Include(x => x.Category)
            .Include(x => x.Images)
            .AsNoTracking()
            .ToListAsync();

        public async Task<List<Recipe>> GetRecipesByName(string name)
            => await Db.Set<Recipe>()
                .Include(x => x.Category)
                .Include(x => x.Images)
                .Where(x => x.Name.Contains(name, System.StringComparison.OrdinalIgnoreCase))
                .AsNoTracking()
                .ToListAsync();

    }
}
