using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IManagerGenNHibernate.EN.IManager;
using IManagerGenNHibernate.CAD.IManager;
using IManagerGenNHibernate.CEN.IManager;
using NHibernate;
using IManagerGenNHibernate.Enumerated.IManager;
namespace EjemploProyectoCP.CPs
{
    public class MovimientoCP : BasicCP
    {

        public MovimientoCP() : base() { }

        public MovimientoCP(ISession sessionAux)
            : base(sessionAux)
        {
        }
        /*Este metodo se encarga de calcular el total de un pedido o venta y de ingresar un movimiento que puede ser
        un ingreso para las ventas o un gasto para los pedidos*/
        public void CrearMovimiento(int p_oid,TipoMovimientoEnum tipo)
        {
            
            IMovimientosCAD _IMovimientosCAD = null;
            MovimientosCEN movimientosCEN = null;
            IPedidoCAD _IPedidoCAD = null;
            PedidoCEN pedidoCEN = null;
            IVentaCAD _IVentaCAD = null;
            VentaCEN ventaCEN = null;
            PedidoEN pedidoEN = null;
            VentaEN ventaEN = null;
            try
            {
                SessionInitializeTransaction();
                _IMovimientosCAD = new MovimientosCAD(session);
                movimientosCEN = new MovimientosCEN(_IMovimientosCAD);
                
                int total = 0;
                int anyo = 0;
                int mes = 0;
                int movimiento = 0;
                switch (tipo)
                {
                    case TipoMovimientoEnum.ingreso:
                        _IVentaCAD = new VentaCAD(session);
                        ventaCEN = new VentaCEN(_IVentaCAD);
                        ventaEN = _IVentaCAD.ReadOIDDefault(p_oid);
                        anyo = ventaEN.FechaVenta.Value.Year;
                        mes = ventaEN.FechaVenta.Value.Month;
                        ventaEN = _IVentaCAD.ReadOIDDefault(p_oid);
                        foreach (LineaVentaEN lp in ventaEN.LineaVenta)
                        {
                            total = total+(lp.Producto.PrecioVenta * lp.Cantidad);
                        }
                        //Creamos el movimiento con el anyo y mes de la venta, tipo y el total calculado
                        movimiento = movimientosCEN.CrearMovimiento(anyo,mes,tipo,total);
                        movimientosCEN.RelationerVenta(movimiento,p_oid);
                    break;

                    case TipoMovimientoEnum.gasto:
                        _IPedidoCAD = new PedidoCAD(session);
                        pedidoCEN = new PedidoCEN(_IPedidoCAD);
                        pedidoEN=_IPedidoCAD.ReadOIDDefault(p_oid);
                        anyo = pedidoEN.FechaConfirmacion.Value.Year;
                        mes = pedidoEN.FechaConfirmacion.Value.Month;
                        pedidoEN = _IPedidoCAD.ReadOIDDefault(p_oid);
                        foreach (LineaPedidoEN lp in pedidoEN.LineaPedido)
                        {
                            total = total+(lp.Producto.PrecioCompra * lp.Cantidad);
                        }
                        movimiento = movimientosCEN.CrearMovimiento(anyo, mes, tipo, total);
                        movimientosCEN.RelationerPedido(movimiento, p_oid);
                        break;
                    
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

            
        }

    }
}