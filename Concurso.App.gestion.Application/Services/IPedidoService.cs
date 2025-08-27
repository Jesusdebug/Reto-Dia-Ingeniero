using Concurso.App.gestion.Application.DTOs;

namespace Concurso.App.gestion.Application.Services
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoDto>> GetAllAsync();
        Task<PedidoDto?> GetByIdAsync(int id);
        Task<PedidoDto> CreateAsync(PedidoDto pedido);
        Task<PedidoDto> UpdateAsync(PedidoDto pedido);
        Task<bool> DeleteAsync(int id);
    }
}
