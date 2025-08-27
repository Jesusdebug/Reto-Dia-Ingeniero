using Concurso.App.gestion.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Concurso.App.gestion.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IPedidoService _pedidoService;
        private readonly IProductoService _productoService;

        public DashboardController(IUsuarioService usuarioService, IPedidoService pedidoService, IProductoService productoService)
        {
            _usuarioService = usuarioService;
            _pedidoService = pedidoService;
            _productoService = productoService;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            var pedidos = await _pedidoService.GetAllAsync();
            var productos = await _productoService.GetAllAsync();

            ViewBag.TotalUsuarios = usuarios.Count();
            ViewBag.TotalPedidos = pedidos.Count();
            ViewBag.TotalProductos = productos.Count();
            ViewBag.TotalVentas = pedidos.Sum(p => p.Total);

            // Pedidos por mes
            var pedidosPorMes = pedidos
                .GroupBy(p => p.Fecha.ToString("yyyy-MM"))
                .OrderBy(g => g.Key)
                .Select(g => new { Mes = g.Key, Cantidad = g.Count() })
                .ToList();

            var meses = pedidosPorMes.Select(x => DateTime.ParseExact(x.Mes + "-01", "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("MMM yyyy", new CultureInfo("es-ES"))).ToList();
            var cantidades = pedidosPorMes.Select(x => x.Cantidad).ToList();

            ViewBag.MesesLabels = System.Text.Json.JsonSerializer.Serialize(meses);
            ViewBag.PedidosPorMes = System.Text.Json.JsonSerializer.Serialize(cantidades);

            return View();
        }
    }
}
