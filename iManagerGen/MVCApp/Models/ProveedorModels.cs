﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IManagerGenNHibernate.EN.IManager;

namespace MVCApp.Models {
    public class ProveedorModels {

        [Display(Prompt = "Email", Description = "Email del proveedor", Name = "Email")]
        [Required(ErrorMessage = "Debe asignar email al proveedor")]
        public string Email { get; set; }

        [Display(Prompt = "Nombre", Description = "Nombre del proveedor", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para el proveedor")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "CIF", Description = "CIF del proveedor", Name = "CIF del proveedor")]
        [Required(ErrorMessage = "Debe indicar un CIF para el proveedor")]
        public string CIF { get; set; }

        [Display(Prompt = "Teléfono", Description = "Teléfono del proveedor", Name = "Telefono")]
        [Required(ErrorMessage = "Debe indicar un teléfono para el proveedor")]
        public string Telefono { get; set; }

        [Display(Prompt = "Direccion", Description = "Direccion del proveedor", Name = "Direccion")]
        [Required(ErrorMessage = "Debe indicar una direccion para el proveedor")]
        public string Direccion { get; set; }

        [Display(Prompt = "Localidad", Description = "Localidad del proveedor", Name = "Localidad")]
        [Required(ErrorMessage = "Debe indicar una localidad para el proveedor")]
        public string Localidad { get; set; }

        [Display(Prompt = "Pais", Description = "Pais del proveedor", Name = "Pais")]
        [Required(ErrorMessage = "Debe indicar un Pais para el proveedor")]
        public string Pais { get; set; }

        
    }
}