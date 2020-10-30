using System.Collections.Generic;

namespace MyCookbook.Api.Controllers
{
    public class CardRecipeViewModel
    {
        public string RecipeName { get; set; }

        public string CategoryName { get; set; }

        public bool Favorite { get; set; }

        public List<string> Images { get; set; } = new List<string>();
    }
}
