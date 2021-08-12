using System.Collections.Generic;

namespace MyCookbook.Api.Recipes.Controllers.ViewModel
{
    public class GetRecipeEditViewModel
    {
        public int IdRecipe { get; set; }

        public string NameRecipe { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public uint NumberPortion { get; set; }

        public uint PreparationTimeInMinutes { get; set; }

        public string Ingredients { get; set; }

        public string PreparationMode { get; set; }

        public List<string> Images { get; set; }

        public bool Publicated { get; set; }
    }
}
