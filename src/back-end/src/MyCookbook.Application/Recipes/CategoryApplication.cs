using MyCookbook.Domain.Common;
using MyCookbook.Domain.Recipes.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCookbook.Domain.Recipes
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryApplication(
            ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Response> GetCateforiesAsync()
        {
            var categories = await _categoryRepository.ListAllAsync();

            var vmCategories = new List<GetCategoryViewModel>();

            vmCategories.AddRange(categories.Select(category => new GetCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                NumberOfRecipes = category.NumberOfRecipes,
                Icon = category.Icon,
            }));

            return Response.Ok(vmCategories);
        }

        public async Task<Response> GetCategoryByIdWithRecipes(int id)
        {
            var category = await _categoryRepository.ByIdWithRecipesAsync(id);

            var vmCategories = new GetCategoryByIdWithRecipesViewModel
            {
                Id = category.Id,
                Name = category.Name,
                NumberOfRecipes = category.NumberOfRecipes,
                Icon = category.Icon,
                Recipes = category.Recipes.Select(recipe => new CardRecipeViewModel
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    UserId = recipe.User,
                    CategoryName = recipe.Category.Name,
                    Favorite = recipe.Favorite,
                    Images = recipe.Images.Select(image => image.RawContent).ToList()
                }).ToList()
            };

            return Response.Ok(vmCategories);
        }

        public async Task<Response> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            var vm = new GetCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Icon = category.Icon
            };

            return Response.Ok(vm);
        }
    }
}