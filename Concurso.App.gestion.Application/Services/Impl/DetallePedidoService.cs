using AutoMapper;
using Concurso.App.gestion.Application.DTOs;
using Concurso.App.gestion.Domain.Entities;
using Concurso.App.gestion.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Concurso.App.gestion.Application.Services.Impl
{
    public class DetallePedidoService : IDetallePedidoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DetallePedidoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DetallePedidoDto>> GetAllAsync()
        {
            var detalles = await _context.DetallePedido.Include(d => d.Producto).ToListAsync();
            return _mapper.Map<IEnumerable<DetallePedidoDto>>(detalles);
        }

        public async Task<DetallePedidoDto?> GetByIdAsync(int id)
        {
            var detalle = await _context.DetallePedido.Include(d => d.Producto).FirstOrDefaultAsync(d => d.Id == id);
            return detalle == null ? null : _mapper.Map<DetallePedidoDto>(detalle);
        }

        public async Task<DetallePedidoDto> CreateAsync(DetallePedidoDto detalleDto)
        {
            var detalle = _mapper.Map<DetallePedido>(detalleDto);
            _context.DetallePedido.Add(detalle);
            await _context.SaveChangesAsync();
            return _mapper.Map<DetallePedidoDto>(detalle);
        }

        public async Task<DetallePedidoDto> UpdateAsync(DetallePedidoDto detalleDto)
        {
            var detalle = await _context.DetallePedido.FindAsync(detalleDto.Id);
            if (detalle == null) throw new Exception("DetallePedido no encontrado");
            _mapper.Map(detalleDto, detalle);
            await _context.SaveChangesAsync();
            return _mapper.Map<DetallePedidoDto>(detalle);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var detalle = await _context.DetallePedido.FindAsync(id);
            if (detalle == null) return false;
            _context.DetallePedido.Remove(detalle);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
