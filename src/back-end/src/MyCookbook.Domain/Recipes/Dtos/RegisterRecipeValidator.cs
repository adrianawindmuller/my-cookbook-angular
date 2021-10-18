using FluentValidation;

namespace MyCookbook.Domain.Recipes.Dtos
{
    public class RegisterRecipeValidator : AbstractValidator<RegisterRecipeDto>
    {
        public RegisterRecipeValidator()
        {
            RuleFor(p => p.Name)
                .Length(5, 60).WithMessage("Insira no m�nimo 5 caracteres e no m�ximo 60 caracteres.")
                .NotEmpty();

            RuleFor(p => p.CategoryId)
                .GreaterThan(0)
                .NotEmpty();

            RuleFor(p => p.NumberPortion)
                .GreaterThan(0).WithMessage("Insira um numero maior que 1.")
                .LessThan(40).WithMessage("Insira um numero menor que 40.")
                .NotEmpty();

            RuleFor(p => p.PreparationTimeInMinutes)
                .GreaterThan(10).WithMessage("Insira um n�mero maior que 10 minutos")
                .LessThan(600).WithMessage("Insira um n�mero menor que 600 minutos.")
                .NotEmpty();

            RuleFor(p => p.Ingredients)
                .Length(5, 1000).WithMessage("Insira no m�nimo 5 caracteres e no m�ximo 100 caracteres.")
                .NotEmpty();


            RuleFor(p => p.PreparationMode)
                .Length(5, 1000).WithMessage("Insira no m�nimo 5 caracteres e no m�ximo 100 caracteres.")
                .NotEmpty();

            RuleFor(p => p.Images)
                .Must(image => image.Count <= 6).WithMessage("Insira no m�ximo 6 imagens.")
                .NotEmpty();
        }
    }
}
