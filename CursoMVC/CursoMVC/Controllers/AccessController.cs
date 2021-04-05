using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
namespace CursoMVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            ViewBag.Title = "Login";
            return View();
        }

        public ActionResult Enter(string user, string pass)
        {
            try
            {
                using (Entities objDB = new Entities() )
                {
                    var lst = from u in objDB.HC_USUARIOS
                              where u.CORREO == user && u.CLAVE == pass && u.ID_ESTADO == 1
                              select u;
                    if (lst.Count() > 0)
                    {
                        Session["User"] = lst.First();
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario Invalido :(");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :( "+ex.Message);// crea un metodo de resultado de contenido utilizando una cadena
            }
        }

        

    }
}