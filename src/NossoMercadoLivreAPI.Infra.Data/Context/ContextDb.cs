using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using NossoMercadoLivreAPI.Domain.Entities;
using NossoMercadoLivreAPI.Infra.Data.Mapping;
using System.Threading.Tasks;
using NossoMercadoLivreAPI.Domain.Entities.Base;
using System.Linq;
using System.Threading;

namespace NossoMercadoLivreAPI.Infra.Data.Context
{
    public class ContextDb : DbContext
    {
        public DbSet<UserEntity> User { get; set; }
        public DbSet<ProfileEntity> Profile { get; set; }
        public DbSet<UserProfileEntity> UserProfile { get; set; }


        private bool _rollBack;
        private IDbContextTransaction Transaction { get; set; }

        public ContextDb(DbContextOptions<ContextDb> options) :
            base(options)
        {
        }

        #region Métodos de Transação

        public async Task<IDbContextTransaction> BeginAsync() => Transaction ?? (Transaction = await this.Database.BeginTransactionAsync());

        public async Task CommitAsync()
        {
            if (Transaction != null && !_rollBack)
            {
                await Transaction.CommitAsync();
                await Transaction.DisposeAsync();
                Transaction = null;
            }
        }

        public async Task RollBackAsync()
        {
            if (Transaction != null && !_rollBack)
            {
                await Transaction.RollbackAsync();
                _rollBack = true;
            }
        }

        #endregion


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(_configuration.GetConnectionString("NossoMercadoLivreAPI_DB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<ProfileEntity>(new ProfileMap().Configure);
            modelBuilder.Entity<UserProfileEntity>(new UserProfileMap().Configure);
        }
    }
}
