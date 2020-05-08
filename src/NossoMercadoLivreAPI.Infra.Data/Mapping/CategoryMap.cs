using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NossoMercadoLivreAPI.Domain.Entities;

namespace NossoMercadoLivreAPI.Infra.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();
            builder.Property(c => c.Name).HasColumnName("name").IsRequired();
            builder.HasIndex(c => c.Name).IsUnique();

            builder.HasOne(c => c.category).WithMany(c => c.Categories).HasForeignKey(c => c.CategoryId);
        }
    }
}
