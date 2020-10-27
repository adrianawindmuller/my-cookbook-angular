using Microsoft.AspNetCore.Mvc;
using MyCookbook.Api.Controllers.ViewModel;
using MyCookbook.Api.Domain;
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
            var imagens = model.Images.Select(c => new Image(c.RawContent)).ToList();

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
    }
}
