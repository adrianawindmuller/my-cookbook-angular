using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MyCookbook.Domain.Recipes
{
    public class User : Entity
    {

        public User(string name, string email, string photo, string password)
        {
            Validate(name, email, photo, password);
            Name = name;
            Email = email;
            Photo = photo;
            Password = password;
        }

        private User() { }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public string Photo { get; private set; }

        public List<Recipe> Recipes { get; private set; }

        public void EditUser(string name, string email, string photo, string password)
        {
            Validate(name, email, photo, password);
            Name = name;
            Email = email;
            Photo = photo;
            Password = password;
        }

        private void Validate(string name, string email, string photo, string password)
        {

            #region name
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Nome obrigatório!", nameof(name));
            }

            if (name.Length < 3)
            {
                throw new ArgumentException("Insira mais de 3 caracteres.", nameof(name));
            }

            if (name.Length > 20)
            {
                throw new ArgumentException("Insira menos de 20 caracteres.", nameof(name));
            }
            #endregion

            #region email

            const string emailPattern = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-||_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+([a-z]+|\d|-|\.{0,1}|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])?([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$";
            if (string.IsNullOrWhiteSpace(email) || !CreateRegEx(emailPattern).IsMatch(email))
            {
                throw new ArgumentException("Insira um e-mail valido.", nameof(email));
            }


            #endregion

            #region photo
            if (string.IsNullOrWhiteSpace(photo))
            {
                throw new ArgumentException("Foto obrigatória!", nameof(photo));
            }
            #endregion

            #region password
            const string passwordPattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
            if (string.IsNullOrWhiteSpace(password) || !CreateRegEx(passwordPattern).IsMatch(password))
            {
                throw new ArgumentException("Insira uma senha valida!", nameof(password));
            }
            #endregion

        }

        private static Regex CreateRegEx(string pattern)
        {
            const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;
            return new Regex(pattern, options);
        }

    }
}
