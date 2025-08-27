using Concurso.App.gestion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Concurso.App.gestion.Infrastructure.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nombre).HasMaxLength(200).IsRequired(false);
            builder.Property(p => p.Descripcion).HasMaxLength(200).IsRequired(false);
            builder.Property(p => p.Precio).HasColumnType("decimal(10,2)");
            builder.Property(p => p.Stock).IsRequired();
        }
    }
}
