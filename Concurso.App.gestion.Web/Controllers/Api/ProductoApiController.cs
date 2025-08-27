using Concurso.App.gestion.Application.DTOs;
using Concurso.App.gestion.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Concurso.App.gestion.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoApiController : ControllerBase
    {
        private readonly IProductoService _productoService;
        public ProductoApiController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetAll() => Ok(await _productoService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetById(int id)
        {
            var producto = await _productoService.GetByIdAsync(id);
            return producto == null ? NotFound() : Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductoDto>> Create([FromBody] ProductoDto producto)
        {
            var created = await _productoService.CreateAsync(producto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductoDto>> Update(int id, [FromBody] ProductoDto producto)
        {
            if (id != producto.Id) return BadRequest();
            var updated = await _productoService.UpdateAsync(producto);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _productoService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
