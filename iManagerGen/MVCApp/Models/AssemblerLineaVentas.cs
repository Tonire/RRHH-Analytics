using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CEN.IManager;
namespace MVCApp.Models {
    public class AssemblerLineaVentas {
        public LineaVentasModels ConvertENToModelUI(LineaVentaEN en) {
            LineaVentasModels ventas = new LineaVentasModels();
            ventas.cantidad = en.Cantidad;
            ventas.referencia = en.Producto.Referencia;

            return ventas;
        }
        public IList<LineaVentasModels> ConvertListENToModel(IList<LineaVentaEN> ens) {
            IList<LineaVentasModels> usu = new List<LineaVentasModels>();
            foreach (LineaVentaEN en in ens) {
                usu.Add(ConvertENToModelUI(en));
            }
            return usu;
        }
    }
}