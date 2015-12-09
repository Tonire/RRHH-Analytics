using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;

namespace MVCApp.Controllers
{
    public class SuperController : Controller
    {
        //
        // GET: /Super/

        public ActionResult Index()
        {
            //Comprobamos que aun no se ha realizado la configuración de la aplicacion
            AparienciaCEN apariencia = new AparienciaCEN();
            if (!apariencia.GetApariencia(0, 3).Any()) //Si se cumple es que aun no hemos insertado nada en apariencia
            {
                
                return RedirectToAction("Index", "Instalacion");
            }
            if (!User.IsInRole("SuperAdministrador"))
                return RedirectToAction("Login", "Account");

            return View();
        }

    }
}
