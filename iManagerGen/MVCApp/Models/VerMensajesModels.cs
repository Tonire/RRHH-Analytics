using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApp.Models {
    public class VerMensajesModels {
        
        public long Cuenta { get; set; }
        public string IdMensaje { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Asunto { get; set; }
        public string Contenido { get; set; }
        public string Tiempo { get; set; }

    }
}