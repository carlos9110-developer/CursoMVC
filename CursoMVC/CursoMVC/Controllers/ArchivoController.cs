using CursoMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    public class ArchivoController : Controller
    {
        // GET: Archivo
        public ActionResult Index()
        {
            if (TempData["Message"] !=null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ArchivoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index",model);
            }
            string RutaSitio = Server.MapPath("~/");
            string PathArchivo1 = Path.Combine(RutaSitio+"/Files/archivo1.png");
            string PathArchivo2 = Path.Combine(RutaSitio+"/Files/archivo2.png");

            model.Archivo1.SaveAs(PathArchivo1);
            model.Archivo2.SaveAs(PathArchivo2);
            @TempData["Message"] = "Se cargaron los archivos";// este mensaje queda en el sistema mientras sigamos en el controlador y puede ser utilizado por otros metodos
            return RedirectToAction("Index");
        }
    }
}