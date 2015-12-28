using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IManagerGenNHibernate.EN.IManager;
namespace MVCApp.Models {
    public class HomeModels {
        public IList<double> totalAnyoGastos { get; set;}
        public IList<double> totalAnyoIngresos {get; set;}
        public IEnumerable<PedidoEN> PedidosPendientes {get; set;}
        public IEnumerable<ProveedorModels> listaProveedores { get; set; }
        public long numeroUsuarios { get; set; }
        public long numeroVentas { get; set; }
        public long numeroPedidiosPendientes { get; set; }
        public long numeroProductos { get; set; }
    }
}