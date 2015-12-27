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
    public class UsuariosController : BasicController
    {
        //
        // GET: /Usuarios/
        [Authorize(Roles = "SuperAdministrador, Administrador")]
        public ActionResult Index()
        {

            UsuarioCEN cen = new UsuarioCEN();
            IList<UsuarioEN> list = cen.DameTodos(0, -1).ToList();
            IEnumerable<UsuarioModels> listUsu = new AssemblerUsuarios().ConvertListENToModel(list).ToList();
            if (TempData["Creado"] !=null) {
                ViewData["Creado"] = true;
            }
            
            return View(listUsu);
        }

        //
        // GET: /Usuarios/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Usuarios/Create
        [Authorize(Roles = "SuperAdministrador, Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Usuarios/Create
        [Authorize(Roles = "SuperAdministrador, Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioModels model)
        {
            if (ModelState.IsValid) {
                // Intento de registrar al usuario
                try {
                    WebSecurity.CreateUserAndAccount(model.Email, model.Password);
                    switch(model.Rol){
                        case "0":
                            Roles.AddUserToRole(model.Email, "SuperAdministrador"); // user in role A 
                            /*Creamos el usuario*/
                            SuperAdministradorCEN superCEN = new SuperAdministradorCEN();
                            superCEN.New_(model.Email, model.DNI, model.Password, model.Nombre, model.Apellidos, DateTime.Now);
                            break;
                        case "1":
                            Roles.AddUserToRole(model.Email, "Administrador"); // user in role A 
                            /*Creamos el usuario*/
                            AdministradorCEN adminCEN = new AdministradorCEN();
                            adminCEN.New_(model.Email, model.DNI, model.Password, model.Nombre, model.Apellidos, DateTime.Now);
                            break;
                        case "2":
                            Roles.AddUserToRole(model.Email, "Empleado"); // user in role A 
                            /*Creamos el usuario*/
                            EmpleadoCEN empleadoCEN = new EmpleadoCEN();
                            empleadoCEN.New_(model.Email, model.DNI, model.Password, model.Nombre, model.Apellidos, DateTime.Now);
                            break;
                    }
                    TempData["Creado"] = true;
                    return RedirectToAction("Index");
                }
                catch (MembershipCreateUserException e) {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Usuarios/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Usuarios/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Usuarios/Delete/5
       /* [Authorize(Roles = "SuperAdministrador, Administrador")]
        public ActionResult Delete(string id)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            Roles.RemoveUserFromRoles(id, Roles.GetRolesForUser(id));
            ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(id); // deletes record from webpages_Membership table
            ((SimpleMembershipProvider)Membership.Provider).DeleteUser(id, true); // deletes record from UserProfile table
            usuarioCEN.Destroy(id);
            return View("Index");
        }*/

        //
        // POST: /Usuarios/Delete/5
        [Authorize(Roles = "SuperAdministrador, Administrador")]
        [HttpPost]
        public ActionResult Delete()
        {
            try
            {
                string id = Request["email"];
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                Roles.RemoveUserFromRoles(id, Roles.GetRolesForUser(id));
                ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(id); // deletes record from webpages_Membership table
                ((SimpleMembershipProvider)Membership.Provider).DeleteUser(id, true); // deletes record from UserProfile table
                usuarioCEN.Destroy(id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
        private static string ErrorCodeToString(MembershipCreateStatus createStatus) {
            // Vaya a http://go.microsoft.com/fwlink/?LinkID=177550 para
            // obtener una lista completa de códigos de estado.
            switch (createStatus) {
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
