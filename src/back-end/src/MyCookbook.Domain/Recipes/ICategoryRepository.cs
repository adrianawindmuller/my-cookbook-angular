using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCookbook.Domain.Recipes
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IReadOnlyList<Category>> ListAllWithRecipesAsync();

        Task<Category> ByIdWithRecipesAsync(int id);
    }
}
