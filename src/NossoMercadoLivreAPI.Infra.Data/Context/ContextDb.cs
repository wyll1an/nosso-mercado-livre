using Microsoft.EntityFrameworkCore;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Domain.Interfaces.Context;
using NossoMercadoLivreAPI.Infra.Data.Mapping;

namespace NossoMercadoLivreAPI.Infra.Data.Context
{
    public class ContextDb : DbContext, IDbContext
    {
        public DbSet<User> User { get; set; }

        public DbContext Instance => this;

        public ContextDb(DbContextOptions<ContextDb> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
        }
    }
}
