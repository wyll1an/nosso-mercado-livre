using Microsoft.EntityFrameworkCore;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Infra.Data.Mapping;

namespace NossoMercadoLivreAPI.Infra.Data.Context
{
    public class ContextDb : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }

        public ContextDb(DbContextOptions<ContextDb> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Category>(new CategoryMap().Configure);
        }
    }
}
