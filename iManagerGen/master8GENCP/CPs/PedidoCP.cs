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
    public class PedidoCP : BasicCP
    {

        public PedidoCP() : base() { }

        public PedidoCP(ISession sessionAux) : base(sessionAux)
        {
        }

        public void AumentarStockConfirmarPedidoHacerMovimiento(int p_oid_pedido,DateTime p_fechaConfirmacion,EstadoPedidoEnum estado)
        {
            IPedidoCAD _IPedidoCAD = null;
            PedidoCEN pedidoCEN = null;
            PedidoEN pedidoEN = null;

            ProductoCP productoCP = null;

            try
            {
                SessionInitializeTransaction();
                _IPedidoCAD = new PedidoCAD(session);
                pedidoCEN = new PedidoCEN(_IPedidoCAD);
                //Recuperamos el pedido del CAD
                pedidoEN = _IPedidoCAD.ReadOIDDefault(p_oid_pedido);
                //Creamos el CP de productos y le pasamos la sesion
                productoCP = new ProductoCP(session);
                //Llamamos a la funcion SumarStock
                productoCP.SumarStock(pedidoEN.LineaPedido);


                
                //pedidoCEN.Modify();
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

           // return oid;
        }
       
    }
}
