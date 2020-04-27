using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using NossoMercadoLivreAPI.Domain.Entities;

namespace NossoMercadoLivreAPI.Infra.Data.Mapping
{
    public class ProfileMap : IEntityTypeConfiguration<ProfileEntity>
    {
        public void Configure(EntityTypeBuilder<ProfileEntity> builder)
        {
            builder.ToTable("profile");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(c => c.Description).HasColumnName("description").HasMaxLength(255).IsRequired();
            builder.Property(c => c.CreatedDate).HasColumnName("created_date").IsRequired();
            builder.Property(c => c.UpdatedDate).HasColumnName("updated_date").IsRequired();
        }
    }
}
