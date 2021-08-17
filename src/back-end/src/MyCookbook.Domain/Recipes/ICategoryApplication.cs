using MyCookbook.Domain.Common;
using System.Threading.Tasks;

namespace MyCookbook.Domain.Recipes
{
    public interface ICategoryApplication
    {
        public Task<Response> GetCateforiesAsync();

        public Task<Response> GetCategoryByIdAsync(int id);
    }
}