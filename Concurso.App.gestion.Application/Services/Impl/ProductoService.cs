using AutoMapper;
using Concurso.App.gestion.Application.DTOs;
using Concurso.App.gestion.Domain.Entities;
using Concurso.App.gestion.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Concurso.App.gestion.Application.Services.Impl
{
    public class ProductoService : IProductoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductoDto>> GetAllAsync()
        {
            var productos = await _context.Producto.ToListAsync();
            return _mapper.Map<IEnumerable<ProductoDto>>(productos);
        }

        public async Task<ProductoDto?> GetByIdAsync(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            return producto == null ? null : _mapper.Map<ProductoDto>(producto);
        }

        public async Task<ProductoDto> CreateAsync(ProductoDto productoDto)
        {
            var producto = _mapper.Map<Producto>(productoDto);
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductoDto>(producto);
        }

        public async Task<ProductoDto> UpdateAsync(ProductoDto productoDto)
        {
            var producto = await _context.Producto.FindAsync(productoDto.Id);
            if (producto == null) throw new Exception("Producto no encontrado");
            _mapper.Map(productoDto, producto);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductoDto>(producto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null) return false;
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
