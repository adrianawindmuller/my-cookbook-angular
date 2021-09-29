using System;

namespace MyCookbook.Domain.Recipes
{
    public class Image : Entity
    {
        public Image(string rawContent)
        {
            RawContent = rawContent;
        }

        private Image() { }

        public string RawContent { get; }

        public void Validate(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new ArgumentException("Imagem obrigatorio!", nameof(content));
            }
        }
    }
}
