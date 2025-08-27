namespace Concurso.App.gestion.Application.DTOs
{
    public class DetallePedidoDto
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string? ProductoNombre { get; set; }
    }
}
