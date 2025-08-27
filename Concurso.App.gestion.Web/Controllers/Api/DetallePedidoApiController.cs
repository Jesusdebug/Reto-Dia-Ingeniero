using Concurso.App.gestion.Application.DTOs;
using Concurso.App.gestion.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Concurso.App.gestion.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetallePedidoApiController : ControllerBase
    {
        private readonly IDetallePedidoService _detallePedidoService;
        public DetallePedidoApiController(IDetallePedidoService detallePedidoService)
        {
            _detallePedidoService = detallePedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedidoDto>>> GetAll() => Ok(await _detallePedidoService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedidoDto>> GetById(int id)
        {
            var detalle = await _detallePedidoService.GetByIdAsync(id);
            return detalle == null ? NotFound() : Ok(detalle);
        }

        [HttpPost]
        public async Task<ActionResult<DetallePedidoDto>> Create([FromBody] DetallePedidoDto detalle)
        {
            var created = await _detallePedidoService.CreateAsync(detalle);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DetallePedidoDto>> Update(int id, [FromBody] DetallePedidoDto detalle)
        {
            if (id != detalle.Id) return BadRequest();
            var updated = await _detallePedidoService.UpdateAsync(detalle);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _detallePedidoService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
