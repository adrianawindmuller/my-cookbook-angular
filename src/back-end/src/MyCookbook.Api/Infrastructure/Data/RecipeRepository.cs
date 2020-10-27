using MyCookbook.Api.Domain;

namespace MyCookbook.Api.Infrastructure.Data
{
    public class RecipeRepository : EfRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(MyCookBookDbContext db) : base(db)
        {
        }
    }
}
