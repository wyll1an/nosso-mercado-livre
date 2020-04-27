using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NossoMercadoLivreAPI.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task BeginAsync();
        Task CommitAsync();
        Task RollBackAsync();
    }
}
