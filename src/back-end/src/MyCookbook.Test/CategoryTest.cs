using MyCookbook.Api.Domain;
using System;
using Xunit;

namespace MyCookbook.Test
{
    public class CategoryTest
    {
        //public void MetodoQueEstouChamando_ParametrosPassando_ResultadoQueEuEspero()
        //{
        //}

        [Theory]
        [InlineData("Bolo")]
        [InlineData("Receitas Rápidas")]

        public void NewCategory_ValidName_CategoryValid(string name)
        {
            var category = new Category(name);

            Assert.Equal(name, category.Name);
        }

        [Theory]
        [InlineData("", "Nome obrigatório! (Parameter 'category')")]
        [InlineData(" ", "Nome obrigatório! (Parameter 'category')")]
        [InlineData(null, "Nome obrigatório! (Parameter 'category')")]
        [InlineData("B", "Insira pelo menos 2 caracteres. (Parameter 'category')")]
        [InlineData("Minha categoria com  ", "Insira no máximo 20 caracteres. (Parameter 'category')")]
        public void NewCategory_InvalidName_CategoryInvalid(string name, string errorExpected)
        {
            var ex = Assert.Throws<ArgumentException>(() => new Category(name));
            Assert.Equal(errorExpected, ex.Message);
        }


        [Fact]
        public void Edit_ValidName_EditValid()
        {
            var category = new Category("Bolo");
            Assert.Equal("Bolo", category.Name);

            category.Edit("Suco de Uva");
            Assert.Equal("Suco de Uva", category.Name);
        }

        [Theory]
        [InlineData("", "Nome obrigatório! (Parameter 'category')")]
        [InlineData(" ", "Nome obrigatório! (Parameter 'category')")]
        [InlineData(null, "Nome obrigatório! (Parameter 'category')")]
        [InlineData("B", "Insira pelo menos 2 caracteres.(Parameter 'category')")]
        [InlineData("Minha categoria com  ", "Insira no máximo 20 caracteres. (Parameter 'category')")]
        public void Edit_InvalidName_EditInvalid(string name, string errorExpected)
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var category = new Category("Bolo");
                category.Edit(name);
            });

            Assert.Equal(errorExpected, ex.Message);
        }
    }
}

