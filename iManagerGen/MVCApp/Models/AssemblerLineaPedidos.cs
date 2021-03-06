﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CEN.IManager;
namespace MVCApp.Models {
    public class AssemblerLineaPedidos {
        public LineaPedidosModels ConvertENToModelUI(LineaPedidoEN en) {
            LineaPedidosModels lPedidos = new LineaPedidosModels();
            lPedidos.cantidad = en.Cantidad;
            if (en.Producto != null) {
                lPedidos.referencia = en.Producto.Referencia;
                lPedidos.nombre = en.Producto.Nombre;
            } else {
                lPedidos.referencia = "No disponible";
                lPedidos.nombre = "No disponible";
            }
            return lPedidos;
        }
        public IList<LineaPedidosModels> ConvertListENToModel(IList<LineaPedidoEN> ens) {
            IList<LineaPedidosModels> usu = new List<LineaPedidosModels>();
            foreach (LineaPedidoEN en in ens) {
                usu.Add(ConvertENToModelUI(en));
            }
            return usu;
        }
    }
}