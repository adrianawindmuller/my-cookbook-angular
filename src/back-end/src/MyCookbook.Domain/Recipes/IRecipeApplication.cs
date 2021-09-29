using MyCookbook.Domain.Common;
using MyCookbook.Domain.Recipes.Dtos;
using System.Threading.Tasks;

namespace MyCookbook.Domain.Recipes
{
    public interface IRecipeApplication
    {
        public Task<Response> RegisterRecipe(RegisterRecipeDto dto);

        public Task<Response> PutRecipe(int id, RegisterRecipeDto dto);

        public Task<Response> DeleteRecipe(int id);

        public Task<Response> GetRecipe();

        public Task<Response> GetRecipeDetails(int id);

        public Task<Response> GetRecipeEdit(int id);

        public Task<Response> ToggleFavoriteAsync(int id);

        public Task<Response> SetRatingAsync(int id, int rate);
    }
}
