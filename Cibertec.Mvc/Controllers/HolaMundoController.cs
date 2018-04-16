using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    public class HolaMundoController : Controller
    {
        // GET: HolaMundo
        public ActionResult Index()
        {
            //return "Hola esta es mi vista <b>Hola Mundo</b>";
            return View();
        }

        public string Bienvenido(string nombre, int id = 1)
        {
            return $"Hola {nombre}, tu ID es: {id}";
        }

        public ActionResult Contador(string nombre, int veces = 1)
        {
            ViewBag.Mensaje = $"Hola {nombre}";
            ViewBag.Veces = veces;
            return View();
        }
    }
}