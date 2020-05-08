using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Interfaces.Repositories;
using NossoMercadoLivreAPI.Infra.Data.Context;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace NossoMercadoLivreAPI.Infra.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ContextDb _context;
        public CategoryRepository(ContextDb context)
        {
            _context = context;
        }


        public async Task<Category> InsertAsync(Category entity)
        {
            using (var dbContextTransaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Set<Category>().AddAsync(entity);
                    await _context.SaveChangesAsync();

                    await dbContextTransaction.CommitAsync();

                    return entity;
                }
                catch (Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();
                    throw ex;
                }
            }
        }
        public bool CheckCategoryIsUnique(string name)
        {
            return _context.Set<Category>().Where(u => u.Name == name).Any();
        }
    }
}
