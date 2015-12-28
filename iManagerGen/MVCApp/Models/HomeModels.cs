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
        public int numeroUsuarios { get; set; }
        public int numeroVentas { get; set; }
        public int numeroPedidiosPendientes { get; set; }
        public int numeroProductos { get; set; }
    }
}