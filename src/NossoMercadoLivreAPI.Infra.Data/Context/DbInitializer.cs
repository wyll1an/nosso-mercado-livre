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
                    new User(1, "user@login.com", "$2a$11$PdoQ9MyLH5D6HEAhqXI0i.X1AFOyh9d7u73OHs4mp6DZWcdvttTQu"),
                    new User(2, "user2@login.com", "$2a$11$PdoQ9MyLH5D6HEAhqXI0i.X1AFOyh9d7u73OHs4mp6DZWcdvttTQu")
                };

                await context.AddRangeAsync(users);
                await context.SaveChangesAsync();

                var commandText = $"SELECT setval('user_id_seq', {users.Count})";
                await context.Database.ExecuteSqlRawAsync(commandText);
            }
        }
    }
}
