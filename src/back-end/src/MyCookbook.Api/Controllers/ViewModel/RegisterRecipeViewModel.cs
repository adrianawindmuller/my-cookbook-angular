using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyCookbook.Api.Controllers.ViewModel
{
    public class RegisterRecipeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = Text.ErrorMessenges.FielRequired)]
        [MaxLength(60, ErrorMessage = "Insira no máximo 60 caracteres.")]
        [MinLength(5, ErrorMessage = "Insira pelo menos 5 caracteres.")]
        public string Name { get; set; }


        [Required(ErrorMessage = Text.ErrorMessenges.FielRequired)]
        public int UserId { get; set; }


        [Required(ErrorMessage = Text.ErrorMessenges.FielRequired)]
        public int CategoryId { get; set; }


        [Required(ErrorMessage = Text.ErrorMessenges.FielRequired)]
        [Range(0, 40, ErrorMessage = "Insira um numero de 1 a 40.")]
        public uint NumberPortion { get; set; }


        [Required(ErrorMessage = Text.ErrorMessenges.FielRequired)]
        [Range(10, 600, ErrorMessage = "Insira um número de 10 minutos a 600 minutos.")]
        public uint PreparationTimeInMinutes { get; set; }


        [Required(ErrorMessage = Text.ErrorMessenges.FielRequired)]
        [MaxLength(1000, ErrorMessage = Text.ErrorMessenges.FielMaxLength)]
        [MinLength(5, ErrorMessage = Text.ErrorMessenges.FielMinLength)]
        public string Ingredients { get; set; }


        [Required(ErrorMessage = Text.ErrorMessenges.FielRequired)]
        [MaxLength(1000, ErrorMessage = Text.ErrorMessenges.FielMaxLength)]
        [MinLength(5, ErrorMessage = Text.ErrorMessenges.FielMinLength)]
        public string PreparationMode { get; set; }

        [Required(ErrorMessage = Text.ErrorMessenges.FielRequired)]
        public List<string> Images { get; set; }

        public bool Published { get; set; }

    }
}
