using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    public class HomeController : Controller
    {   

        // un ActionResult, practicamente puede ser cualquier cosa (String,int,decimal,List,Una vista,etc)
        // dando clic derecho en el metodo podemos agregar la vista del respectivo controlador
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}