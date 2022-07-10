using Microsoft.AspNetCore.Mvc;

namespace Pedidos.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Linea()
        {
            ViewBag.xValues = new List<int>{50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150};
            ViewBag.yValues = new List<int> { 7, 8, 8, 9, 9, 9, 10, 11, 14, 14, 15 };

            return View();
        }

        public IActionResult Barra()
        {
            return View();
        }

        public IActionResult Pastel()
        {
            return View();
        }

        public FileResult DownloadPdf()
        {
            var filBytes = System.IO.File.ReadAllBytes(@"C:\Users\Cadhe\Downloads\Liga.txt");
            string fileName = "Graficas.pdf";
            return File(filBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpPost]
        public JsonResult Data()
        {
            var xValues = new List<string> { "Italy", "France", "Spain", "USA", "Argentina" };
            var yValues = new List<int> { 55, 49, 44, 24, 15 };
            var barColors = new List<string> { "#b91d47", "#00aba9", "brown", "#e8c3b9", "#1e7145" };

            var lst = new
            {
                xValues,
                yValues,
                barColors,
            };

            return Json(lst);


        }
    }
}
