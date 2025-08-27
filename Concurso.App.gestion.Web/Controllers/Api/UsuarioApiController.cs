using Concurso.App.gestion.Application.DTOs;
using Concurso.App.gestion.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Concurso.App.gestion.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioApiController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioApiController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetAll() => Ok(await _usuarioService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetById(int id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            return usuario == null ? NotFound() : Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Create([FromBody] UsuarioDto usuario)
        {
            var created = await _usuarioService.CreateAsync(usuario);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioDto>> Update(int id, [FromBody] UsuarioDto usuario)
        {
            if (id != usuario.Id) return BadRequest();
            var updated = await _usuarioService.UpdateAsync(usuario);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _usuarioService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
