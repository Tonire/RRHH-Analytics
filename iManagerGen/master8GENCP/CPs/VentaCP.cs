using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;
using IManagerGenNHibernate.CEN.IManager;
//using master8GenNHibernate.EN.Petstore3; // <- Apuntar a los respectivos paquetes de vuestro proyecto.
//using master8GenNHibernate.CAD.Petstore3;
//using master8GenNHibernate.CEN.Petstore3;
using NHibernate;
using IManagerGenNHibernate.Enumerated.IManager;

namespace EjemploProyectoCP.CPs
{
    public class VentaCP : BasicCP
    {

        public VentaCP() : base() { }

        public VentaCP(ISession sessionAux)
            : base(sessionAux)
        {
        }

        public void RestarStockCrearVentaHacerMovimiento(string p_usuario,DateTime p_fechaVenta, IList<LineaVentaEN> p_lineasVenta)
        {
            IVentaCAD _IVentaCAD = null;
            VentaCEN ventaCEN = null;
            ProductoCP productoCP = null;
            MovimientoCP movimientoCP = null;
            int p_oid_venta;

            try
            {
                SessionInitializeTransaction();
                _IVentaCAD = new VentaCAD(session);
                ventaCEN = new VentaCEN(_IVentaCAD);
                //Recuperamos el pedido del CAD
                p_oid_venta = ventaCEN.NuevaVenta(p_usuario,p_lineasVenta,p_fechaVenta);
                //Creamos el CP de productos y le pasamos la sesion
                productoCP = new ProductoCP(session);
                //Llamamos a la funcion RestarStock
                productoCP.RestarStock(p_lineasVenta);
                movimientoCP.CrearMovimiento(p_oid_venta, TipoMovimientoEnum.ingreso);

                SessionCommit();

            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }

        }

    }
}
