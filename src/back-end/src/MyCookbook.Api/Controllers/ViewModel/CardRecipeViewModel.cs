using System.Collections.Generic;

namespace MyCookbook.Api.Controllers
{
    public class CardRecipeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public bool Favorite { get; set; }

        public List<string> Images { get; set; } = new List<string>();
    }
}
