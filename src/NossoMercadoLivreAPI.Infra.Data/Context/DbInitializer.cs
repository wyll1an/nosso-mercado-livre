using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NossoMercadoLivreAPI.Domain.Interfaces.Context;
using System;
using System.Threading.Tasks;

namespace NossoMercadoLivreAPI.Infra.Data.Context
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<IDbContext>();
            await context.Instance.Database.MigrateAsync();
        }
    }
}
