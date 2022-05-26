using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP5_Kristal.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace TP5_Kristal.Controllers
{
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

        public IActionResult Tutorial()
        {
            return View();
        }
         public IActionResult Comenzar()
        {
            Escape NuevoJuego = new Escape();
            // Save

            var str = JsonConvert.SerializeObject(NuevoJuego);
            HttpContext.Session.SetString("Juego", str);

            return View("Habitacion"+NuevoJuego.EstadoJuego);
        }

        [HttpPost]
        public IActionResult Habitacion(int Sala, string Clave)
        {
            // Retrieve
            var str = HttpContext.Session.GetString("Juego");
            Escape Juego = JsonConvert.DeserializeObject<Escape>(str);

            if (Sala>Juego.EstadoJuego)
            {
                ViewBag.MensajeError="La sala a la cual hace referencia aun no puede ser resuelta. Resuelva primero las anteriores";
                return View("Habitacion"+Juego.EstadoJuego);    
            }
            else 
            {
                
                if (Juego.ResolverSala(Sala, Clave.Trim().ToUpper()))
                {
                    if (Juego.EstadoJuego== 5) return View("victoria");
                        else return View("Habitacion"+Juego.EstadoJuego); 
                }
                else
                {
                    ViewBag.MensajeError="La clave ingresada es Incorrectra";
                    return View("Habitacion"+Juego.EstadoJuego);
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
