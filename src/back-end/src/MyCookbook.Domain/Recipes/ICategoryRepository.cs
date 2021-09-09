using System.Threading.Tasks;

namespace MyCookbook.Domain.Recipes
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> ByIdWithRecipesAsync(int id);
    }
}
