using System.Collections.Generic;

namespace MyCookbook.Domain.Recipes.Dtos
{
    public class GetCategoryByIdWithRecipesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfRecipes { get; set; }

        public string Icon { get; set; }

        public List<CardRecipeViewModel> Recipes { get; set; } = new List<CardRecipeViewModel>();

    }
}
