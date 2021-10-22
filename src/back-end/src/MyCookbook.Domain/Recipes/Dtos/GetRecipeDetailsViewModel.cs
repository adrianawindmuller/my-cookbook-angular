using System.Collections.Generic;

namespace MyCookbook.Domain.Recipes.Dtos
{
    public class GetRecipeDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public string CategoryName { get; set; }

        public Difficulty Difficulty { get; set; }

        public int NumberPortion { get; set; }

        public int PreparationTimeInMinutes { get; set; }

        public string Ingredients { get; set; }

        public string PreparationMode { get; set; }

        public int Rating { get; set; }

        public bool Favorite { get; set; }

        public List<string> Images { get; set; }
    }
}
