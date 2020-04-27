using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NossoMercadoLivreAPI.Domain.Entities;

namespace NossoMercadoLivreAPI.Infra.Data.Mapping
{
    public class UserProfileMap : IEntityTypeConfiguration<UserProfileEntity>
    {
        public void Configure(EntityTypeBuilder<UserProfileEntity> builder)
        {
            builder.ToTable("user_profile");

            builder.HasKey(u => new { u.UserId, u.ProfileId });
            builder.Property(u => u.UserId).HasColumnName("user_id").IsRequired();
            builder.Property(u => u.ProfileId).HasColumnName("profile_id").IsRequired();
            builder.Property(c => c.CreatedDate).HasColumnName("created_date").IsRequired();
            builder.Property(c => c.UpdatedDate).HasColumnName("updated_date").IsRequired();

            builder.HasOne(u => u.User).WithMany(u => u.UserProfiles).HasForeignKey(bc => bc.UserId);
            builder.HasOne(u => u.Profile).WithMany(u => u.UserProfiles).HasForeignKey(bc => bc.ProfileId);

            builder.Ignore(u => u.Id);
        }
    }
}
