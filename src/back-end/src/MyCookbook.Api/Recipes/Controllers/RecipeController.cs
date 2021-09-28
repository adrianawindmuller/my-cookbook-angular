using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyCookbook.Domain.Recipes;
using MyCookbook.Domain.Recipes.Dtos;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MyCookbook.Api.Recipes.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class RecipeController : BaseController
    {
        private readonly IRecipeApplication _recipeApplication;

        public RecipeController(IRecipeApplication recipeApplication)
        {
            _recipeApplication = recipeApplication;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(RegisterRecipeDto dto)
        {
            if (dto.Images.Count > 6)
            {
                ModelState.AddModelError("images", "Insira no máximo 6 imagens.");
            }

            var response = await _recipeApplication.RegisterRecipe(dto);
            return Result(response);

        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> PutRecipe(int id, RegisterRecipeDto dto)
        {
            var response = await _recipeApplication.PutRecipe(id, dto);
            return Result(response);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var response = await _recipeApplication.DeleteRecipe(id);
            return Result(response);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetRecipe()
        {
            var response = await _recipeApplication.GetRecipe();
            return Result(response);
        }

        [AllowAnonymous]
        [Route("{id}/details")]
        [HttpGet]
        public async Task<IActionResult> GetRecipeDetails(int id)
        {
            var response = await _recipeApplication.GetRecipeDetails(id);
            return Result(response);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetRecipeEdit(int id)
        {
            var response = await _recipeApplication.GetRecipeEdit(id);
            return Result(response);
        }

        [Route("{id}/toggle-favorite")]
        [HttpPut]
        public async Task<IActionResult> ToggleFavoriteAsync(int id)
        {
            var response = await _recipeApplication.ToggleFavoriteAsync(id);
            return Result(response);
        }

        [Route("{id}/set-rating/{rate}")]
        [HttpPut]
        public async Task<IActionResult> SetRatingAsync(int id, [Required][Range(1, 5)] int rate)
        {
            var response = await _recipeApplication.SetRatingAsync(id, rate);
            return Result(response);
        }
    }
}
