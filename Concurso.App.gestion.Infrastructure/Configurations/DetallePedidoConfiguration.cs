using Concurso.App.gestion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Concurso.App.gestion.Infrastructure.Configurations
{
    public class DetallePedidoConfiguration : IEntityTypeConfiguration<DetallePedido>
    {
        public void Configure(EntityTypeBuilder<DetallePedido> builder)
        {
            builder.ToTable("DetallePedido");
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Cantidad).IsRequired();
            builder.Property(d => d.PrecioUnitario).HasColumnType("decimal(18,2)");
            builder.HasOne(d => d.Pedido)
                   .WithMany(p => p.Detalles)
                   .HasForeignKey(d => d.PedidoId);
            builder.HasOne(d => d.Producto)
                   .WithMany(p => p.Detalles)
                   .HasForeignKey(d => d.ProductoId);
        }
    }
}
