using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using NossoMercadoLivreAPI.Domain.Entities;
using System.Threading.Tasks;

namespace NossoMercadoLivreAPI.Infra.Data.Context
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ContextDb>();
            await context.Database.MigrateAsync();

            if (!await context.User.AnyAsync())
            {
                var users = new List<User>()
                {
                    new User(1, "Primeiro usuário", "user@login.com", "3454634", "34997276638", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5"),
                    new User(1, "Segundo usuário", "user2@login.com", "3454430", "34997276639", "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5")
                };

                await context.AddRangeAsync(users);
                await context.SaveChangesAsync();

                var commandText = $"SELECT setval('user_id_seq', {users.Count})";
                await context.Database.ExecuteSqlRawAsync(commandText);
            }
        }
    }
}
