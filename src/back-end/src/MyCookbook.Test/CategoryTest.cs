using MyCookbook.Domain.Recipes;
using System;
using Xunit;

namespace MyCookbook.UnitTest
{
    public class CategoryTest
    {
        [Theory]
        [InlineData("Bolo", "carne.png")]
        [InlineData("Receitas Rápidas", "bolo.png")]

        public void NewCategory_ValidName_CategoryValid(string name, string icon)
        {
            var category = new Category(name, icon);

            Assert.Equal(name, category.Name);
            Assert.Equal(icon, category.Icon);
        }

        [Theory]
        [InlineData("", "Nome obrigatório! (Parameter 'name')")]
        [InlineData(" ", "Nome obrigatório! (Parameter 'name')")]
        [InlineData(null, "Nome obrigatório! (Parameter 'name')")]
        [InlineData("B", "Insira pelo menos 2 caracteres. (Parameter 'name')")]
        [InlineData("Minha categoria com  ", "Insira no máximo 20 caracteres. (Parameter 'name')")]
        public void NewCategory_InvalidName_CategoryInvalid(string name, string errorExpected)
        {
            var ex = Assert.Throws<ArgumentException>(() => new Category(name, "bolo.png"));
            Assert.Equal(errorExpected, ex.Message);
        }
    }
}

