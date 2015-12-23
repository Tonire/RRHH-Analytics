using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IManagerGenNHibernate.EN.IManager;
namespace MVCApp.Models {
    public class CrearMensajeModels {
        public string Remitente { get; set; }
        public string Destinatario { get; set; }
        public string DestinatarioNombre { get; set; }
        public string Asunto { get; set; }
        public string Contenido { get; set; }
        public IEnumerable<UsuarioModels> Usuarios { get; set; }
    }
}