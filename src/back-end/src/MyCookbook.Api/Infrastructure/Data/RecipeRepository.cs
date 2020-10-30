using Microsoft.EntityFrameworkCore;
using MyCookbook.Api.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCookbook.Api.Infrastructure.Data
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
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id == id);

        public override async Task<IReadOnlyList<Recipe>> ListAllAsync()
         => await Db.Set<Recipe>()
            .Include(x => x.Category)
            .Include(x => x.Images)
            .Include(x => x.User)
            .AsNoTracking().ToListAsync();


    }
}
