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

        public int RestarStockConfirmarVentaHacerMovimiento(int p_oid_pedido, DateTime p_fechaVenta)
        {
            IVentaCAD _IVentaCAD = null;
            VentaCEN ventaCEN = null;
            VentaEN ventaEN = null;
            ProductoCP productoCP = null;
            MovimientoCP movimientoCP = null;

            try
            {
                SessionInitializeTransaction();
                _IVentaCAD = new VentaCAD(session);
                ventaCEN = new VentaCEN(_IVentaCAD);
                //Recuperamos el pedido del CAD
                ventaEN = _IVentaCAD.ReadOIDDefault(p_oid_pedido);
                //Creamos el CP de productos y le pasamos la sesion
                productoCP = new ProductoCP(session);
                //Llamamos a la funcion RestarStock
                productoCP.RestarStock(ventaEN.LineaVenta);
                //Modificamos los valores del pedido, cambiando su estado a confirmado y indicando la fecha de la confirmacion.
                ventaCEN.Modify(ventaEN.Id, p_fechaVenta);
                movimientoCP.CrearMovimiento(ventaEN.Id, "INGRESO");

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

            return oid;
        }

    }
}
