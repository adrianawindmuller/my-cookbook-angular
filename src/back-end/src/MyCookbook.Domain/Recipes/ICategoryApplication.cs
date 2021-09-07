using MyCookbook.Domain.Common;
using System.Threading.Tasks;

namespace MyCookbook.Domain.Recipes
{
    public interface ICategoryApplication
    {
        public Task<Response> GetCateforiesAsync();

        public Task<Response> GetCategoryWithRecipes();

        public Task<Response> GetCategoryByIdWithRecipes(int id);

        public Task<Response> GetCategoryByIdAsync(int id);
    }
}