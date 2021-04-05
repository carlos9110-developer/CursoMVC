using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
using CursoMVC.Models.TablesViewModels;
using CursoMVC.Models.ViewModels;

namespace CursoMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            using (Entities db = new Entities())
            {
                lst = (from us in db.HC_USUARIOS
                       where us.ID_ESTADO == 1
                       orderby us.CORREO
                       select new UserTableViewModel
                       {
                           CORREO = us.CORREO,
                           ID = us.ID,
                           EDAD = us.EDAD
                       }).ToList();
            }
            return View(lst);
        }

        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (Entities db = new Entities())
            {
                HC_USUARIOS oHC_USUARIOS = new HC_USUARIOS();
                oHC_USUARIOS.ID_ESTADO   = 1;
                oHC_USUARIOS.CORREO      = model.Correo;
                oHC_USUARIOS.EDAD        = model.Edad;
                oHC_USUARIOS.CLAVE       = model.Clave;
                db.HC_USUARIOS.Add(oHC_USUARIOS);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        } 

        [HttpGet]
        public ActionResult Editar(decimal ID)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new Entities())
            {
                var oUser    = db.HC_USUARIOS.Find(ID);
                model.Id     = ID;
                model.Edad   = (decimal)oUser.EDAD;
                model.Correo = oUser.CORREO;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (Entities db = new Entities())
            {
                var oUser = db.HC_USUARIOS.Find(model.Id);
                oUser.CORREO = model.Correo;
                oUser.EDAD = model.Edad;

                if (model.Clave != null && model.Clave.Trim() != "" )
                {
                    oUser.CLAVE = model.Clave;
                }
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }

        [HttpPost]
        public ActionResult Eliminar(decimal Id)
        {
            
            using (Entities db = new Entities())
            {
                var oUser = db.HC_USUARIOS.Find(Id);
                oUser.ID_ESTADO = 3;// el estado tres es eliminado, se recomienda siempre tener un borrado logico de los registros
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }

    }
}