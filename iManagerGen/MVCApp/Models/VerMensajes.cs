using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CEN.IManager;
namespace MVCApp.Models {
    public class VerMensajes {
        public VerMensajesModels ConvertENToModelUI(MensajeEN mensaje) {
            if (mensaje != null) {
                VerMensajesModels modeloMensaje = new VerMensajesModels();
                MensajeCEN mensajeCEN = new MensajeCEN();
                long noLeidos = mensajeCEN.ContarMensajesNoLeidosByDestinatario(mensaje.Destinatario.Email);
                modeloMensaje.Cuenta = noLeidos;
                modeloMensaje.IdMensaje = mensaje.Id.ToString();
                modeloMensaje.Nombre = mensaje.Remitente.Nombre;
                modeloMensaje.Apellidos = mensaje.Remitente.Apellidos;
                modeloMensaje.Asunto = mensaje.Asunto;
                modeloMensaje.Contenido = mensaje.Contenido;

                DateTime? when = mensaje.Fecha;
                TimeSpan ts = DateTime.Now.Subtract((DateTime)when);
                if (ts.TotalHours < 1){
                    modeloMensaje.Tiempo = "Hace " + (int)ts.TotalMinutes + " minutos";
                } else if (ts.TotalDays < 1) {
                    modeloMensaje.Tiempo = "Hace " + (int)ts.TotalHours + " horas";
                }else{
                    modeloMensaje.Tiempo = "Hace " + (int)ts.TotalDays + " dias";
                }

                    
            }
        }
        public IList<VerMensajesModels> ConvertListENToModel(IList<MensajeEN> ens) {
            IList<VerMensajesModels> usu = new List<VerMensajesModels>();
            foreach (MensajeEN en in ens) {
                usu.Add(ConvertENToModelUI(en));
            }
            return usu;
        }
    }
}