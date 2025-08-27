namespace Concurso.App.gestion.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
        public ICollection<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();
    }
}
