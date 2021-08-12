using System.ComponentModel.DataAnnotations;

namespace MyCookbook.Api.Recipes.Controllers.ViewModel
{
    public class RegisterCategoryViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(20, ErrorMessage = "Insira no máximo 20 caracteres.")]
        [MinLength(2, ErrorMessage = "Insira mais de 2 caracteres.")]
        public string Name { get; set; }
    }
}
