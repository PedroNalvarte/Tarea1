using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tarea1_Nalvarte.Models;

namespace Tarea1_Nalvarte.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public ActionResult Pago(string numeroTarjeta, DateTime fechaVencimiento, decimal montoPagar)
    {
    
    int diasAtraso = (int)(DateTime.Now - fechaVencimiento).TotalDays;
  
    decimal mora = montoPagar * (decimal)(diasAtraso * 0.005);
  
    decimal pagoFinal = montoPagar + mora;
  
    ViewBag.NumeroTarjeta = numeroTarjeta;
    ViewBag.DiasAtraso = diasAtraso;
    ViewBag.MontoPagar = montoPagar;
    ViewBag.Mora = mora;
    ViewBag.PagoFinal = pagoFinal;
    return View("Index");
    }
}
