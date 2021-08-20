using MyCookbook.Domain.Recipes;
using System;
using Xunit;

namespace MyCookbook.UnitTest
{
    public class CategoryTest
    {
        [Theory]
        [InlineData("Bolo")]
        [InlineData("Receitas Rápidas")]

        public void NewCategory_ValidName_CategoryValid(string name)
        {
            var category = new Category(name);

            Assert.Equal(name, category.Name);
        }

        [Theory]
        [InlineData("", "Nome obrigatório! (Parameter 'name')")]
        [InlineData(" ", "Nome obrigatório! (Parameter 'name')")]
        [InlineData(null, "Nome obrigatório! (Parameter 'name')")]
        [InlineData("B", "Insira pelo menos 2 caracteres. (Parameter 'name')")]
        [InlineData("Minha categoria com  ", "Insira no máximo 20 caracteres. (Parameter 'name')")]
        public void NewCategory_InvalidName_CategoryInvalid(string name, string errorExpected)
        {
            var ex = Assert.Throws<ArgumentException>(() => new Category(name));
            Assert.Equal(errorExpected, ex.Message);
        }
    }
}

