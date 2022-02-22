using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCookbook.Domain.Recipes
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        public Task<List<Recipe>> GetRecipesByName(string name);
    }
}