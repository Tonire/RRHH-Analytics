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
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //Comprobamos que aun no se ha realizado la configuración de la aplicacion
            AparienciaCEN apariencia = new AparienciaCEN();
            if (!apariencia.GetApariencia(0, 3).Any()) //Si se cumple es que aun no hemos insertado nada en apariencia
            {
                TempData["Instalacion"] = true;
                return RedirectToAction("Index", "Instalacion");
            }
            if (!Request.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            /*Si llegamos aquí es que vamos a devolver la vista
            Lo que vamos a hacer es pasarle los datos del usuario actual a la vista*/
            UsuarioCEN usuario = new UsuarioCEN();
            UsuarioEN usu = usuario.GetUsuarioByEmail(User.Identity.Name);
            //Una vez recuperado pasamos a la vista el nombre del usuario
            ViewData["NombreUsuario"] = usu.Nombre + " " + usu.Apellidos;
            

            //Ahora vamos a recuperar el numero de mensajes recibidos del usuario y pasarlo a la vista
            MensajeCEN mensajes= new MensajeCEN();
            IList<MensajeEN> numMensajes=mensajes.GetMensajesByDestinatario(User.Identity.Name);

            ViewData["Emails"] = numMensajes.Count;

            return View();
        }

    }
}
