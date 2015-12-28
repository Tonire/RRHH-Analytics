using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;
using MVCApp.Models;
using Newtonsoft.Json;
namespace MVCApp.Controllers
{
    public class MensajesController : BasicController
    {
        //
        // GET: /Mensajes/
        [Authorize]
        public ActionResult Index()
        {
            SessionInitialize();
            MensajeCAD mensajeCAD = new MensajeCAD(session);
            MensajeCEN mensajeCEN = new MensajeCEN(mensajeCAD);
            IList<MensajeEN> mensajes = mensajeCEN.GetMensajesByDestinatario(User.Identity.Name,0,-1);
            IEnumerable<VerMensajesModels> listaMensajes = new VerMensajes().ConvertListENToModel(mensajes).ToList();
            long noLeidos = mensajeCEN.ContarMensajesNoLeidosByDestinatario(User.Identity.Name);
            ViewData["cuenta"] = noLeidos;
            SessionClose();
            return View(listaMensajes);
        }

        //
        // GET: /Mensajes/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            SessionInitialize();
            MensajeCAD mensajeCAD = new MensajeCAD(session);
            MensajeCEN mensajeCEN = new MensajeCEN(mensajeCAD);
            MensajeEN mensajeEN=mensajeCEN.GetMensaje(id);
            VerMensajesModels mensaje = new VerMensajes().ConvertENToModelUI(mensajeEN);
            SessionClose();
            if (mensajeEN.Destinatario.Email.CompareTo(User.Identity.Name) != 0 || mensajeEN.Remitente.Email.CompareTo(User.Identity.Name)!=0) {
                RedirectToAction("Index", "Mensajes");
            }
            MensajeCEN mensajeCEN2 = new MensajeCEN();
            mensajeCEN2.Modify(mensajeEN.Id, mensajeEN.Asunto, mensajeEN.Contenido, true, mensajeEN.Fecha, mensajeEN.Borrado);
            return View(mensaje);
        }


        // GET: /Mensajes/getUltimosMensajes/
        [Authorize]
        public string getUltimosMensajes() {
            SessionInitialize();

            MensajeCAD mensajeCAD = new MensajeCAD(session);
            MensajeCEN mensajeCEN = new MensajeCEN(mensajeCAD);
            IList<MensajeEN> listaMensajes;
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            
            string emailUsuario = User.Identity.Name;
            string sJSON = "[";
            //mensajeCEN.CreaMensaje("hector@hotmail.com",emailUsuario,"Hola Toni","Soy Hector",false);
            listaMensajes = mensajeCEN.GetMensajesByDestinatario(emailUsuario, 0, 5);

            string remitente;
            UsuarioEN usuarioRemitente;

            for (int i = 0; i < listaMensajes.Count; i++) {
                remitente = listaMensajes[i].Remitente.Email;
                usuarioRemitente = usuarioCEN.GetUsuarioByEmail(remitente);

                sJSON = sJSON + "{";
                sJSON = sJSON + "\"Asunto\":\"" + listaMensajes[i].Asunto + "\", \"Remitente\":\"" + listaMensajes[i].Remitente.Nombre + " " + listaMensajes[i].Remitente.Apellidos + "\", \"Rol\": \"" + usuarioRemitente.GetType().Name + "\"";
                if (i == listaMensajes.Count - 1) {
                    sJSON = sJSON + "}";
                } else {
                    sJSON = sJSON + "},";
                }
                
            }
            sJSON = sJSON + "]";
            SessionClose();
            return sJSON;
        }

        //
        // GET: /Mensajes/Crear
        [Authorize]
        public ActionResult Crear()
        {
            MensajeCEN mensajeCEN = new MensajeCEN();
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuario = new UsuarioEN();
            CrearMensajeModels mensaje = new CrearMensajeModels();
            IList<UsuarioEN> list = usuarioCEN.DameTodos(0, -1);
            IEnumerable<UsuarioModels> listUsu = new AssemblerUsuarios().ConvertListENToModel(list).ToList();
            mensaje.Usuarios = listUsu;
            long noLeidos = mensajeCEN.ContarMensajesNoLeidosByDestinatario(User.Identity.Name);
            ViewData["cuenta"] = noLeidos;
            return View(mensaje);
        }

        //
        // POST: /Mensajes/Create
        [Authorize]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Crear(CrearMensajeModels model)
        {
            try
            {
                MensajeCEN mensajeCEN = new MensajeCEN();
                mensajeCEN.CreaMensaje(User.Identity.Name,model.Destinatario,model.Asunto,model.Contenido,false,DateTime.Now,false);
                TempData["Creado"] = true;
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Error"] = true;
                return View(model);
            }
        }
        //
        // GET: /Mensajes/Salida
        [Authorize]
        public ActionResult Salida() {
            SessionInitialize();
            MensajeCAD mensajeCAD = new MensajeCAD(session);
            MensajeCEN mensajeCEN = new MensajeCEN(mensajeCAD);
            IList<MensajeEN> mensajes = mensajeCEN.GetMensajesByRemitente(User.Identity.Name);
            for (int i = 0; i < mensajes.Count();i++ ) {
                if (mensajes[i].Borrado == true) {
                    mensajes.RemoveAt(i);
                    i--;
                }
            }
            IEnumerable<VerMensajesModels> listaMensajes = new VerMensajes().ConvertListENToModel(mensajes).ToList();
            long noLeidos = mensajeCEN.ContarMensajesNoLeidosByDestinatario(User.Identity.Name);
            ViewData["cuenta"] = noLeidos;
            SessionClose();
            return View(listaMensajes);
        }

        //
        // GET: /Mensajes/Delete/5
        [Authorize]
        public string Delete(int id)
        {
            try
            {
                SessionInitialize();
                MensajeCAD mensajeCAD = new MensajeCAD();
                MensajeCEN mensajeCEN = new MensajeCEN(mensajeCAD);
                if(mensajeCEN.GetMensaje(id).Destinatario.Email.CompareTo(User.Identity.Name)==0){
                    mensajeCEN.Destroy(id);
                } else {
                    TempData["ErrorBorr"] = true;
                    RedirectToAction("Index");
                    return "Error";
                }
                SessionClose();
                return "1";
            }
            catch
            {
                TempData["ErrorBorr"] = true;
                RedirectToAction("Index");
                return "0";
            }
        }
        //
        // GET: /Mensajes/Borrar/5
        [Authorize]
        public string Borrar(int id) {
            try {
                SessionInitialize();
                MensajeCAD mensajeCAD = new MensajeCAD();
                MensajeCEN mensajeCEN = new MensajeCEN(mensajeCAD);
                MensajeEN mensajeEN= mensajeCEN.GetMensaje(id);
                if (mensajeEN.Remitente.Email.CompareTo(User.Identity.Name) == 0) {
                    mensajeCEN.Modify(mensajeEN.Id,mensajeEN.Asunto,mensajeEN.Contenido,mensajeEN.Leido,mensajeEN.Fecha,true);
                } else {
                    TempData["ErrorBorr"] = true;
                    RedirectToAction("Salida");
                    return "Error";
                }
                SessionClose();
                return "1";
            } catch {
                TempData["ErrorBorr"] = true;
                RedirectToAction("Salida");
                return "0";
            }
        }
    }
}
