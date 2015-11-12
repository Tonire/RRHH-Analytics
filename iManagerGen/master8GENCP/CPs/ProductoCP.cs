using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using IManagerGenNHibernate.CAD.IManager;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CEN.IManager;
using IManagerGenNHibernate.Exceptions;

namespace EjemploProyectoCP.CPs {
    public class ProductoCP : BasicCP {
        public ProductoCP() : base() { }
        public ProductoCP(ISession sessionAux) : base(sessionAux) { }

        public void RestarStock(IList<LineaPedidoEN> lineasPedidos) {
            IProductoCAD _IProductoCAD = null;
            ProductoCEN productoCEN = null;
            try {
                SessionInitializeTransaction();
                _IProductoCAD = new ProductoCAD(session);
                productoCEN = new ProductoCEN(_IProductoCAD);
                int stock = 0;

                foreach (LineaPedidoEN lp in lineasPedidos) {
                    stock = lp.Producto.Stock - lp.Cantidad;
                    if (stock >= 0) {
                        productoCEN.Modify(lp.Producto.Referencia, lp.Producto.Nombre, lp.Producto.Marca, lp.Producto.PrecioCompra, lp.Producto.PrecioVenta, stock);
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
                    productoCEN.Modify(lp.Producto.Referencia, lp.Producto.Nombre, lp.Producto.Marca, lp.Producto.PrecioCompra, lp.Producto.PrecioVenta, stock);
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
