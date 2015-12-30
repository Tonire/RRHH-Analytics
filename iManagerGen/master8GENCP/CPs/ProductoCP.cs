using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IManagerGenNHibernate.CAD.IManager;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.Exceptions;

namespace EjemploProyectoCP.CPs {
    public class ProductoCP : BasicCP {
        public ProductoCP() : base() { }
        public ProductoCP(ISession sessionAux) : base(sessionAux) { }

        public void RestarStock(IList<LineaVentaEN> lineasPedidos) {
            IProductoCAD _IProductoCAD = null;
            ProductoCEN productoCEN = null;
            try {
                SessionInitializeTransaction();
                _IProductoCAD = new ProductoCAD(session);
                productoCEN = new ProductoCEN(_IProductoCAD);
                int stock = 0;
                int ventas=0;
                foreach (LineaVentaEN lp in lineasPedidos) {
                    stock = lp.Producto.Stock - lp.Cantidad;
                    ventas = lp.Producto.Ventas + 1 * lp.Cantidad; ;
                    if (stock >= 0) {
                        productoCEN.Modify(lp.Producto.Referencia, lp.Producto.Nombre, lp.Producto.Marca, lp.Producto.PrecioCompra, lp.Producto.PrecioVenta, stock,ventas);
                    } else {
                        throw new ModelException("Stock insuficiente: "+stock+" Producto: "+lp.Producto.Nombre);
                    }
                }
                SessionCommit();
            } catch (Exception ex) {
                SessionRollBack();
                throw ex;
            } finally {
                SessionClose();
            }
        }

        public void SumarStock(IList<LineaPedidoEN> lineasPedidos) {
            IProductoCAD _IProductoCAD = null;
            ProductoCEN productoCEN = null;
            try {
                SessionInitializeTransaction();
                _IProductoCAD = new ProductoCAD(session);
                productoCEN = new ProductoCEN(_IProductoCAD);
                int stock = 0;
                foreach (LineaPedidoEN lp in lineasPedidos) {
                    stock = lp.Producto.Stock + lp.Cantidad;
                    productoCEN.Modify(lp.Producto.Referencia, lp.Producto.Nombre, lp.Producto.Marca, lp.Producto.PrecioCompra, lp.Producto.PrecioVenta, stock,lp.Producto.Ventas);
                }
                SessionCommit();
            } catch (Exception ex) {
                SessionRollBack();
                throw ex;
            } finally {
                SessionClose();
            }
        }

    }
}
