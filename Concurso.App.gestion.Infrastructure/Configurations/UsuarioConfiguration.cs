using Concurso.App.gestion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Concurso.App.gestion.Infrastructure.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nombre).HasMaxLength(200).IsRequired(false);
            builder.Property(u => u.Correo).HasMaxLength(200).IsRequired(false);
        }
    }
}
