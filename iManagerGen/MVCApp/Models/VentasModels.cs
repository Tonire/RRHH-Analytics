using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApp.Models {
    public class VentasModels {
        public IList<LineaVentasModels> lineas { get; set; }
        public VentasModels() {
            lineas = new List<LineaVentasModels>();
        }
        
    }
}