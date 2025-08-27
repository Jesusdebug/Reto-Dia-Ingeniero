using Concurso.App.gestion.Application.DTOs;
using Concurso.App.gestion.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Concurso.App.gestion.Web.Controllers
{
    public class DetallePedidoController : Controller
    {
        private readonly IDetallePedidoService _detallePedidoService;
        public DetallePedidoController(IDetallePedidoService detallePedidoService)
        {
            _detallePedidoService = detallePedidoService;
        }

        // GET: DetallePedido
        public async Task<IActionResult> Index()
        {
            var detalles = await _detallePedidoService.GetAllAsync();
            return View(detalles);
        }

        // GET: DetallePedido/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var detalle = await _detallePedidoService.GetByIdAsync(id);
            if (detalle == null) return NotFound();
            return View(detalle);
        }

        // GET: DetallePedido/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetallePedido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DetallePedidoDto detalle)
        {
            if (ModelState.IsValid)
            {
                await _detallePedidoService.CreateAsync(detalle);
                return RedirectToAction(nameof(Index));
            }
            return View(detalle);
        }

        // GET: DetallePedido/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var detalle = await _detallePedidoService.GetByIdAsync(id);
            if (detalle == null) return NotFound();
            return View(detalle);
        }

        // POST: DetallePedido/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DetallePedidoDto detalle)
        {
            if (id != detalle.Id) return NotFound();
            if (ModelState.IsValid)
            {
                await _detallePedidoService.UpdateAsync(detalle);
                return RedirectToAction(nameof(Index));
            }
            return View(detalle);
        }

        // GET: DetallePedido/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var detalle = await _detallePedidoService.GetByIdAsync(id);
            if (detalle == null) return NotFound();
            return View(detalle);
        }

        // POST: DetallePedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _detallePedidoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
