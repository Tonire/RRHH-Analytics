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
using IManagerGenNHibernate.Exceptions;

namespace EjemploProyectoCP.CPs
{
    public class PedidoCP : BasicCP
    {

        public PedidoCP() : base() { }

        public PedidoCP(ISession sessionAux) : base(sessionAux)
        {
        }
        /*Este metodo se encarga de aumentar el stock de cada uno de los articulos contenidos en las lineas de pedido del pedido
        pasado por parámetro. Una vez hecho esto confirma el pedido, modificando para ello el estado del pedido y estableciendo
        la fecha de la confirmacion del pedido. Además inserta en la tabla movimientos el gasto.
        OJO: No puedes confirmar un pedido que ya ha sido confirmado o esta en estado cancelado*/
        public void AumentarStockConfirmarPedidoHacerMovimiento(int p_oid_pedido,DateTime p_fechaConfirmacion)
        {
            IPedidoCAD _IPedidoCAD = null;
            PedidoCEN pedidoCEN = null;
            PedidoEN pedidoEN = null;
            ProductoCP productoCP = null;
            MovimientoCP movimientoCP = null;

            try
            {
                SessionInitializeTransaction();
                _IPedidoCAD = new PedidoCAD(session);
                pedidoCEN = new PedidoCEN(_IPedidoCAD);
                //Recuperamos el pedido del CAD
                pedidoEN = _IPedidoCAD.ReadOIDDefault(p_oid_pedido);
                if (pedidoEN.Estado==EstadoPedidoEnum.pendiente)
                {
                    //Creamos el CP de productos y le pasamos la sesion
                    productoCP = new ProductoCP(session);
                    //Llamamos a la funcion SumarStock
                    productoCP.SumarStock(pedidoEN.LineaPedido);
                    //Modificamos los valores del pedido, cambiando su estado a confirmado y indicando la fecha de la confirmacion.
                    pedidoCEN.Modify(pedidoEN.Id, EstadoPedidoEnum.confirmado, pedidoEN.FechaRealizacion, p_fechaConfirmacion, null);
                    movimientoCP = new MovimientoCP(session);
                    movimientoCP.CrearMovimiento(pedidoEN.Id, TipoMovimientoEnum.gasto);
                }
                else
                {
                    throw new ModelException("Error en datos del pedido: "+ pedidoEN.Id+ " , este pedido ya tiene estado: " + pedidoEN.Estado + " y no puede ser confirmado.");
                }
                

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
