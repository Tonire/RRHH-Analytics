using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using IManagerGenNHibernate.EN.IManager;
namespace MVCApp.Models {
    public class CrearMensajeModels {
        public string Remitente { get; set; }

        [Display(Prompt = "Destinatario", Description = "Destinatario del mensaje", Name = "Destinatario")]
        [Required(ErrorMessage = "Debe indicar un destinatario")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Introduce un email válido.")]
        public string Destinatario { get; set; }

        public string DestinatarioNombre { get; set; }

        [Display(Prompt = "Asunto", Description = "Asunto del mensaje", Name = "Asunto")]
        [Required(ErrorMessage = "Debe indicar un campo para el Asunto")]
        [StringLength(maximumLength: 50, ErrorMessage = "El Asunto no puede superar los 50 carácteres.")]
        public string Asunto { get; set; }

        [Required(ErrorMessage = "Debe indicar un campo para el contenido del Mensaje")]
        [StringLength(maximumLength: 1000, ErrorMessage = "El Contenido del Mensaje no puede superar los 1000 carácteres.")]
        public string Contenido { get; set; }

        public IEnumerable<UsuarioModels> Usuarios { get; set; }
    }
}