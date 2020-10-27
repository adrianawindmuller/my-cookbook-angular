using System;

namespace MyCookbook.Api.Domain
{
    public class Category : Entity
    {
        public Category(string name)
        {
            Validate(name);
            Name = name;
        }

        private Category() { } //isto é necessario para que o entity materialize a entidade

        public string Name { get; private set; }


        public void Edit(string name)
        {
            Validate(name);
            Name = name;
        }

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
