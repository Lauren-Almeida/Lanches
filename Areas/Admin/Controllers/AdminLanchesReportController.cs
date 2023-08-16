using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Lanches.Areas.Admin.FastReportUtils;
using Lanches.Areas.Admin.Servicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lanches.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLanchesReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnv;
        private readonly RelatorioLanchesServico _relatorioLanchesServico;

        public AdminLanchesReportController(IWebHostEnvironment webHostEnv,
            RelatorioLanchesServico relatorioLanchesServico)
        {
            _webHostEnv = webHostEnv;
            _relatorioLanchesServico = relatorioLanchesServico;
        }
        public async Task<ActionResult> LanchesCategoriaReport()
        {
            var webReport = new WebReport();
            var mssqlDataConnection = new MsSqlDataConnection();

            webReport.Report.Dictionary.AddChild(mssqlDataConnection);

            webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports",
                                               "LanchesCategoria.frx"));

            var lanches = HelperFastReport.GetTable(await _relatorioLanchesServico.GetLanchesReport(), "LanchesReport");
            var categorias = HelperFastReport.GetTable(await _relatorioLanchesServico.GetCategoriasReport(), "CategoriasReport");

            webReport.Report.RegisterData(lanches, "LancheReport");
            webReport.Report.RegisterData(categorias, "CategoriasReport");
            return View(webReport);
        }

        [Route("LanchesCategoriaPDF")]
        public async Task<ActionResult> LanchesCategoriaPDF()
        {
            var webReport = new WebReport();
            var mssqlDataConnection = new MsSqlDataConnection();

            webReport.Report.Dictionary.AddChild(mssqlDataConnection);

            webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports",
                                               "lanchesCategoria.frx"));

            var lanches = HelperFastReport.GetTable(await _relatorioLanchesServico.GetLanchesReport(), "LanchesReport");
            var categorias = HelperFastReport.GetTable(await _relatorioLanchesServico.GetCategoriasReport(), "CategoriasReport");

            webReport.Report.RegisterData(lanches, "LancheReport");
            webReport.Report.RegisterData(categorias, "CategoriasReport");

            webReport.Report.Prepare();

            Stream stream = new MemoryStream();

            webReport.Report.Export(new PDFSimpleExport(), stream);
            stream.Position = 0;

            // return File(stream, "application/zip", "LancheCategoria.pdf"); baixa o pdf
            return new FileStreamResult(stream, "application/pdf"); //abre o pdf no navegador
        }
    }
}