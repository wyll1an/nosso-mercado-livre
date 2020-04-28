using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NossoMercadoLivreAPI.Domain.Interfaces.UnitOfWork;
using NossoMercadoLivreAPI.Infra.Data.Context;

namespace NossoMercadoLivreAPI.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextDb _context;

        public UnitOfWork(ContextDb context)
        {
            _context = context;
        }

        public async Task BeginAsync()
        {
            await _context.BeginAsync();
        }

        public async Task CommitAsync()
        {
            await _context.CommitAsync();
        }

        public async Task RollBackAsync()
        {
            await _context.RollBackAsync();
        }
    }
}
