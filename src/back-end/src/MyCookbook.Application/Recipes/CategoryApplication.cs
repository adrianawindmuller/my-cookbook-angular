using Microsoft.EntityFrameworkCore;
using MyCookbook.Domain.Common;
using MyCookbook.Domain.Recipes.Dtos;
using MyCookbook.Infrastructure.Data.DbContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCookbook.Domain.Recipes
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly MyCookBookDbContext _context;

        public CategoryApplication(
            MyCookBookDbContext context)
        {
            _context = context;
        }

        public async Task<Response> GetCateforiesAsync()
        {
            var categories = await _context.Category.Include(x => x.Recipes).ToListAsync();

            var vmCategories = new List<GetCategoryViewModel>();

            vmCategories.AddRange(categories.Select(category => new GetCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                NumberOfRecipes = category.NumberOfRecipes,
                Icon = category.Icon,
            }));
            _context.SaveChanges();
            return Response.Ok(vmCategories);
        }

        public async Task<Response> GetCategoryByIdWithRecipes(int id)
        {
            var category = await _context.Category
                .Include(x => x.Recipes)
                .ThenInclude(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == id);

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
                    CategoryName = recipe.Category.Name,
                    Difficulty = recipe.Difficulty,
                    NumberPortion = recipe.NumberPortion,
                    PreparationTimeInMinutes = recipe.PreparationTimeInMinutes,
                    Favorite = recipe.Favorite,
                    Images = recipe.Images.Select(image => image.RawContent).ToList()
                }).ToList()
            };

            _context.SaveChanges();
            return Response.Ok(vmCategories);
        }

        public async Task<Response> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(x => x.Id == id);

            var vm = new GetCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Icon = category.Icon
            };

            _context.SaveChanges();
            return Response.Ok(vm);
        }
    }
}