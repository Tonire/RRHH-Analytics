using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;
using Newtonsoft.Json;
namespace MVCApp.Controllers
{
    public class MensajesController : BasicController
    {
        //
        // GET: /Mensajes/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Mensajes/Details/5
        
        public string Details(int id)
        {
            return null;
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
                sJSON = sJSON + "\"Asunto\":\"" + listaMensajes[i].Asunto + "\", \"Remitente\":\"" + listaMensajes[i].Remitente.Email + "\", \"Rol\": \"" + usuarioRemitente.GetType().Name + "\"";
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
        // GET: /Mensajes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Mensajes/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Mensajes/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Mensajes/Edit/5

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
        // GET: /Mensajes/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Mensajes/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
