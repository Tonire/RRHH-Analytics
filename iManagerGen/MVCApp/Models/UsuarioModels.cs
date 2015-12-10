using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApp.Models {
    public class UsuarioModels {

        [Display(Prompt = "Rol", Description = "Rol del usuario", Name = "Rol")]
        [Required(ErrorMessage = "Debe un rol para el usuario")]
        [Range(minimum: 0, maximum: 2, ErrorMessage = "Debes introducir un Rol válido.")]
        public string Rol { get; set; }

        [Display(Prompt = "Email", Description = "Email del usuario", Name = "Email")]
        [Required(ErrorMessage = "Debe indicar un nombre para el usuario")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El precio debe ser un valor numérico")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Email { get; set; }

        [Display(Prompt = "DNI", Description = "DNI del usuario", Name = "DNI")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string DNI { get; set; }

        [Display(Prompt = "Nombre", Description = "Nombre del usuario", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Apellidos", Description = "Apellidos del usuario", Name = "Apellidos")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
       
    }
}