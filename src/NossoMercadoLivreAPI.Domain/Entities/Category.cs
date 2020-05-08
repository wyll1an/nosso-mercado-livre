using NossoMercadoLivreAPI.Domain.Request;
using System.Collections.Generic;

namespace NossoMercadoLivreAPI.Domain.Entities
{
    public class Category
    {
        public Category(CategoryRequest request)
        {
            Name = request.Name;
            CategoryId = request.CategoryId;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public long? CategoryId { get; private set; }
        public Category category { get; private set; }
        public ICollection<Category> Categories { get; private set; }
    }
}
