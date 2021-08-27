﻿using System;

namespace MyCookbook.Domain.Recipes
{
    public class Category : Entity
    {
        public Category(string name)
        {
            Validate(name);
            Name = name;
        }

        private Category() { }

        public string Name { get; private set; }

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