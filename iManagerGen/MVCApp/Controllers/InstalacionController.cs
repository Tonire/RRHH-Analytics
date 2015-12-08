using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using MVCApp.Filters;
using MVCApp.Models;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;

namespace MVCApp.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class InstalacionController : Controller
    {
        //
        // GET: /Instalacion/
        [AllowAnonymous]
        public ActionResult Index()
        {
            if(TempData["Instalacion"]==null){
                return RedirectToAction("Index", "Super");
            }
            return View();
        }

        //
        // POST: /Instalacion/

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(InstalacionModel model)
        {
            if (ModelState.IsValid)
            {
                // Intento de registrar al usuario
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserEmail, model.Password);
                    Roles.AddUserToRole(model.UserEmail, "SuperAdministrador"); // user in role A 

                    /*Creamos la apariencia*/
                    AparienciaCEN aparienciaCEN = new AparienciaCEN();
                    aparienciaCEN.CrearApariencia(model.SiteName,model.SiteLogo,model.SuperColor,model.AdminColor,model.EmplColor);

                    /*Creamos el usuario*/
                    SuperAdministradorCEN superCEN = new SuperAdministradorCEN();
                    superCEN.New_(model.UserEmail,model.DNI,model.Password,model.UserName,model.UserLastName,DateTime.Now);

                    WebSecurity.Login(model.UserEmail, model.Password);
                    return RedirectToAction("Index", "Super");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // Vaya a http://go.microsoft.com/fwlink/?LinkID=177550 para
            // obtener una lista completa de códigos de estado.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "El nombre de usuario ya existe. Escriba un nombre de usuario diferente.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Ya existe un nombre de usuario para esa dirección de correo electrónico. Escriba una dirección de correo electrónico diferente.";

                case MembershipCreateStatus.InvalidPassword:
                    return "La contraseña especificada no es válida. Escriba un valor de contraseña válido.";

                case MembershipCreateStatus.InvalidEmail:
                    return "La dirección de correo electrónico especificada no es válida. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "La respuesta de recuperación de la contraseña especificada no es válida. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "La pregunta de recuperación de la contraseña especificada no es válida. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.InvalidUserName:
                    return "El nombre de usuario especificado no es válido. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.ProviderError:
                    return "El proveedor de autenticación devolvió un error. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema.";

                case MembershipCreateStatus.UserRejected:
                    return "La solicitud de creación de usuario se ha cancelado. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema.";

                default:
                    return "Error desconocido. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema.";
            }
        }

    }
}
