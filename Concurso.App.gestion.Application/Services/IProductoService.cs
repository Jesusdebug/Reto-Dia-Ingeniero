using Concurso.App.gestion.Application.DTOs;

namespace Concurso.App.gestion.Application.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoDto>> GetAllAsync();
        Task<ProductoDto?> GetByIdAsync(int id);
        Task<ProductoDto> CreateAsync(ProductoDto producto);
        Task<ProductoDto> UpdateAsync(ProductoDto producto);
        Task<bool> DeleteAsync(int id);
    }
}
