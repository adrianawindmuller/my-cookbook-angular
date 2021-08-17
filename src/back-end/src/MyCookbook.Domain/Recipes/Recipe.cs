using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCookbook.Domain.Recipes
{
    public class Recipe : Entity
    {
        public Recipe(
            string name,
            User user,
            Category category,
            uint numberPortion,
            uint preparationTimeInMinutes,
            string ingredients,
            string preparationMode,
            List<Image> images,
            bool published)
        {
            Validate(name, user, category, images, ingredients, preparationMode, numberPortion, preparationTimeInMinutes);
            Name = name;
            User = user;
            Category = category;
            NumberPortion = numberPortion;
            PreparationTimeInMinutes = preparationTimeInMinutes;
            Ingredients = ingredients;
            PreparationMode = preparationMode;
            Images = images;
            Published = published;
            Created = DateTime.Now;
        }

        private Recipe() { }

        public string Name { get; private set; }

        public User User { get; private set; }

        public Category Category { get; private set; }

        public uint NumberPortion { get; private set; }

        public uint PreparationTimeInMinutes { get; private set; }

        public string Ingredients { get; private set; }

        public string PreparationMode { get; private set; }

        public List<Image> Images { get; private set; }

        public DateTime Created { get; }

        public bool Published { get; private set; }

        public int Rating { get; private set; }

        public bool Favorite { get; private set; }

        public void ToogleFavorite()
        {
            Favorite = !Favorite;
        }

        public void TooglePublicated()
        {
            Published = !Published;
        }

        public void SetRating(int rate)
        {
            if (rate < 0 || rate > 5)
            {
                throw new ArgumentException("Insira um número de 1 á 5");
            }
            Rating = rate;
        }


        public void Edit(
            string name,
            User user,
            Category category,
            uint numberPortions,
            uint preparationTimeInMinutes,
            string ingredients,
            string preparationMode,
            bool published,
            List<Image> images = null)
        {
            Validate(name, user, category, images, ingredients, preparationMode, numberPortions, preparationTimeInMinutes);
            Name = name;
            User = user;
            Category = category;
            NumberPortion = numberPortions;
            PreparationTimeInMinutes = preparationTimeInMinutes;
            Ingredients = ingredients;
            PreparationMode = preparationMode;
            Published = published;

            if (images != null)
            {
                Images.Clear();
                Images.AddRange(images);
            }

        }

        private void Validate(
            string name,
            User user,
            Category category,
            List<Image> images,
            string ingredients,
            string preparationMode,
            uint numberPortion,
            uint preparationTimeInMinutes)
        {
            if (user is null)
            {
                throw new ArgumentException("Usuário obrigatório!", nameof(user));
            }

            if (category is null)
            {
                throw new ArgumentException("Categoria obrigatório!", nameof(category));
            }

            if (images is null || !images.Any())
                throw new ArgumentException("É necessário pelo menos uma imagem.", nameof(images));

            if (images.Count > 6)
                throw new ArgumentException("Insira no máximo 6 imagens.", nameof(images));

            if (preparationTimeInMinutes < 10)
                throw new ArgumentException("Insira mais de 10 minutos.", nameof(preparationTimeInMinutes));

            if (TimeSpan.FromMinutes(preparationTimeInMinutes).Hours > 10)
                throw new ArgumentException("Insira no máximo 10 horas.", nameof(preparationTimeInMinutes));

            #region IsNullOrWriteSpace
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome obrigatório!", nameof(name));

            if (string.IsNullOrWhiteSpace(ingredients))
                throw new ArgumentException("Ingredientes obrigatórios!", nameof(ingredients));

            if (string.IsNullOrWhiteSpace(preparationMode))
                throw new ArgumentException("Modo de preparo obrigatório!", nameof(preparationMode));
            #endregion

            #region Validação de Lenght
            if (name.Length < 5)
                throw new ArgumentException("Insira pelo menos 5 caracteres.", nameof(name));

            if (ingredients.Length < 5)
                throw new ArgumentException("Insira pelo menos 5 caracteres.", nameof(ingredients));

            if (preparationMode.Length < 5)
                throw new ArgumentException("Insira pelo menos 5 caracteres.", nameof(preparationMode));

            if (name.Length > 60)
                throw new ArgumentException("Insira no máximo 60 caracteres.", nameof(name));

            if (ingredients.Length > 1000)
                throw new ArgumentException("Insira no máximo 1000 caracteres.", nameof(ingredients));

            if (preparationMode.Length > 1000)
                throw new ArgumentException("Insira no máximo 1000 caracteres.", nameof(preparationMode));
            #endregion

            if (numberPortion < 1 || numberPortion > 40)
                throw new ArgumentException("Insira um numero de 1 a 40.", nameof(numberPortion));

        }
    }
}
