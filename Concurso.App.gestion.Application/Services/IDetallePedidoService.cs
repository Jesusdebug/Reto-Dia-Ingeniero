using Concurso.App.gestion.Application.DTOs;

namespace Concurso.App.gestion.Application.Services
{
    public interface IDetallePedidoService
    {
        Task<IEnumerable<DetallePedidoDto>> GetAllAsync();
        Task<DetallePedidoDto?> GetByIdAsync(int id);
        Task<DetallePedidoDto> CreateAsync(DetallePedidoDto detalle);
        Task<DetallePedidoDto> UpdateAsync(DetallePedidoDto detalle);
        Task<bool> DeleteAsync(int id);
    }
}
