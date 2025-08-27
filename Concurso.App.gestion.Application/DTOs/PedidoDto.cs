namespace Concurso.App.gestion.Application.DTOs
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int UsuarioId { get; set; }
        public string? UsuarioNombre { get; set; }
    }
}
