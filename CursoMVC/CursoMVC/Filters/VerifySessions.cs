using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
using CursoMVC.Controllers;

namespace CursoMVC.Filters
{
    public class VerifySessions : ActionFilterAttribute // esto es herencia en c#
    {
        
        // con override le estoy diciendo que me sobreescriba el metodo que heredo del padre,
        // le estoy queriendo decir que primero en ese metoodo va hacer lo que yo quiero y despues lo que tiene el padre en el metodo
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oHC_USUARIOS = (HC_USUARIOS)HttpContext.Current.Session["User"];
            if (oHC_USUARIOS == null )
            {
                if (filterContext.Controller is AccessController==false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            else
            {
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}