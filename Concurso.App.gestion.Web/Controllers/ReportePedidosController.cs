using Concurso.App.gestion.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using OfficeOpenXml;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace Concurso.App.gestion.Web.Controllers
{
    public class ReportePedidosController : Controller
    {
        private readonly IPedidoService _pedidoService;
        private readonly IUsuarioService _usuarioService;

        public ReportePedidosController(IPedidoService pedidoService, IUsuarioService usuarioService)
        {
            _pedidoService = pedidoService;
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var pedidos = await _pedidoService.GetAllAsync();
            // Ventas por mes
            var ventasPorMes = pedidos
                .GroupBy(p => p.Fecha.ToString("yyyy-MM"))
                .OrderBy(g => g.Key)
                .Select(g => new { Mes = g.Key, Total = g.Sum(x => x.Total) })
                .ToList();
            var meses = ventasPorMes.Select(x => DateTime.ParseExact(x.Mes + "-01", "yyyy-MM-dd", CultureInfo.InvariantCulture).ToString("MMM yyyy", new CultureInfo("es-ES"))).ToList();
            var totales = ventasPorMes.Select(x => x.Total).ToList();
            ViewBag.MesesLabels = System.Text.Json.JsonSerializer.Serialize(meses);
            ViewBag.VentasPorMes = System.Text.Json.JsonSerializer.Serialize(totales);
            return View(pedidos);
        }

        public async Task<IActionResult> ExportarExcel()
        {
            var pedidos = await _pedidoService.GetAllAsync();
            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add("Pedidos");
            ws.Cells[1, 1].Value = "Id";
            ws.Cells[1, 2].Value = "Fecha";
            ws.Cells[1, 3].Value = "Total";
            ws.Cells[1, 4].Value = "Usuario";
            int row = 2;
            foreach (var p in pedidos)
            {
                ws.Cells[row, 1].Value = p.Id;
                ws.Cells[row, 2].Value = p.Fecha.ToString("dd/MM/yyyy");
                ws.Cells[row, 3].Value = p.Total;
                ws.Cells[row, 4].Value = p.UsuarioNombre;
                row++;
            }
            var stream = new MemoryStream(package.GetAsByteArray());
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReportePedidos.xlsx");
        }

        public async Task<IActionResult> ExportarPdf()
        {
            var pedidos = await _pedidoService.GetAllAsync();
            var ms = new MemoryStream();
            var writer = new PdfWriter(ms);
            var pdf = new PdfDocument(writer);
            var doc = new Document(pdf);
            doc.Add(new Paragraph("Reporte de Pedidos").SetBold().SetFontSize(16));
            var table = new Table(4, false);
            table.AddHeaderCell("Id");
            table.AddHeaderCell("Fecha");
            table.AddHeaderCell("Total");
            table.AddHeaderCell("Usuario");
            foreach (var p in pedidos)
            {
                table.AddCell(p.Id.ToString());
                table.AddCell(p.Fecha.ToString("dd/MM/yyyy"));
                table.AddCell(p.Total.ToString("C"));
                table.AddCell(p.UsuarioNombre ?? "");
            }
            doc.Add(table);
            doc.Close();
            var pdfBytes = ms.ToArray();
            return File(pdfBytes, "application/pdf", "ReportePedidos.pdf");
        }
    }
}
