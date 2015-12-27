using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IManagerGenNHibernate.EN.IManager;
namespace MVCApp.Models {
    public class HomeModels {
        public double[] totalAñoGastos;
        public double[] totalAñoIngresos;
        public IEnumerable<PedidoEN> PedidosPendientes;
    }
}