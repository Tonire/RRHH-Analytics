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
    }
}