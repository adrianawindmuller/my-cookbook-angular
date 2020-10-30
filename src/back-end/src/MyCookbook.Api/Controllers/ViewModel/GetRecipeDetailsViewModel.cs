using System.Collections.Generic;

namespace MyCookbook.Api.Controllers.ViewModel
{
    public class GetRecipeDetailsViewModel
    {
        public int RecipeId { get; set; }

        public string RecipeName { get; set; }

        public string CategoryName { get; set; }

        public uint NumberPortion { get; set; }

        public uint PreparationTimeInMinutes { get; set; }

        public string Ingredients { get; set; }

        public string PreparationMode { get; set; }

        public int? Rating { get; set; }

        public bool Favorite { get; set; }

        public List<string> Images { get; set; }
    }
}
