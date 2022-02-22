using MyCookbook.Domain.Common;
using MyCookbook.Domain.Recipes.Dtos;
using System.Threading.Tasks;

namespace MyCookbook.Domain.Recipes
{
    public interface IRecipeApplication
    {
        public Task<Response> CreateRecipe(RegisterRecipeDto dto);

        public Task<Response> EditRecipeAsync(int id, RegisterRecipeDto dto);

        public Task<Response> DeleteRecipeAsync(int id);

        public Task<Response> ListAllRecipesAsync();

        public Task<Response> ListAllRecipesDetailsAsync(int id);

        public Task<Response> FindRecipeByIdAsync(int id);

        public Task<Response> ToggleFavoriteAsync(int id);

        public Task<Response> SetRatingAsync(int id, int rate);

        public Task<Response> FindRecipeByNameAsync(string name);
    }
}
