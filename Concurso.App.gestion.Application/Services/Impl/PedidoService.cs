using AutoMapper;
using Concurso.App.gestion.Application.DTOs;
using Concurso.App.gestion.Domain.Entities;
using Concurso.App.gestion.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Concurso.App.gestion.Application.Services.Impl
{
    public class PedidoService : IPedidoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PedidoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PedidoDto>> GetAllAsync()
        {
            var pedidos = await _context.Pedido.Include(p => p.Usuario).ToListAsync();
            return _mapper.Map<IEnumerable<PedidoDto>>(pedidos);
        }

        public async Task<PedidoDto?> GetByIdAsync(int id)
        {
            var pedido = await _context.Pedido.Include(p => p.Usuario).FirstOrDefaultAsync(p => p.Id == id);
            return pedido == null ? null : _mapper.Map<PedidoDto>(pedido);
        }

        public async Task<PedidoDto> CreateAsync(PedidoDto pedidoDto)
        {
            var pedido = _mapper.Map<Pedido>(pedidoDto);
            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();
            return _mapper.Map<PedidoDto>(pedido);
        }

        public async Task<PedidoDto> UpdateAsync(PedidoDto pedidoDto)
        {
            var pedido = await _context.Pedido.FindAsync(pedidoDto.Id);
            if (pedido == null) throw new Exception("Pedido no encontrado");
            _mapper.Map(pedidoDto, pedido);
            await _context.SaveChangesAsync();
            return _mapper.Map<PedidoDto>(pedido);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null) return false;
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
