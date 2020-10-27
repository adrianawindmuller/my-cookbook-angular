using Microsoft.AspNetCore.Mvc;
using MyCookbook.Api.Controllers.ViewModel;
using MyCookbook.Api.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCookbook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var categories = await _categoryRepository.ListAllAsync();

            var vm = new List<GetCategoryViewModel>();

            //foreach (var category in categories)  -->>Forma manual
            //{
            //    vm.Add(new CategoryViewModel { Id = category.Id, Name = category.Name });
            //}

            vm.AddRange(categories.Select(c => new GetCategoryViewModel { Id = c.Id, Name = c.Name }));

            return Ok(vm);
        }

        [HttpPost]
        public async Task PostAsync(RegisterCategoryViewModel model)
        {
            var category = new Category(model.Name);

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.UnitOfWork.CommitAsync();
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return NotFound($"Categoria {id} não encontrado.");
            }

            _categoryRepository.Delete(category);
            await _categoryRepository.UnitOfWork.CommitAsync();
            return Ok("Deletado com sucesso!");
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> PutAsync(int id, RegisterCategoryViewModel model)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return NotFound($"Categoria {id} não encontrada.");
            }

            category.Edit(model.Name);
            _categoryRepository.Update(category);
            await _categoryRepository.UnitOfWork.CommitAsync();
            return Ok("Atualizado com sucesso!");

        }
    }
}
