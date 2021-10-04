using System.Collections.Generic;

namespace MyCookbook.Domain.Recipes.Dtos
{
    public class CardRecipeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public bool Favorite { get; set; }

        public List<string> Images { get; set; } = new List<string>();
    }
}
