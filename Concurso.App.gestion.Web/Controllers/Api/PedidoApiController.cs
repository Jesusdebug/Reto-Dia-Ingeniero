using Concurso.App.gestion.Application.DTOs;
using Concurso.App.gestion.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Concurso.App.gestion.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoApiController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        public PedidoApiController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDto>>> GetAll() => Ok(await _pedidoService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDto>> GetById(int id)
        {
            var pedido = await _pedidoService.GetByIdAsync(id);
            return pedido == null ? NotFound() : Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult<PedidoDto>> Create([FromBody] PedidoDto pedido)
        {
            var created = await _pedidoService.CreateAsync(pedido);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidoDto>> Update(int id, [FromBody] PedidoDto pedido)
        {
            if (id != pedido.Id) return BadRequest();
            var updated = await _pedidoService.UpdateAsync(pedido);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _pedidoService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
