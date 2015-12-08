using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace MVCApp.Models
{

    public class InstalacionModel
    {
        [Required]
        [Display(Name = "Nombre del sitio")]
        public string SiteName { get; set; }

        [Required]
        [Display(Name = "Nombre del SuperUsuario")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Apellido del SuperUsuario")]
        public string UserLastName { get; set; }

        [Required]
        [Display(Name = "DNI")]
        public string DNI { get; set; }

        [Required]
        [Display(Name = "Email del SuperUsuario")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Required]
        [Display(Name = "Logo del sitio")]
        [DataType(DataType.Upload)]
        public string SiteLogo { get; set; }

        [Required]
        [Display(Name = "Super Administrador Color")]
        public string SuperColor { get; set; }

        [Required]
        [Display(Name = "Administrador Color")]
        public string AdminColor { get; set; }

        [Required]
        [Display(Name = "Empleado Color")]
        public string EmplColor { get; set; }

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
