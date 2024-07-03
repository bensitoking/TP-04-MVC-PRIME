using System.Diagnostics;
using System.Timers;
using Microsoft.AspNetCore.Components.Forms;
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
    public IActionResult SelectPaquete (string? error)
    {
        ViewBag.ListaAereos = ORTWorld.ListaAereos;
        ViewBag.ListaDestinos = ORTWorld.ListaDestinos;
        ViewBag.ListaExcursiones = ORTWorld.ListaExcursiones;
        ViewBag.ListaHoteles = ORTWorld.ListaHoteles;
        if (error != null) {
            ViewBag.MensajeError = error;
        }
        return View();
    }

    private static bool ValidarPaquete(int Destino, int Hotel, int Aereo, int Excursion)
    {
        if (Destino > ORTWorld.ListaDestinos.Count || Destino < 1)
        {
            return false;
        }
        if (Hotel > ORTWorld.ListaHoteles.Count || Hotel < 1)
        {
            return false;
        }
        if (Aereo > ORTWorld.ListaAereos.Count || Hotel < 1)
        {
            return false;
        }
        if (Excursion > ORTWorld.ListaExcursiones.Count || Hotel < 1)
        {
            return false;
        }
        return true;
    }

    public IActionResult GuardarPaquete (int Destino, int Hotel, int Aereo, int Excursion)
    {
        bool exito;
        if (ValidarPaquete(Destino,Hotel,Aereo,Excursion))
        {
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
        else
        {
            return RedirectToAction("SelectPaquete", new { error = "Error, ingrese nuevamente" });
        }
    }
}
