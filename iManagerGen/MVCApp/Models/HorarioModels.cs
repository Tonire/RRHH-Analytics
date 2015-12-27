using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCApp.Models {
    public class HorarioModels {
        [Display(Prompt = "Titulo", Description = "Titulo del horario", Name = "Titulo")]
        [Required(ErrorMessage = "Debe indicar nombre para el horario")]
        [StringLength(maximumLength: 20, ErrorMessage = "El Horario no puede superar los 20 carácteres.")]
        public string Titulo { get; set; }
        [Display(Prompt = "Año", Description = "Año del horario", Name = "Año")]
        [Required(ErrorMessage = "Debes seleccionar un año para el horario.")]
        [Range(minimum: 2015, maximum: 2017, ErrorMessage = "Debes introducir un Año válido.")]
        public string Año { get; set; }
        [Display(Prompt = "Mes", Description = "Mes del horario", Name = "Mes")]
        [Required(ErrorMessage = "Debes seleccionar un mes para el horario.")]
        [Range(minimum: 1, maximum: 12, ErrorMessage = "Debes introducir un Mes válido.")]
        public string Mes { get; set; }
        [Display(Name = "Añadir horario a Usuarios")]
        public IEnumerable<UsuarioModels> Usuarios { get; set; }
    }
}