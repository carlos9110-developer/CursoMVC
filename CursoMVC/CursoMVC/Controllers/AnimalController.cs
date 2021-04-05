using CursoMVC.Models;
using CursoMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    public class AnimalController : Controller
    {
        // GET: Animal
        public ActionResult Index()
        {
            List<AnimalViewModel> lstAnimalViewModel = new List<AnimalViewModel>();
            List<SelectListItem> lstSelectListItem = new List<SelectListItem>();
            
            using (Entities db = new Entities())
            {
                lstAnimalViewModel = 
                    (from c in db.HC_CLASE_ANIMAL
                       select new AnimalViewModel
                       {
                           Id = c.ID,
                           Nombre = c.NOMBRE
                    }).ToList();
            }

            foreach (var item in lstAnimalViewModel)
            {
                SelectListItem objSelectListItem = new SelectListItem();
                objSelectListItem.Value = item.Id.ToString();
                objSelectListItem.Text = item.Nombre;
                lstSelectListItem.Add(objSelectListItem);
            }
            return View(lstSelectListItem);
        }

        [HttpGet]
        public JsonResult ObtenerAnimales(int IdAnimalClase)
        {
            List<ElementJsonIntKey> lstElementJsonIntKey = new List<ElementJsonIntKey>();
            using (Entities objDB = new Entities())
            {
                using (Entities db = new Entities())
                {
                    lstElementJsonIntKey =
                        (from a in db.HC_ANIMAL
                         where a.ID_ANIMAL_CLASE == IdAnimalClase
                         select new ElementJsonIntKey
                         {
                             Value = a.ID,
                             Text = a.NOMBRE
                         }).ToList();
                }
            }
            return Json(lstElementJsonIntKey,JsonRequestBehavior.AllowGet);
        }

        public class ElementJsonIntKey
        {
            public decimal Value { get; set; }

            public string Text { get; set; }
        }
    }
}