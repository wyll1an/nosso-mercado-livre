using FluentValidation;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Xunit;

namespace NossoMercadoLivreAPI.UnitTest.ContextTest
{
    public class ContextDbTest
    {
        protected ContextDb _context;

        public ContextDbTest(ContextDb context = null)
        {
           _context = context ?? GetInMemoryDBContext();
        }
        protected ContextDb GetInMemoryDBContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ContextDb>();
            builder.EnableSensitiveDataLogging();
            var options = builder.UseInMemoryDatabase("test").UseInternalServiceProvider(serviceProvider).Options;

            ContextDb dbContext = new ContextDb(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}
