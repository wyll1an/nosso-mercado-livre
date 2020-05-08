using NossoMercadoLivreAPI.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace NossoMercadoLivreAPI.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository 
    {
        Task<Category> InsertAsync(Category entity);
        bool CheckCategoryIsUnique(string name);
    }
}
