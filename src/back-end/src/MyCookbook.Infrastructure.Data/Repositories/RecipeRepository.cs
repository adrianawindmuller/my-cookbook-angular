using Microsoft.EntityFrameworkCore;
using MyCookbook.Domain.Recipes;
using MyCookbook.Infrastructure.Data.DbContexts;
using System.Collections.Generic;
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
            .AsNoTracking().ToListAsync();


    }
}
