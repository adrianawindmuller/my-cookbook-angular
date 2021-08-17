using System.Collections.Generic;

namespace MyCookbook.Domain.Recipes.Dtos
{
    public class RegisterRecipeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public uint NumberPortion { get; set; }

        public uint PreparationTimeInMinutes { get; set; }

        public string Ingredients { get; set; }

        public string PreparationMode { get; set; }

        public List<string> Images { get; set; }

        public bool Published { get; set; }

    }
}
