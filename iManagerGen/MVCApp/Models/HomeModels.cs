using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IManagerGenNHibernate.EN.IManager;
namespace MVCApp.Models {
    public class HomeModels {
        public List<List<double>> totalAnyoGastos { get; set;}
        public List<List<double>> totalAnyoIngresos {get; set;}
        public IEnumerable<PedidoEN> PedidosPendientes {get; set;}
        public IEnumerable<ProveedorModels> listaProveedores { get; set; }
        public long numeroUsuarios { get; set; }
        public long numeroVentas { get; set; }
        public long numeroPedidiosPendientes { get; set; }
        public long numeroProductos { get; set; }
        public List<double> totalIngresos{ get; set;}
        public List<double> totalGastos { get; set; }
        public List<double> ganancia { get; set; }
        public IEnumerable<PedidoEN> listaUltimosPedidos { get; set; }
        public IEnumerable<ProductoEN> productosMasVendidos {get; set;}
        public long otrosCuenta { get; set; }
        public HomeModels() {
            totalIngresos = new List<double>();
            totalGastos = new List<double>();
            ganancia = new List<double>();
        }
    }
}