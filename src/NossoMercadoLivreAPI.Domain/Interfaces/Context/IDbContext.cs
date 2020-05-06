using Microsoft.EntityFrameworkCore;
using System;

namespace NossoMercadoLivreAPI.Domain.Interfaces.Context
{
    public interface IDbContext : IDisposable
    {
        DbContext Instance { get; }
    }
}
