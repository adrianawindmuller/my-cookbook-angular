using MyCookbook.Domain.Recipes;
using System;
using System.Collections.Generic;
using Xunit;

namespace MyCookbook.Test
{
    public class RecipeTest
    {
        private List<Image> _3Images = new List<Image> // field(variavel privada)
        {
            new Image("src:/bolo-de-chocolate-1"),
            new Image("src:/bolo-de-chocolate-2"),
            new Image("src:/bolo-de-chocolate-3")
        };

        private List<Image> _emptyImages = new List<Image>
        {
        }; // field(variavel privada)

        private List<Image> _7Images = new List<Image> // field(variavel privada)
        {
            new Image("src:/bolo-de-chocolate-1"),
            new Image("src:/bolo-de-chocolate-2"),
            new Image("src:/bolo-de-chocolate-3"),
            new Image("src:/bolo-de-chocolate-4"),
            new Image("src:/bolo-de-chocolate-5"),
            new Image("src:/bolo-de-chocolate-6"),
            new Image("src:/bolo-de-chocolate-7"),
        };

        private User _NewUser = new User("Adriana", "adriana@gmail.com", "src://adriana.jpg", "r0D@hf35");

        private Category _NewCategory = new Category("Bolo");

        private Recipe GetNewRecipe(
            List<Image> images,
            User user,
            Category category,
            string name = "Bolo de Chocolate",
            string ingredients = "1 xicara de farinha....",
            string preparationMode = "Bata todos os ingrediente...",
            uint numberPortion = 5,
            uint preparationTimeInMinutes = 60)
        {

            return new Recipe(name,
             user,
             category,
             numberPortion,
             preparationTimeInMinutes,
             ingredients,
             preparationMode,
             images, false);
        }

        [Fact]
        public void NewRecipe_ValidConstrutor_RecipeValid()
        {
            var recipe = GetNewRecipe(_3Images, _NewUser, _NewCategory);

            Assert.Equal("Bolo de Chocolate", recipe.Name);
            Assert.Equal("Bolo", recipe.Category.Name);
            Assert.Equal(5, (int)recipe.NumberPortion);
            Assert.Equal(60, (int)recipe.PreparationTimeInMinutes);
            Assert.Equal("1 xicara de farinha....", recipe.Ingredients);
            Assert.Equal("Bata todos os ingrediente...", recipe.PreparationMode);
            Assert.Equal(_3Images, recipe.Images);
        }

        [Fact]
        public void NewRecipe_InvalidConstrutor_RecipeInvalid()
        {
            var ex = Assert.Throws<ArgumentException>(() => GetNewRecipe(_3Images, _NewUser, _NewCategory, name: ""));
            Assert.Equal("Nome obrigatório! (Parameter 'name')", ex.Message);

            var ex1 = Assert.Throws<ArgumentException>(() => GetNewRecipe(_3Images, _NewUser, _NewCategory, name: "bolo"));
            Assert.Equal("Insira pelo menos 5 caracteres. (Parameter 'name')", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => GetNewRecipe(_3Images, _NewUser, _NewCategory, name: "bolo de chocolate com cobertura de morango com morango com morango"));
            Assert.Equal("Insira no máximo 60 caracteres. (Parameter 'name')", ex2.Message);

            var ex3 = Assert.Throws<ArgumentException>(() => GetNewRecipe(_emptyImages, _NewUser, _NewCategory));
            Assert.Equal("É necessário pelo menos uma imagem. (Parameter 'images')", ex3.Message);

            var ex15 = Assert.Throws<ArgumentException>(() => GetNewRecipe(images: null, _NewUser, _NewCategory));
            Assert.Equal("É necessário pelo menos uma imagem. (Parameter 'images')", ex15.Message);

            var ex4 = Assert.Throws<ArgumentException>(() => GetNewRecipe(_7Images, _NewUser, _NewCategory));
            Assert.Equal("Insira no máximo 6 imagens. (Parameter 'images')", ex4.Message);

            var ex5 = Assert.Throws<ArgumentException>(() => GetNewRecipe(_3Images, _NewUser, _NewCategory, ingredients: ""));
            Assert.Equal("Ingredientes obrigatórios! (Parameter 'ingredients')", ex5.Message);

            var ex6 = Assert.Throws<ArgumentException>(() => GetNewRecipe(_3Images, _NewUser, _NewCategory, ingredients: "bolo"));
            Assert.Equal("Insira pelo menos 5 caracteres. (Parameter 'ingredients')", ex6.Message);

            var ex7 = Assert.Throws<ArgumentException>(() => GetNewRecipe(_3Images, _NewUser, _NewCategory, ingredients: "150 g farinha 50 g açúcar 1 c. de chá fermento em pó ½ c. de chá sal 1 ovo M 200 ml leite meio-gordo 2 c. sopa manteiga (para untar)150 g farinha 150 g farinha 50 g açúcar 1 c. de chá fermento em pó ½ c. de chá sal 1 ovo M 200 ml leite meio-gordo 2 c. sopa manteiga (para untar)150 g farinha150 g farinha 50 g açúcar 1 c. de chá fermento em pó ½ c. de chá sal 1 ovo M 200 ml leite meio-gordo 2 c. sopa manteiga (para untar)150 g farinha150 g farinha 50 g açúcar 1 c. de chá fermento em pó ½ c. de chá sal 1 ovo M 200 ml leite meio-gordo 2 c. sopa manteiga (para untar)150 g farinha150 g farinha 50 g açúcar 1 c. de chá fermento em pó ½ c. de chá sal 1 ovo M 200 ml leite meio-gordo 2 c. sopa manteiga (para untar)150 g farinha150 g farinha 50 g açúcar 1 c. de chá fermento em pó ½ c. de chá sal 1 ovo M 200 ml leite meio-gordo 2 c. sopa manteiga (para untar)150 g farinha150 g farinha 50 g açúcar 1 c. de chá fermento em pó ½ c. de chá sal 1 ovo M 200 ml leite meio-gordo 2 c. sopa manteiga (para untar)150 g farinha"));
            Assert.Equal("Insira no máximo 1000 caracteres. (Parameter 'ingredients')", ex7.Message);

            var ex8 = Assert.Throws<ArgumentException>(() => GetNewRecipe(_3Images, _NewUser, _NewCategory, preparationMode: " "));
            Assert.Equal("Modo de preparo obrigatório! (Parameter 'preparationMode')", ex8.Message);

            var ex9 = Assert.Throws<ArgumentException>(() => GetNewRecipe(_3Images, _NewUser, _NewCategory, preparationMode: "bolo"));
            Assert.Equal("Insira pelo menos 5 caracteres. (Parameter 'preparationMode')", ex9.Message);

            var ex10 = Assert.Throws<ArgumentException>(() => GetNewRecipe(_3Images, _NewUser, _NewCategory, preparationMode: "150 g farinha 50 g açúcar 1 c. de chá fermento em pó ½ c. de chá sal 1 ovo M 200 ml leite meio-gordo 2 c. sopa manteiga (para untar)150 g farinha 150 g farinha 50 g açúcar 1 c. de chá fermento em pó ½ c. de chá sal 1 ovo M 200 ml leite meio-gordo 2 c. sopa manteiga (para untar)150 g farinha150 g farinha 50 g açúcar 1 c. de chá fermento em pó ½ c. de chá sal 1 ovo M 200 ml leite meio-gordo 2 c. sopa manteiga (para untar)150 g farinha150 g farinha 50 g açúcar 1 c. de chá fermento em pó ½ c. de chá sal 1 ovo M 200 ml leite meio-gordo 2 c. sopa manteiga (para untar)150 g farinha150 g farinha 50 g açúcar 1 c. de chá fermento em pó ½ c. de chá sal 1 ovo M 200 ml leite meio-gordo 2 c. sopa manteiga (para untar)150 g farinha150 g farinha 50 g açúcar 1 c. de chá fermento em pó ½ c. de chá sal 1 ovo M 200 ml leite meio-gordo 2 c. sopa manteiga (para untar)150 g farinha150 g farinha 50 g açúcar 1 c. de chá fermento em pó ½ c. de chá sal 1 ovo M 200 ml leite meio-gordo 2 c. sopa manteiga (para untar)150 g farinha"));
            Assert.Equal("Insira no máximo 1000 caracteres. (Parameter 'preparationMode')", ex10.Message);

            var ex12 = Assert.Throws<ArgumentException>(() => GetNewRecipe(_3Images, _NewUser, _NewCategory, numberPortion: 45));
            Assert.Equal("Insira um numero de 1 a 40. (Parameter 'numberPortion')", ex12.Message);

            var ex13 = Assert.Throws<ArgumentException>(() => GetNewRecipe(_3Images, _NewUser, _NewCategory, preparationTimeInMinutes: 5));
            Assert.Equal("Insira mais de 10 minutos. (Parameter 'preparationTimeInMinutes')", ex13.Message);

            var ex14 = Assert.Throws<ArgumentException>(() =>
            {
                var minutes = Convert.ToUInt32(TimeSpan.FromHours(20).TotalMinutes);
                GetNewRecipe(_3Images, _NewUser, _NewCategory, preparationTimeInMinutes: minutes);
            });
            Assert.Equal("Insira no máximo 10 horas. (Parameter 'preparationTimeInMinutes')", ex14.Message);

            var ex16 = Assert.Throws<ArgumentException>(() => GetNewRecipe(_3Images, user: null, _NewCategory));
            Assert.Equal("Usuário obrigatório! (Parameter 'user')", ex16.Message);

            var ex17 = Assert.Throws<ArgumentException>(() => GetNewRecipe(_3Images, _NewUser, category: null));
            Assert.Equal("Categoria obrigatório! (Parameter 'category')", ex17.Message);
        }

        [Fact]
        public void EditRecipe_ValidEdit_ValidRecipe()
        {
            var userNew = new User("Taís", "tais@gmail.com", "src://tais.jpg", "A5F@hf88");
            var categoryNew = new Category("Sopas");
            var recipe = GetNewRecipe(_3Images, _NewUser, _NewCategory);

            recipe.Edit("Sopa de Abobora", userNew, categoryNew, 8, 60, "1 abobora....", "Corte a abobora e coloque para cozinhar...", true, _3Images);
            Assert.Equal("Sopa de Abobora", recipe.Name);
            Assert.Equal(userNew, recipe.User);
            Assert.Equal("Sopas", recipe.Category.Name);
            Assert.Equal(8, (int)recipe.NumberPortion);
            Assert.Equal("1 abobora....", recipe.Ingredients);
            Assert.Equal("Corte a abobora e coloque para cozinhar...", recipe.PreparationMode);
            Assert.True(recipe.Published);
            Assert.Equal(_3Images, recipe.Images);


        }

        [Fact]
        public void EditRecipe_InvalidEdit_InvalidRecipe()
        {
            var category = new Category("Bolo");
            var userNew = new User("Taís", "tais@gmail.com", "src://tais.jpg", "A5F@hf88");
            var recipe = GetNewRecipe(_3Images, _NewUser, _NewCategory);
            Assert.Throws<ArgumentException>(() => recipe.Edit("", userNew, category, 60, 5, " ", "", true, _7Images));
        }

        [Fact]
        public void ToogleFavorite_Caled_Toogled()
        {
            var recipe = GetNewRecipe(_3Images, _NewUser, _NewCategory);

            Assert.False(recipe.Favorite);
            recipe.ToogleFavorite();
            Assert.True(recipe.Favorite);
        }

        [Fact]
        public void TooglePublicated_Caled_Toogled()
        {
            var recipe = GetNewRecipe(_3Images, _NewUser, _NewCategory);

            Assert.False(recipe.Published);
            recipe.TooglePublicated();
            Assert.True(recipe.Published);
        }


        [Fact]
        public void SetRating_Rating_SetRating()
        {
            var recipe = GetNewRecipe(_3Images, _NewUser, _NewCategory);

            recipe.SetRating(5);
            Assert.Equal(5, recipe.Rating);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(10)]
        [InlineData(50)]
        public void SetRating_InvalidRating_InvalidRating(int rating)
        {
            var recipe = GetNewRecipe(_3Images, _NewUser, _NewCategory);

            Assert.Throws<ArgumentException>(() => recipe.SetRating(rating));
        }

    }
}
