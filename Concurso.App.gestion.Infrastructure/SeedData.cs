using Concurso.App.gestion.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Concurso.App.gestion.Infrastructure
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.Migrate();

            if (!context.Usuario.Any())
            {
                var usuarios = new List<Usuario>
                {
                    new Usuario { Nombre = "Admin", Correo = "admin@mvm.com" },
                    new Usuario { Nombre = "Juan Pérez", Correo = "juan.perez@email.com" },
                    new Usuario { Nombre = "Ana López", Correo = "ana.lopez@email.com" }
                };
                context.Usuario.AddRange(usuarios);
                context.SaveChanges();
            }

            if (!context.Producto.Any())
            {
                var productos = new List<Producto>
                {
                    new Producto { Nombre = "Laptop", Descripcion = "Laptop profesional", Precio = 1200, Stock = 10 },
                    new Producto { Nombre = "Mouse", Descripcion = "Mouse óptico", Precio = 25, Stock = 100 },
                    new Producto { Nombre = "Teclado", Descripcion = "Teclado mecánico", Precio = 80, Stock = 50 }
                };
                context.Producto.AddRange(productos);
                context.SaveChanges();
            }

            if (!context.Pedido.Any())
            {
                var usuario = context.Usuario.First();
                var pedido = new Pedido { Fecha = DateTime.Now.AddDays(-2), Total = 1300, UsuarioId = usuario.Id };
                context.Pedido.Add(pedido);
                context.SaveChanges();

                var producto1 = context.Producto.First();
                var producto2 = context.Producto.Skip(1).First();
                context.DetallePedido.AddRange(new List<DetallePedido>
                {
                    new DetallePedido { PedidoId = pedido.Id, ProductoId = producto1.Id, Cantidad = 1, PrecioUnitario = 1200 },
                    new DetallePedido { PedidoId = pedido.Id, ProductoId = producto2.Id, Cantidad = 4, PrecioUnitario = 25 }
                });
                context.SaveChanges();
            }
        }
    }
}
