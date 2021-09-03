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

            var vm = new List<GetCategoryViewModel>();

            vm.AddRange(categories.Select(c => new GetCategoryViewModel { Id = c.Id, Name = c.Name, NumberOfRecipes = c.NumberOfRecipes }));

            return Response.Ok(vm);
        }

        public async Task<Response> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            var vm = new GetCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };

            return Response.Ok(vm);
        }
    }
}
