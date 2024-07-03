using System.Diagnostics;
using System.Timers;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;

namespace PrimerProyecto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Paquetes = ORTWorld.Paquetes;
        return View();
    }
    public IActionResult SelectPaquete ()
    {
        ViewBag.ListaAereos = ORTWorld.ListaAereos;
        ViewBag.ListaDestinos = ORTWorld.ListaDestinos;
        ViewBag.ListaExcursiones = ORTWorld.ListaExcursiones;
        ViewBag.ListaHoteles = ORTWorld.ListaHoteles;
        return View();
    }
    public IActionResult GuardarPaquete (int Destino, int Hotel, int Aereo, int Excursion)
    {
        bool exito;
        Paquete NuevoPaquete = new Paquete(ORTWorld.ListaHoteles [Hotel-1], ORTWorld.ListaAereos[Aereo-1], ORTWorld.ListaExcursiones[Excursion-1]);
        exito = ORTWorld.IngresarPaquete(ORTWorld.ListaDestinos[Destino-1], NuevoPaquete);
        if(exito)
        {
            ViewBag.creacionPaquete = "Se logro crear el paquete";
        }
        else{
            ViewBag.creacionPaquete = "No se logro crear el paquete";
        }
        return RedirectToAction("Index");
    }
}
