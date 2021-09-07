namespace MyCookbook.Domain.Recipes.Dtos
{
    public class GetCategoryWithRecipesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfRecipes { get; set; }

        public string Icon { get; set; }
    }
}
