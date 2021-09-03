using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCookbook.Domain.Recipes
{
    public class Category : Entity
    {
        private readonly List<Recipe> _recipes = new List<Recipe>();

        public Category(string name, string icon)
        {
            Validate(name);
            Name = name;
            Icon = icon;
        }

        private Category() { }

        public string Name { get; private set; }

        public string Icon { get; set; }

        public IReadOnlyList<Recipe> Recipes => _recipes.ToList();

        public int NumberOfRecipes => _recipes.Count();

        private void Validate(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Nome obrigatório!", nameof(name));
            }

            if (name.Length < 2)
            {
                throw new ArgumentException("Insira pelo menos 2 caracteres.", nameof(name));
            }

            if (name.Length > 20)
            {
                throw new ArgumentException("Insira no máximo 20 caracteres.", nameof(name));
            }
        }
    }
}
