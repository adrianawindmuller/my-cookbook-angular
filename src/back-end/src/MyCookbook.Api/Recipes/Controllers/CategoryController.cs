using Microsoft.AspNetCore.Mvc;
using MyCookbook.Domain.Recipes;
using System.Threading.Tasks;

namespace MyCookbook.Api.Recipes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetCateforiesAsync()
        {
            var response = await _categoryApplication.GetCateforiesAsync();
            return Result(response);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var response = await _categoryApplication.GetCategoryByIdAsync(id);
            return Result(response);
        }
    }
}
