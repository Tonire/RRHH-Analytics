using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CEN.IManager;
namespace MVCApp.Models {
    public class VerMensajes {
        public VerMensajesModels ConvertENToModelUI(MensajeEN mensaje) {
            VerMensajesModels modeloMensaje = null;
            if (mensaje != null) {
                modeloMensaje = new VerMensajesModels();
                MensajeCEN mensajeCEN = new MensajeCEN();

                modeloMensaje.IdMensaje = mensaje.Id.ToString();
                modeloMensaje.Nombre = mensaje.Remitente.Nombre;
                modeloMensaje.Apellidos = mensaje.Remitente.Apellidos;
                modeloMensaje.Asunto = mensaje.Asunto;
                modeloMensaje.Contenido = mensaje.Contenido;
                int longitud = mensaje.Contenido.Length;
                if(longitud>41){
                    modeloMensaje.ContenidoPreview = mensaje.Contenido.Substring(0, 41);
                }else {
                    modeloMensaje.ContenidoPreview = mensaje.Contenido;
                }
                
                DateTime? when = mensaje.Fecha;
                TimeSpan ts = DateTime.Now.Subtract((DateTime)when);
                if (ts.TotalHours < 1){
                    modeloMensaje.Tiempo = "Hace " + (int)ts.TotalMinutes + " minuto(s)";
                } else if (ts.TotalDays < 1) {
                    modeloMensaje.Tiempo = "Hace " + (int)ts.TotalHours + " hora(s)";
                }else{
                    modeloMensaje.Tiempo = "Hace " + (int)ts.TotalDays + " día(s)";
                }

                
            }
            return modeloMensaje;
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