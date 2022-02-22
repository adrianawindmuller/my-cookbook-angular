using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyCookbook.Domain.Recipes;
using MyCookbook.Domain.Recipes.Dtos;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MyCookbook.Api.Recipes.Controllers
{
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

            var response = await _recipeApplication.CreateRecipe(dto);
            return Result(response);

        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> PutRecipe(int id, RegisterRecipeDto dto)
        {
            var response = await _recipeApplication.EditRecipeAsync(id, dto);
            return Result(response);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var response = await _recipeApplication.DeleteRecipeAsync(id);
            return Result(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            var response = await _recipeApplication.ListAllRecipesAsync();
            return Result(response);
        }

        [Route("{id}/details")]
        [HttpGet]
        public async Task<IActionResult> GetRecipeDetails(int id)
        {
            var response = await _recipeApplication.ListAllRecipesDetailsAsync(id);
            return Result(response);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetRecipeEdit(int id)
        {
            var response = await _recipeApplication.FindRecipeByIdAsync(id);
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

        [Route("name/{name}")]
        [HttpGet]
        public async Task<IActionResult> GetRecipesByName(string name)
        {
            var response = await _recipeApplication.FindRecipeByNameAsync(name);
            return Result(response);
        }
    }
}
