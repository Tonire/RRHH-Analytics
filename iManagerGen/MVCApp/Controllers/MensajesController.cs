﻿using System;
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
        [HttpPost]
        public ActionResult Crear(CrearMensajeModels model)
        {
            try
            {
                MensajeCEN mensajeCEN = new MensajeCEN();
                mensajeCEN.CreaMensaje(User.Identity.Name,model.Destinatario,model.Asunto,model.Contenido,false,DateTime.Now);
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
        public ActionResult 

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
    }
}
