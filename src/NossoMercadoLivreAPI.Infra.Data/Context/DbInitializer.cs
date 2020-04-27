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

            if (!await context.Profile.AnyAsync())
            {
                var profiles = new List<ProfileEntity>()
                {
                    new ProfileEntity() { Id = 1, Description = "Administrador" },
                    new ProfileEntity() { Id = 2, Description = "Usuário" },
                };

                await context.AddRangeAsync(profiles);
                await context.SaveChangesAsync();

                var commandText = "SELECT setval('profile_id_seq', 2)";
                await context.Database.ExecuteSqlRawAsync(commandText);
            }

            if (!await context.User.AnyAsync())
            {
                var users = new List<UserEntity>()
                {
                    new UserEntity() { Id = 1, FullName = "Primeiro usuário", Document = "3454634", PhoneNumber = "34997276638", Email = "user@login.com", PasswordHash = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5" },
                    new UserEntity() { Id = 2, FullName = "Segundo usuário", Document = "3454633", PhoneNumber = "34994276530", Email = "user2@login.com", PasswordHash = "5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5" }
                };

                await context.AddRangeAsync(users);
                await context.SaveChangesAsync();

                var commandText = "SELECT setval('user_id_seq', 2)";
                await context.Database.ExecuteSqlRawAsync(commandText);
            }

            if (!await context.UserProfile.AnyAsync())
            {
                var userProfiles = new List<UserProfileEntity>()
                {
                    new UserProfileEntity() { UserId = 1, ProfileId = 1 },
                    new UserProfileEntity() { UserId = 1, ProfileId = 2 },
                    new UserProfileEntity() { UserId = 2, ProfileId = 2 }
                };

                await context.AddRangeAsync(userProfiles);
                await context.SaveChangesAsync();
            }
        }
    }
}
