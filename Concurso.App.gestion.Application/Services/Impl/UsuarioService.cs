using AutoMapper;
using Concurso.App.gestion.Application.DTOs;
using Concurso.App.gestion.Domain.Entities;
using Concurso.App.gestion.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Concurso.App.gestion.Application.Services.Impl
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
        {
            var usuarios = await _context.Usuario.ToListAsync();
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }

        public async Task<UsuarioDto?> GetByIdAsync(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            return usuario == null ? null : _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto> CreateAsync(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto> UpdateAsync(UsuarioDto usuarioDto)
        {
            var usuario = await _context.Usuario.FindAsync(usuarioDto.Id);
            if (usuario == null) throw new Exception("Usuario no encontrado");
            _mapper.Map(usuarioDto, usuario);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null) return false;
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
