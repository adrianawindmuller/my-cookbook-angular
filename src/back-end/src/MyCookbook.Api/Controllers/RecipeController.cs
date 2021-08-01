using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyCookbook.Api.Controllers.ViewModel;
using MyCookbook.Api.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCookbook.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RecipeController : ControllerBase
    {
        private IRecipeRepository _recipeRepository;
        private IUserRepository _userRepository;
        private ICategoryRepository _categoryRepository;

        public RecipeController(IRecipeRepository recipeRepository, IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            _recipeRepository = recipeRepository;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(RegisterRecipeViewModel model)
        {
            if (model.Images.Count > 6)
            {
                ModelState.AddModelError("images", "Insira no máximo 6 imagens.");
            }

            var user = await _userRepository.GetByIdAsync(model.UserId);
            if (user is null)
            {
                return NotFound($"User {model.UserId} não encontrada.");
            }

            var category = await _categoryRepository.GetByIdAsync(model.CategoryId);
            if (category is null)
            {
                return NotFound($"Categoria {model.CategoryId} não encontrada.");
            }

            var imagens = model.Images.Select(i => new Image(i)).ToList();

            var recipe = new Recipe(
                model.Name,
                user,
                category,
                model.NumberPortion,
                model.PreparationTimeInMinutes,
                model.Ingredients,
                model.PreparationMode,
                imagens,
                model.Publicated);


            await _recipeRepository.AddAsync(recipe);
            await _recipeRepository.UnitOfWork.CommitAsync();
            return Ok("Receita criada com sucesso!");
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> PutRecipe(int id, RegisterRecipeViewModel model)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe is null)
            {
                return NotFound($"Receita {id} não encontrada");
            }

            var user = await _userRepository.GetByIdAsync(model.UserId);
            if (user is null)
            {
                return NotFound($"User {model.UserId} não encontrada.");
            };

            var category = await _categoryRepository.GetByIdAsync(model.CategoryId);
            if (category is null)
            {
                return NotFound($"Categoria {model.CategoryId}");
            };

            var images = model.Images.Select(i => new Image(i)).ToList();

            recipe.Edit(
                model.Name,
                user,
                category,
                model.NumberPortion,
                model.PreparationTimeInMinutes,
                model.Ingredients,
                model.PreparationMode,
                model.Publicated,
                images
                );

            _recipeRepository.Update(recipe);
            await _recipeRepository.UnitOfWork.CommitAsync();

            return Ok("Receita atualizada com sucesso!");

        }

        [HttpGet]
        public async Task<IActionResult> GetRecipe()
        {
            var recipes = await _recipeRepository.ListAllAsync();
            var vmRecipes = new List<CardRecipeViewModel>();


            foreach (var recipe in recipes)
            {
                var vmRecipe = new CardRecipeViewModel
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    CategoryName = recipe.Category.Name,
                    Favorite = recipe.Favorite,
                };

                foreach (var image in recipe.Images)
                {
                    vmRecipe.Images.Add(image.RawContent);
                }

                vmRecipes.Add(vmRecipe);
            }

            return Ok(vmRecipes);

        }

        [Route("{id}/details")]
        [HttpGet]
        public async Task<IActionResult> GetRecipeDetails(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe is null)
            {
                return NotFound($"Recipe {recipe.Id} não encontrada.");
            }

            var imageVm = new List<string>();
            foreach (var image in recipe.Images)
            {
                imageVm.Add(image.RawContent);
            }

            var vm = new GetRecipeDetailsViewModel
            {
                RecipeId = recipe.Id,
                RecipeName = recipe.Name,
                CategoryName = recipe.Category.Name,
                NumberPortion = recipe.NumberPortion,
                PreparationTimeInMinutes = recipe.PreparationTimeInMinutes,
                Ingredients = recipe.Ingredients,
                PreparationMode = recipe.PreparationMode,
                Images = imageVm,
                Favorite = recipe.Favorite,
                Rating = recipe.Rating,
            };

            return Ok(vm);

        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetRecipeEdit(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe is null)
            {
                return NotFound($"Receita {id} não encontrada.");
            }

            var imagesVm = new List<string>();
            foreach (var image in recipe.Images)
            {
                imagesVm.Add(image.RawContent);
            }

            var vm = new RegisterRecipeViewModel
            {
                Id = recipe.Id,
                Name = recipe.Name,
                CategoryId = recipe.Category.Id,
                UserId = recipe.User.Id,
                NumberPortion = recipe.NumberPortion,
                PreparationTimeInMinutes = recipe.PreparationTimeInMinutes,
                Ingredients = recipe.Ingredients,
                PreparationMode = recipe.PreparationMode,
                Images = imagesVm,
                Publicated = recipe.Publicated
            };

            return Ok(vm);

        }

        [Route("{id}/toggle-favorite")]
        [HttpPut]
        public async Task<IActionResult> ToggleFavoriteAsync(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe is null)
            {
                return NotFound($"Receita {id} não encontrada.");
            }

            recipe.ToogleFavorite();
            _recipeRepository.Update(recipe);
            await _recipeRepository.UnitOfWork.CommitAsync();

            return Ok();
        }

        [Route("{id}/set-rating/{rate}")]
        [HttpPut]
        public async Task<IActionResult> SetRatingAsync(int id, [Required][Range(1, 5)] int rate)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe is null)
            {
                return NotFound($"Receita {id} não encontrada.");
            }

            recipe.SetRating(rate);
            _recipeRepository.Update(recipe);
            await _recipeRepository.UnitOfWork.CommitAsync();

            return Ok();
        }
    }
}
