using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.Enumerated.IManager;

namespace MVCApp.Models {
    public class PedidoModels {
        public int id { get; set; }

        [Display(Prompt = "Descripción", Description = "Descripción del pedido", Name = "Descripcion")]
        [Required]
        public string Descripcion { get; set; }

        [Display(Prompt = "Estado", Description = "Estado del pedido", Name = "Estado")]
        [Required]
        public EstadoPedidoEnum estado { get; set; }

        [Display(Prompt = "Fecha de pedido", Description = "Fecha del pedido", Name = "FechaRealizacion")]
        [Required]
        public DateTime fechaRealizacion { get; set; }

        [Display(Prompt = "Fecha de confirmación", Description = "Fecha de confirmación del pedido", Name = "FechaConfirmacion")]
        [Required]
        public DateTime fechaConfirmacion { get; set; }

        [Display(Prompt = "Fecha de cancelación", Description = "Fecha de cancelación del pedido", Name = "FechaCancelacion")]
        [Required]
        public DateTime fechaCancelacion { get; set; }
    }
}