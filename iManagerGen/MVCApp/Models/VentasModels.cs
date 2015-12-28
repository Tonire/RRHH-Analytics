using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using IManagerGenNHibernate.EN.IManager;

namespace MVCApp.Models {
    public class VentasModels {
        public IList<LineaVentasModels> lineas { get; set; }
        public VentasModels() {
            lineas = new List<LineaVentasModels>();
        }
        [Display(Name = "Productos")]
        public IEnumerable<ProductoEN> productos { get; set; }

        //public IList<string> proovedoresStrings { get; set; }
        //public string[] selectedProveedores { get; set; }
        public IEnumerable<string> SelectedProducto { get; set; }
        
    }
}