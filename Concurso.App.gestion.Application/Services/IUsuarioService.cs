using Concurso.App.gestion.Application.DTOs;

namespace Concurso.App.gestion.Application.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> GetAllAsync();
        Task<UsuarioDto?> GetByIdAsync(int id);
        Task<UsuarioDto> CreateAsync(UsuarioDto usuario);
        Task<UsuarioDto> UpdateAsync(UsuarioDto usuario);
        Task<bool> DeleteAsync(int id);
    }
}
