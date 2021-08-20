using MyCookbook.Domain.Recipes;
using System;
using Xunit;

namespace MyCookbook.UnitTest
{
    public class UserTest
    {

        [Fact]
        public void NewUser_ValidName_ValidUser()
        {
            var user = new User("Adriana", "adriana@gmail.com", "src://adriana.jpg", "r0D@hf35");
            Assert.Equal("Adriana", user.Name);
        }

        [Theory]
        [InlineData("", "Nome obrigatório! (Parameter 'name')")]
        [InlineData("  ", "Nome obrigatório! (Parameter 'name')")]
        [InlineData(null, "Nome obrigatório! (Parameter 'name')")]
        [InlineData("11", "Insira mais de 3 caracteres. (Parameter 'name')")]
        [InlineData("Ana Maria de Souza Cruz", "Insira menos de 20 caracteres. (Parameter 'name')")]
        public void NewUser_InvalidName_InvalidUser(string name, string errorExpected)
        {
            var ex = Assert.Throws<ArgumentException>(() => new User(name, "adriana@gmail.com", "src://adriana.jpg", "r0D@hf35"));
            Assert.Equal(errorExpected, ex.Message);
        }

        [Fact]
        public void NewUser_ValidEmail_ValidUser()
        {
            var user = new User("Adriana", "adriana@gmail.com", "src://adriana.jpg", "r0D@hf35");
            Assert.Equal("adriana@gmail.com", user.Email);
        }

        [Theory]
        [InlineData("adria", "Insira um e-mail valido. (Parameter 'email')")]
        [InlineData("adria@", "Insira um e-mail valido. (Parameter 'email')")]
        [InlineData("adria@gmail", "Insira um e-mail valido. (Parameter 'email')")]
        [InlineData("", "Insira um e-mail valido. (Parameter 'email')")]
        [InlineData("  ", "Insira um e-mail valido. (Parameter 'email')")]
        [InlineData(null, "Insira um e-mail valido. (Parameter 'email')")]
        public void NewUser_InvalidEmail_InvalidEmail(string email, string errorExpected)
        {
            var ex = Assert.Throws<ArgumentException>(() => new User("Adriana", email, "src://adriana.jpg", "r0D@hf35"));
            Assert.Equal(errorExpected, ex.Message);
        }

        [Fact] // new
        public void NewUser_ValidPhoto_ValidUser()
        {
            var user = new User("Adriana", "adriana@gmail.com", "src://adriana.jpg", "r0D@hf35");
            Assert.Equal("src://adriana.jpg", user.Photo);

        }

        [Theory]
        [InlineData("", "Foto obrigatória! (Parameter 'photo')")]
        [InlineData("    ", "Foto obrigatória! (Parameter 'photo')")]
        [InlineData(null, "Foto obrigatória! (Parameter 'photo')")]
        public void NewUser_InvalidPhoto_Invaliduser(string photo, string errorExpected)
        {
            var ex = Assert.Throws<ArgumentException>(() => new User("Adriana", "adria@gmail.com", photo, "r0D@hf35"));
            Assert.Equal(errorExpected, ex.Message);
        }

        [Fact] //new 
        public void NewUser_ValidPassword_ValidUser()
        {
            var user = new User("Adriana", "adriana@gmail.com", "src://adriana.jpg", "r0D@hf35");
            Assert.Equal("r0D@hf35", user.Password);
        }

        [Theory] //new
        [InlineData("", "Insira uma senha valida! (Parameter 'password')")]
        [InlineData("  ", "Insira uma senha valida! (Parameter 'password')")]
        [InlineData(null, "Insira uma senha valida! (Parameter 'password')")]
        [InlineData("bbb", "Insira uma senha valida! (Parameter 'password')")]
        [InlineData("aaa6666", "Insira uma senha valida! (Parameter 'password')")]
        [InlineData("cRfP54@", "Insira uma senha valida! (Parameter 'password')")]
        public void NewUser_InvalidPassword_InvalidUser(string password, string errorExpected)
        {
            var ex = Assert.Throws<ArgumentException>(() => new User("Adriana", "adriana@gmail.com", "src://adriana.jpg", password));
            Assert.Equal(errorExpected, ex.Message);
        }


        [Fact] //new
        public void EditUser_ValidEdit_ValidUser()
        {
            var user = new User("Adriana", "adriana@gmail.com", "src://adriana.jpg", "r0D@hf35");
            user.EditUser("Tais", "tais@gmail.com", "src://tais.jpg", "r0D@hf49");
            Assert.Equal("Tais", user.Name);
            Assert.Equal("tais@gmail.com", user.Email);
            Assert.Equal("src://tais.jpg", user.Photo);
            Assert.Equal("r0D@hf49", user.Password);

        }

        [Theory] //new
        [InlineData("", "@gmail.com", "", "sda66")]
        public void EditUser_InvalidEdit_InvalidUser(string name, string email, string photo, string password)
        {
            var user = new User("Adriana", "adriana@gmail.com", "src://adriana.jpg", "r0D@hf35");
            Assert.Throws<ArgumentException>(() => user.EditUser(name, email, photo, password));
        }


    }
}
